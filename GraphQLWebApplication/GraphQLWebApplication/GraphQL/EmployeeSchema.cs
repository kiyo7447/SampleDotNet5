using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace GraphQLWebApplication.GraphQL
{
    public class EmployeeSchema : Schema
    {
		//実施できなかった
		//https://www.c-sharpcorner.com/article/graphql-in-net-core-web-api-with-entity-framework-core-part-one/
		//public EmployeeSchema(IDependencyResolver resolver) : base(resolver)
		//{
		//	Query = resolver.Resolve<EmployeeQuery>();
		//}

		//V2->V3
		//https://graphql-dotnet.github.io/docs/migrations/migration3/

		//GraphQL.NET
		//https://graphql-dotnet.github.io/docs/getting-started/dependency-injection/
		public EmployeeSchema(IServiceProvider provider): base(provider)
		{
			Query = Query = provider.GetRequiredService<EmployeeQuery>();
		}
	}
}
