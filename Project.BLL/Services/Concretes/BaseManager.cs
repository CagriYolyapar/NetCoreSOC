using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services.Concretes
{
    //Burayı abstract yaparsan serviste DI kuramazsın aklında olsun!! Ya burayı hic Abstract yapma ya da servis konfigurasyonuna koyma!!!
    public  class BaseManager<T> : IManager<T> where T: BaseEntity
    {
        IRepository<T> _irp;
        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }
        public void IntTest(T item)
        {
            _irp.RepTest(item);
        }
    }
}
