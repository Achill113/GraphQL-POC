using System.Reflection;
using GraphQL_POC.Infrastructure.Repositories.Interfaces;
using GraphQL_POC.Models;
using Microsoft.Data.Sqlite;

namespace GraphQL_POC.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    public List<Patient> GetPatients()
    {
        using var connection = GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT id, first_name
            FROM patients;
        ";

        using var reader = command.ExecuteReader();

        var patients = new List<Patient>();

        while (reader.Read())
        {
            var patient = new Patient
            {
                Id = reader.GetGuid(0),
                FirstName = reader.GetString(1)
            };

            patients.Add(patient);
        }

        return patients;
    }

    public Patient CreatePatient(string firstName)
    {
        using var connection = GetConnection();
        connection.Open();

        var command = connection.CreateCommand();

        var id = Guid.NewGuid();

        command.CommandText = $"""
                                   INSERT INTO patients
                                   VALUES ('{id.ToString()}', '{firstName}');
                               """;

        command.ExecuteNonQuery();

        command.CommandText = $"""
                               SELECT *
                               FROM patients
                               WHERE id = '{id.ToString()}'
                               LIMIT 1
                               """;
        using var reader = command.ExecuteReader();

        Patient? patient = null;

        while (reader.Read())
        {
            patient = new Patient
            {
                Id = reader.GetGuid(0),
                FirstName = reader.GetString(1)
            };
        }

        if (patient is null)
        {
            throw new ApplicationException("Failed to create patient.");
        }

        return patient;
    }

    private SqliteConnection GetConnection()
    {
        var currentLocation = Assembly.GetExecutingAssembly().Location;
        var currentDirectory = Path.GetDirectoryName(currentLocation);
        return new SqliteConnection($"Data Source={currentDirectory}/poc.db");
    }
}