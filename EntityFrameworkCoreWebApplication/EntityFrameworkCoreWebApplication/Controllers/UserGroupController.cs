using EntityFrameworkCoreWebApplication.DbContexts;
using EntityFrameworkCoreWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreWebApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserGroupController : ControllerBase
	{
        private MyDbContext myDbContext;

        public UserGroupController(MyDbContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<UserGroup> Get()
        {
            return (this.myDbContext.UserGroups.ToList());
        }
    }
}
