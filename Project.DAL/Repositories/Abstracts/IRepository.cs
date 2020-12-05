using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T:BaseEntity
    {
        string RepTest(T item);
    }
}
