using IQA_RecordingApplication.Contracts;
using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Repository
{
    public class ErrorMessageRepository : IErrorMessage
    {
        private readonly ApplicationDbContext _db;

        public ErrorMessageRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public bool Create(ErrorMessage entity)
        {
            _db.ErrorMessages.Add(entity);
            return Save();
        }

        public bool CreatErrorTracker(ErrorMessageTrack entity)
        {
            _db.ErrorMessageTracks.Add(entity);
            return Save();
        }

        public bool Delete(ErrorMessage entity)
        {
            _db.ErrorMessages.Remove(entity);
            return Save();
        }

        public ErrorMessage Find(int Id)
        {
            return _db.ErrorMessages.Find(Id);
        }

        public ICollection<ErrorMessage> FindAll()
        {
            return _db.ErrorMessages.ToList();

        }

        public int FindLatestId()
        {
            return _db.ErrorMessages.Max(q => q.ErrorMessageId);
        }

        public ICollection<ErrorMessage> FindProductTypes()
        {
            throw new NotImplementedException();
        }

        public List<ErrorMessage> GetErrorMessage(int productId)
        {
            List<ErrorMessage> localList = new List<ErrorMessage>();
            var product = _db.Products.Where(a => a.ProductId == productId).FirstOrDefault();
            if (product != null)
            {

                var products = _db.Products
                    .Where(q => q.ProductName.ToLower() == product.ProductName.ToLower()).Select(e => e.ProductId);
                foreach (var item in products)
                {
                    var errormessage = _db.ErrorMessageTracks.Where(q => q.ProductId == item).Select(e => e.ErrorMessage);
                    foreach (var msg in errormessage)
                    {
                        if (!localList.Select(q => q.ErrorMessageId).Contains(msg.ErrorMessageId))
                        {

                            localList.Add(msg);
                        }
                    }
                }

            }
            return localList;
        }

        public bool IsExists(int Id)
        {
            var exists = _db.ErrorMessages.Any(q => q.ErrorMessageId == Id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(ErrorMessage entity)
        {
            _db.ErrorMessages.Update(entity);
            return Save();
        }
    }
}
