﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibManager.Controllers;

public class NoticationController : Controller
{
    private readonly ILogger<NoticationController> _logger;
    private readonly LibDbContext _dbContext;

    public NoticationController(ILogger<NoticationController> logger, LibDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var notications = await _dbContext.Notications.ToListAsync();
        return View(notications);
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        ViewBag.categories = categories;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind] Book book, string category)
    {
        var categories = await _dbContext.Categories.ToListAsync();
        ViewBag.categories = categories;

        try
        {
            var categoryDb = await _dbContext.Categories.FirstOrDefaultAsync(x => x.id == category);
            if (categoryDb == null) throw new Exception("not found category");

            book.category = categoryDb;
            await _dbContext.Books.AddAsync(book);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            return Ok(ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var categories = await _dbContext.Categories.ToListAsync();
        ViewBag.categories = categories;
        try
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.id == id);
            return View(book);
        }
        catch (System.Exception ex)
        {
            return Ok(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind] Book book, string category)
    {
        var categories = await _dbContext.Categories.ToListAsync();
        ViewBag.categories = categories;
        try
        {

            var bookDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.id == book.id);
            if (bookDb != null)
            {
                var categoryDb = await _dbContext.Categories.FirstOrDefaultAsync(x => x.id == category);
                if (categoryDb != null) bookDb.category = categoryDb;
                _dbContext.Entry(bookDb).CurrentValues.SetValues(book);
                await _dbContext.SaveChangesAsync();
            }
            return View(book);
        }
        catch (System.Exception ex)
        {
            return Ok(ex.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> delete(string id)
    {
        try
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.id == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            return Ok(ex.Message);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
