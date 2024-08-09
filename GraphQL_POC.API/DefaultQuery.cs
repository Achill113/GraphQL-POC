using GraphQL_POC.Infrastructure.Repositories.Interfaces;
using GraphQL_POC.Models;
using GraphQL.Types;

namespace GraphQL_POC;

public class DefaultQuery : ObjectGraphType
{
    public DefaultQuery(IPatientRepository patientRepository)
    {
        Field<ListGraphType<PatientType>>("patients")
            .Resolve(context => patientRepository.GetPatients());
    }
}
