using GraphQLWebApplication.DbContexts;
using GraphQLWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebApplication.GraphQL
{
    public interface IEmployeeRepository
    {
        //IEmployeeRepository(GraphQLTestContext);

        Task<List<Employee>> GetEmployees();
    }
}
