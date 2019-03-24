using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace libraryCataloger.Models
{
    public class libraryCatalogerContext : IdentityDbContext<libraryCatalogerUser>
    {   
        public libraryCatalogerContext() : base("name=libraryCatalogerContext")
        {
        }

        public System.Data.Entity.DbSet<libraryCataloger.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<libraryCataloger.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<libraryCataloger.Models.BorrowHistory> BorrowHistories { get; set; }

        //public System.Data.Entity.DbSet<libraryCataloger.Models.RegisterModel> RegisterModels { get; set; }

        public static libraryCatalogerContext Create()
        {
            return new libraryCatalogerContext();
        }
    }
}
