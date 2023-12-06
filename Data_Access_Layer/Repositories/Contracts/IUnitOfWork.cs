using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IBookRepository BookRepository { get; }

        IRatingRepository RatingRepository { get; }

        Task<int> SaveChanges();
    }
}
