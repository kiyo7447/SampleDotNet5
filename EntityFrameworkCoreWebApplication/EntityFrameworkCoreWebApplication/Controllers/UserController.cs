using EntityFrameworkCoreWebApplication.DbContexts;
using EntityFrameworkCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
	{
        private MyDbContext myDbContext;

        public UserController(MyDbContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<User> Get()
        {
            return (this.myDbContext.Users.ToList());
        }
    }
}
