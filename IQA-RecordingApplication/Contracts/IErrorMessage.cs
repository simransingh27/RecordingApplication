using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Contracts
{
  public  interface IErrorMessage: IRepositoryBase<ErrorMessage>
    {
        public bool CreatErrorTracker(ErrorMessageTrack emt);
        public List<ErrorMessage> GetErrorMessage(int ProductId);
       public int FindLatestId();
    }
}
