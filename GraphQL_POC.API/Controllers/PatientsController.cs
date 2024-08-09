using GraphQL_POC.DTOs;
using GraphQL_POC.Infrastructure.Repositories.Interfaces;
using GraphQL_POC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_POC.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController(IPatientRepository patientRepository) : ControllerBase
{
    [HttpPost]
    public Patient CreatePatient([FromBody] CreatePatientRequest request)
    {
        return patientRepository.CreatePatient(request.FirstName);
    }
}