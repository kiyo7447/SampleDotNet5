using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLWebApplication.GraphQL
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: context => employeeRepository.GetEmployees()
                );
        }
    }
}
