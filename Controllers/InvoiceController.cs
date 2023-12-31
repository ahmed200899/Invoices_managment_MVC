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
    public  ActionResult  AddInvoice(float totalprice,string Customer, int Id, DateTime InvoiceDate,List<Holder> invoiceItems )
        {

            
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


            return RedirectToAction("Index");
            


        }
    public async Task<IActionResult> Edit(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);

        var invoiceitem =  _context.InvoiceItems
                                .Where(i=>i.InvoiceId == id)
                                .ToList();


        var  items  = _context.Items.ToList();


        List<item> itemList2 = _context.Items
        .Select(dbItem => new item
        {
            Id = dbItem.Id,
            Itemname = dbItem.Itemname,
            itemprice = dbItem.itemprice
        })
        .ToList();


        viewmodel viewmodel = new viewmodel();
        viewmodel.invoice = invoice;
        viewmodel.invoiceiteme = invoiceitem;
        viewmodel.items = items;

        ViewBag.GroceryItems2 =  new SelectList(items , "Id", "Itemname"); 
        ViewBag.itemslist2 = itemList2; 
        ViewBag.i_nvoice_id = id;             


        return View(viewmodel);
    }


    [HttpPost]
   public  ActionResult  Edit(float totalprice,string Customer, int Id, DateTime InvoiceDate,List<Holder> invoiceItems )
        {


            var current_invoice = _context.Invoices.Find(Id);
            current_invoice.Customer = Customer;
            current_invoice.TotalPrice=totalprice;
            current_invoice.InvoiceDate = InvoiceDate;

            _context.SaveChanges();

            var invoiceitem =  _context.InvoiceItems
                                        .Where(i=>i.InvoiceId == Id )
                                        .ToList();

            _context.InvoiceItems.RemoveRange(invoiceitem);
            _context.SaveChanges();

            foreach(Holder item in invoiceItems)
            {
                InvoiceItem newinvoiceItem = new InvoiceItem();
                newinvoiceItem.InvoiceId = current_invoice.Id; 
                newinvoiceItem.Amount = item.Amount;         
                newinvoiceItem.ItemId = _context.Items.FirstOrDefault(i=>i.Itemname == item.item_Name).Id;

                _context.InvoiceItems.Add(newinvoiceItem);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
            


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
