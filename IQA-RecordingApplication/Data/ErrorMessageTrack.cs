using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Data
{
    public class ErrorMessageTrack
    {
        [Key]
        public int ErrorMessageTrackId { get; set; }
       
   
    
        [ForeignKey("ErrorMessageId")]
        public ErrorMessage ErrorMessage { get; set; }
        public int ErrorMessageId { get; set; }
            
       
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        


    }
}
