using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Models
{
    public class CreateCustomerCodeViewModel
    {
        [Key]
        public int CustomerCodeId { get; set; }
        [Required]
        public String CustomerCodeName { get; set; }
        public String CustomerCodeDescription { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int ProductId { get; set; }
    }

    public class DetailsCustomerCodeViewModel
    {
        [Key]
        public int CustomerCodeId { get; set; }
        [Required]
        public String CustomerCode { get; set; }
        public String CustomerCodeDescription { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
