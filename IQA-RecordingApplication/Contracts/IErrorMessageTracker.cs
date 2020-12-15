using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Contracts
{
    interface IErrorMessageTracker : IRepositoryBase<ErrorMessageTrack>
    {
    }
}
