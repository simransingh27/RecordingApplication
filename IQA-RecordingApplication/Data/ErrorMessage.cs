using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Data
{
    public class ErrorMessage
    {
        [Key]
        public int ErrorMessageId { get; set; }
        public String Message { get; set; }

        //[ForeignKey("ErrorMessageTrackId")]
        //public ErrorMessageTrack ErrorMessageTrack { get; set; }
        //public int ErrorMessageTrackId { get; set; }

    }
}
