using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace rest_api_test.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
  private readonly BookContext _context;

  public BooksController(BookContext context)
  {
    _context = context;
  }

  // GET: /api/books
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
  {
    return await _context.Books.ToListAsync();
  }

  // GET: /api/books/1
  [HttpGet("{id}")]
  public async Task<ActionResult<Book>> GetBook(int id)
  {
    var book = await _context.Books.FindAsync(id);

    if (book == null)
    {
      return NotFound();
    }

    return book;
  }

  // POST: /api/books
  [HttpPost]
  public async Task<ActionResult<Book>> PostBook(Book book)
  {
    _context.Books.Add(book);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
  }

  // PUT: /api/books/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutBook(int id, Book book)
  {
    if (id != book.Id)
    {
      return BadRequest();
    }

    _context.Entry(book).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!BookExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  // DELETE: /api/books/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBook(int id)
  {
    var book = await _context.Books.FindAsync(id);
    if (book == null)
    {
      return NotFound();
    }

    _context.Books.Remove(book);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool BookExists(int id)
  {
    return _context.Books.Any(e => e.Id == id);
  }

  // dummy method to test the connection
  [HttpGet("ping")]
  public string Ping()
  {
    return "Pong";
  }
}
