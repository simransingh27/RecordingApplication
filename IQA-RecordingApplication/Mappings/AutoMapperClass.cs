using AutoMapper;
using IQA_RecordingApplication.Data;
using IQA_RecordingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Mappings
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductType, ProductTypeViewModel>().ReverseMap();
            CreateMap<ErrorMessage, CreateErrorMessageViewModel>().ReverseMap();
            CreateMap<ErrorMessage, DisplayErrorMessageViewModel>().ReverseMap();
            CreateMap<CustomerCode1, DetailsCustomerCodeViewModel>().ReverseMap();
            CreateMap<CustomerCode1, CreateCustomerCodeViewModel>().ReverseMap();
            CreateMap<SKUCode1, SKUCodeViewModel>().ReverseMap();
            CreateMap<ErrorMessageTrack, ErrorMessageTrackViewModel>().ReverseMap();
        }
    }
}
