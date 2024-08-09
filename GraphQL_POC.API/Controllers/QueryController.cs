using GraphQL_POC.Infrastructure.Repositories.Interfaces;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_POC.Controllers;

[ApiController]
[Route("api/graphql/query")]
public class QueryController(DefaultQuery defaultQuery) : ControllerBase
{
    /// <summary>
    /// Queries the GraphQL API.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<string> Query(string query)
    {
        var schema = new Schema { Query = defaultQuery };

        var json = await schema.ExecuteAsync(_ => { _.Query = query; });

        return json;
    }
}