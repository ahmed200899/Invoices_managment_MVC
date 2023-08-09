using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Invoice invoice)
    {
        if (ModelState.IsValid)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(invoice);
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
