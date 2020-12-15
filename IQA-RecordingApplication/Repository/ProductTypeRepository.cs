using IQA_RecordingApplication.Contracts;
using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Repository
{
    public class ProductTypeRepository : IProductType 
    {
        private readonly ApplicationDbContext _db;

        public ProductTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(ProductType entity)
        {
            _db.ProductTypes.Add(entity);
            return Save();
        }

        public bool Delete(ProductType entity)
        {
             _db.ProductTypes.Remove(entity);
            return Save();
        }

        public ProductType Find(int Id)
        {
            return _db.ProductTypes.Find(Id);
        }

        public ICollection<ProductType> FindAll()
        {
            return _db.ProductTypes.ToList();
        }


        public bool IsExists(int Id)
        {
            var exists = _db.ProductTypes.Any(q => q.ProductTypeId == Id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(ProductType entity)
        {
            _db.ProductTypes.Update(entity);
            return Save();
        }
    }
}
