using GraphQL_POC.Models;

namespace GraphQL_POC.Infrastructure.Repositories.Interfaces;

public interface IPatientRepository
{
    List<Patient> GetPatients();
    Patient CreatePatient(string firstName);
}