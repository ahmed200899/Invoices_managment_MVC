using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        var  groceryItems  = new List<item> 
        {
            new item{Id = '1', Itemname = "Milk", itemprice = 40},
            new item{Id = '2', Itemname = "Rice", itemprice = 50},
            new item{Id = '3', Itemname = "cheese", itemprice = 20},
            new item{Id = '4', Itemname = "Apples", itemprice = 100},
            new item{Id = '5', Itemname = "orange", itemprice=70}
        };  

       ViewBag.GroceryItems =  new SelectList(groceryItems , "itemprice", "Itemname");        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateInvoiceViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var invoice = viewModel.Invoice;
            invoice.InvoiceDate = DateTime.Now;

            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            foreach (var itemId in viewModel.SelectedItemIds)
            {
                var invoiceItem = new InvoiceItem
                {
                    InvoiceId = invoice.Id,
                    ItemId = itemId
                };
                _context.InvoiceItems.Add(invoiceItem);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Invoice"); // Redirect to the Invoice controller's Index action
        }

        viewModel.AvailableItems = _context.Items.ToList();
        return View(viewModel);
    }


        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
                return NotFound();

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
                return NotFound();

            return View(invoice);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
                return NotFound();

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
