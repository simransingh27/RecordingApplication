using Microsoft.AspNetCore.Mvc.Rendering;
using IQA_RecordingApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Models
{
    public class CreateErrorMessageViewModel
    {
        [Key]
        public int ErrorMessageId { get; set; }

        [Required]
        public String Message { get; set; }

        public int ProductId { get; set; }
        public List<ErrorMessageCheckBox> ErrorMessageCheckBoxes { get; set; }
    }

    public class EditErrorMessageViewModel
    {
        public String Message { get; set; }
        public ErrorMessageTrackViewModel ErrorMessageTrack { get; set; }
        public IEnumerable<SelectListItem> ErrorMessagTracks { get; set; }
    }

    public class DisplayErrorMessageViewModel
    {
        public String Message { get; set; }
        public ErrorMessageTrackViewModel ErrorMessageTrack { get; set; }
    }

    public class DeleteErrorMessageViewModel {

        public int ErrorMessageId { get; set; }
        public String Message { get; set; }
        public ErrorMessageTrackViewModel ErrorMessageTrack { get; set; }
        public IEnumerable<SelectListItem> ErrorTrackIds { get; set; }
        public IEnumerable<SelectListItem> ErrorTextMessages { get; set; }
        public int MyProperty { get; set; }
    }

    public class ErrorMessageCheckBox{

        public bool IsChecked { get; set; }
        public string  Text { get; set; }

        public int ErrorMessageId { get; set; }


    }
}
