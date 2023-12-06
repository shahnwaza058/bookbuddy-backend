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
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;   
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);   
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUserName(userName);   
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public User  Update(User user)
        {
            User updatedUser=_userRepository.Update(user);
            _unitOfWork.SaveChanges().Wait();
            return updatedUser;
        }

    }
}
