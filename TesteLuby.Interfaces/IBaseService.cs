using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Interfaces
{
    public interface IBaseService<T>
    {
        T Get(int id);
        bool Insert(T dto);
        bool Update(T dto, int id);
        bool Delete(int id);
    }
}
