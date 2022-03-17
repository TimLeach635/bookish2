using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Request;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;

    public HomeController(
        ILogger<HomeController> logger,
        IBookService bookService
    )
    {
        _logger = logger;
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BookList()
    {
        var books = _bookService.GetAllBooks();
        return View(books);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookRequest createBookRequest)
    {
        var newBook = _bookService.CreateBook(createBookRequest);

        return Created("/Home/BookList", newBook);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
