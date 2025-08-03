using System;
using System.Collections.Generic;
using System.Linq;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
        // Add Patient objects
        _patientRepo.Add(new Patient(101, "Joy Dei", 45, "Male"));
        _patientRepo.Add(new Patient(102, "Paulina Boakywaa", 32, "Female"));
        _patientRepo.Add(new Patient(103, "Don Quixote", 68, "Male"));

        // Add Prescription objects
        _prescriptionRepo.Add(new Prescription(1, 101, "Metformin", DateTime.Now.AddDays(-10)));
        _prescriptionRepo.Add(new Prescription(2, 102, "Lisinopril", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(3, 101, "Amoxicillin", DateTime.Now.AddDays(-2)));
        _prescriptionRepo.Add(new Prescription(4, 103, "Ibuprofen", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(5, 102, "Atorvastatin", DateTime.Now.AddDays(-1)));
    }

    public void BuildPrescriptionMap()
    {
        var allPrescriptions = _prescriptionRepo.GetAll();

        // Use LINQ's GroupBy and ToDictionary to efficiently build the map
        _prescriptionMap = allPrescriptions.GroupBy(p => p.PatientId)
                                           .ToDictionary(g => g.Key, g => g.ToList());
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("--- All Patients ---");
        var patients = _patientRepo.GetAll();
        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
        }
        Console.WriteLine();
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        Console.WriteLine($"--- Prescriptions for Patient ID: {patientId} ---");
        if (_prescriptionMap.ContainsKey(patientId))
        {
            var prescriptions = _prescriptionMap[patientId];
            if (prescriptions.Count > 0)
            {
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine($"  Prescription ID: {prescription.Id}, Medication: {prescription.MedicationName}, Date: {prescription.DateIssued.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("  No prescriptions found.");
            }
        }
        else
        {
            Console.WriteLine("  Patient ID not found in the prescription map.");
        }
        Console.WriteLine();
    }
}