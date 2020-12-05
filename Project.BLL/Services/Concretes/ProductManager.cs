using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services.Concretes
{
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        public ProductManager(IRepository<Product> prp) : base(prp)
        {

        }
    }
}
