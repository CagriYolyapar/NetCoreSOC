using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public string RepTest(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
            return "Triumph!!!";
        }
    }
}
