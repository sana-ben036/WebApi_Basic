using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
          var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Get()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }

        public async Task<Book> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }

        public async Task Update(Book model)
        {
            var book = await _context.Books.FindAsync(model.Id);
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }
    }
}
