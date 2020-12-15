using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQA_RecordingApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<CustomerCode1> CustomerCodes { get; set; }
        public DbSet<ErrorMessage> ErrorMessages { get; set; }
        public DbSet<ErrorMessageTrack> ErrorMessageTracks { get; set; }
        public DbSet<Product> Products { get; set; }
      //  public DbSet<SKUCode1> SKUCodes { get; set; }
        //public DbSet<IQA_RecordingApplication.Models.SKUCodeViewModel> SKUCodeViewModel { get; set; }



    }
}
