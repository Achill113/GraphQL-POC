using GraphQL;
using GraphQL_POC.Models;
using GraphQL.Types;

namespace GraphQL_POC;

public class Query : ObjectGraphType
{
    public Query()
    {
        Field<PatientType>("patient")
            .Resolve(context => new Patient { Id = Guid.NewGuid(), FirstName = "Neil" });
    }
}
