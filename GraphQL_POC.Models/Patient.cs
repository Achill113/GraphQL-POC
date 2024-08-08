using GraphQL.Types;

namespace GraphQL_POC.Models;

public class Patient
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
}

public sealed class PatientType : ObjectGraphType<Patient>
{
  public PatientType()
  {
    Field(x => x.Id).Description("The Id of the Patient.");
    Field(x => x.FirstName).Description("The first name of the Patient.");
  }
}