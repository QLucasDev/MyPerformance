using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataBase;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyContext _myContext) : base(_myContext)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string encryptedPassword)
        {
            return await FindByCondition(a => a.Email.Equals(email) && a.Password.Equals(encryptedPassword)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await FindByCondition(a => a.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await FindAll().ToListAsync();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}