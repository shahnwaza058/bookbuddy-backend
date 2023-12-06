using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class BookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookServices(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }
        public async Task<IEnumerable<Book>> GetBooksByLendUser(int userId)
        {
            return await _bookRepository.GetBooksByLendUser(userId);
        }
        public async Task<IEnumerable<Book>> GetBooksByBorrowedUser(int userId)
        {
            return await _bookRepository.GetBooksByBorrowedUser(userId);
        }

        public Book AddBook(Book book)
        {
            Book newBook=_bookRepository.AddBook(book);
            _unitOfWork.SaveChanges().Wait();
            return newBook;
        }

        public Book UpdateBook(Book book)
        {
            Book updatedBook=_bookRepository.UpdateBook(book);  
            _unitOfWork.SaveChanges().Wait();  
            return updatedBook;
        }
        public void DeleteBook(Book book)
        {
           _bookRepository.DeleteBook(book);
            _unitOfWork.SaveChanges().Wait();
        }

    }
}
