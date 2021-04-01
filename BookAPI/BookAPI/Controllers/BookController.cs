using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }






        // GET: BooksController
        [HttpGet]
        public async Task<IEnumerable<Book>> Index()
        {
            return await bookRepository.Get();
        }

        // GET: BooksController/Details/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<Book>> Details(int id)
        {
            return  await bookRepository.Get(id);
        }

       

        // POST: BooksController/Create
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            var newbook = await bookRepository.Create(book);
            return CreatedAtAction("Get()", new { id = newbook.Id }, newbook);
        }

        // PuT: BooksController/Update
        [HttpPut]

        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await bookRepository.Update(book);
            return NoContent();


        }

        // GET: BooksController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await bookRepository.Get(id);

            if(book is null)
            {
                return NotFound();
            }
            await bookRepository.Delete(book.Id);
            return NoContent();
        }
    }
}
