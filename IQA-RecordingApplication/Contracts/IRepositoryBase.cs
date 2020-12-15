using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Contracts
{
    public interface IRepositoryBase <T> where T: class
    {
        ICollection<T> FindAll();
        T Find(int Id);

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool IsExists(int Id);
        bool Save();

       



    }
}
