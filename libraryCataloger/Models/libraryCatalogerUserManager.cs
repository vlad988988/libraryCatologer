using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace libraryCataloger.Models
{
    public class libraryCatalogerUserManager : UserManager<libraryCatalogerUser>
    {
        public libraryCatalogerUserManager(IUserStore<libraryCatalogerUser> store)
            : base(store)
        {
        }
        public static libraryCatalogerUserManager Create(IdentityFactoryOptions<libraryCatalogerUserManager> options,
                                                IOwinContext context)
        {
            libraryCatalogerContext db = context.Get<libraryCatalogerContext>();
            libraryCatalogerUserManager manager = new libraryCatalogerUserManager(new UserStore<libraryCatalogerUser>(db));
            return manager;
        }
    }
}