using Microsoft.AspNetCore.Identity;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Concretes
{
    public class UserManagerSpecial : IUserManagerSpecial
    {
        IUserRepository _irp;
        public UserManagerSpecial(IUserRepository irp)
        {
            _irp = irp;
        }
        public async Task TestUser(IdentityUser item)
        {
           await _irp.UserTest(item);
        }
    }
}
