using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Contracts
{
   public interface ISKUCode : IRepositoryBase<SKUCode1>
    {
        public bool IsExitsSKU(String Id);
        public bool FindById(String Id);
    }
}
