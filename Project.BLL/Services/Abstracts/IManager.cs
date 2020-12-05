using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services.Abstracts
{
    public interface IManager<T> where T:BaseEntity
    {
        void IntTest(T item);
    }
}
