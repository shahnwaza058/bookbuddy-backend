using Data_Access_Layer.Data_Context;
using Data_Access_Layer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        
        public IUserRepository UserRepository { get; }

        public IBookRepository BookRepository { get; }

      
        public IRatingRepository RatingRepository { get; }

        /// <inheritdoc />
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            BookRepository = new BookRepository(context);
            RatingRepository = new RatingRepository(context);
        }

        /// <inheritdoc />
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
