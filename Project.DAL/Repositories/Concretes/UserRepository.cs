using Microsoft.AspNetCore.Identity;
using Project.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class UserRepository:IUserRepository
    {
        UserManager<IdentityUser> _ium;

        public UserRepository(UserManager<IdentityUser> ium)
        {
            _ium = ium;
        }

        public async Task UserTest(IdentityUser item)
        {
             await _ium.CreateAsync(item, item.PasswordHash);   
        }
    }
}
