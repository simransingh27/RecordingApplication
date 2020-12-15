using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Models
{
    public class ErrorMessageTrackViewModel
    {
        public int ErrorMessageTrackId { get; set; }

        public CreateCustomerCodeViewModel CustomerCode { get; set; }
        public string CustomerCodeId { get; set; }

       
        public ProductTypeViewModel ProductType { get; set; }
        public int? ProductTypeId { get; set; }

      
        public SKUCodeViewModel SKUCode { get; set; }
        public String SKUCodeId { get; set; }

       
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
