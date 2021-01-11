using GraphQLWebApplication.DbContexts;
using GraphQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebApplication.GraphQL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GraphQLTestContext _context;
        public EmployeeRepository(GraphQLTestContext context)
        {
            _context = context;
        }

        public Task<List<Employee>> GetEmployees()
        {
            return _context.Employees.ToListAsync();
        }
    }
}
