using Data_Access_Layer.Data_Context;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.BookList.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.BookList.ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksByLendUser(int userId)
        {
            return await _context.BookList.Where(r => r.LentByUserId == userId).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksByBorrowedUser(int userId)
        {
            return await _context.BookList.Where(r => r.CurrentlyBorrowedByUserId == userId).ToListAsync();
        }

        public Book AddBook(Book book)
        {
            _context.BookList.Add(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            _context.BookList.Update(book);
            return book;
        }
        public void DeleteBook(Book book)
        {
            _context.BookList.Remove(book);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
