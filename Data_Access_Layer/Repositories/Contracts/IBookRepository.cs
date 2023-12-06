using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooks();

        Task<IEnumerable<Book>> GetBooksByLendUser(int userId);

        Task<IEnumerable<Book>> GetBooksByBorrowedUser(int userId);
        Book AddBook(Book book);

        Book UpdateBook(Book book);

        void DeleteBook(Book book);
    }
}
