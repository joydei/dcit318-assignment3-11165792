using System;

class Program
{
    static void Main(string[] args)
    {
        // i. Instantiate HealthSystemApp
        var app = new HealthSystemApp();

        // ii. Call SeedData()
        app.SeedData();

        // iii. Call BuildPrescriptionMap()
        app.BuildPrescriptionMap();

        // iv. Print all patients
        app.PrintAllPatients();

        // v. Select one PatientId and display all prescriptions
        app.PrintPrescriptionsForPatient(101); // John Doe
        app.PrintPrescriptionsForPatient(102); // Jane Smith
        app.PrintPrescriptionsForPatient(999); // Invalid ID for demonstration
    }
}