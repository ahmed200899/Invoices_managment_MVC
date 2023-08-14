using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;




public class InvoiceController : Controller
{
    private readonly ApplicationDbContext _context;
    public InvoiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int pagenumber = 1)
    {
        var pagescount = await _context.Invoices.CountAsync();
        var pagesize = 5; 

        var invoices = await _context.Invoices
                                .Skip((pagenumber - 1) * pagesize)
                                .Take(pagesize)
                                .ToListAsync();

        ViewBag.CurrentPage = pagenumber;
        ViewBag.TotalPages = (int)Math.Ceiling((double)pagescount / pagesize);

        return View(invoices);
    }


    public IActionResult Add()
    {
        var  groceryItems  = _context.Items.ToList(); 

        List<item> itemList = _context.Items
        .Select(dbItem => new item
        {
            Id = dbItem.Id,
            Itemname = dbItem.Itemname,
            itemprice = dbItem.itemprice
        })
        .ToList();

        ViewBag.itemslist = itemList;
        ViewBag.GroceryItems =  new SelectList(groceryItems , "Id", "Itemname"); 
        return View();
    }



    [HttpPost]
    public  ActionResult  AddInvoice(float totalprice,string Customer, int Id, DateTime InvoiceDate,List<test> invoiceItems )
        {
            if(!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }
            
            Invoice newinvoice = new Invoice
            {
                Id = Id,
                Customer = Customer,
                TotalPrice = totalprice,
                InvoiceDate = InvoiceDate
            };
            _context.Invoices.Add(newinvoice);
            _context.SaveChanges();

            foreach(var item in invoiceItems)
            {
                InvoiceItem newinvoiceItem = new InvoiceItem();
                newinvoiceItem.InvoiceId = newinvoice.Id; 
                newinvoiceItem.Amount = item.Amount;         
                newinvoiceItem.ItemId = _context.Items.FirstOrDefault(i=>i.Itemname == item.item_Name).Id;

                _context.InvoiceItems.Add(newinvoiceItem);
                _context.SaveChanges();
            }


            string result = $"Received float: {totalprice}, string: {Customer}, int: {Id}, Date: {InvoiceDate}";
            return RedirectToAction("Index");
            


        }

    public async Task<IActionResult> Edit(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return View(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Invoice updatedInvoice)
    {
        if (ModelState.IsValid)
        {
            _context.Update(updatedInvoice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(updatedInvoice);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return View(invoice);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        var invoiceitem =  _context.InvoiceItems
                                        .Where(i=>i.InvoiceId == id)
                                        .ToList();
        if (invoice == null)
        {
            return NotFound();
        }
        _context.InvoiceItems.RemoveRange(invoiceitem);
        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
