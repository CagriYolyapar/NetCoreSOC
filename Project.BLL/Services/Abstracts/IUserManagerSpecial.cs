using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
    public interface IUserManagerSpecial
    {
        Task TestUser(IdentityUser item);
    }
}
