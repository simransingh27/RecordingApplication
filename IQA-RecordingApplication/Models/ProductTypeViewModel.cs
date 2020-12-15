using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Models
{
    public class ProductTypeViewModel
    {
        [Key]
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
