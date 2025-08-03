using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "student_data.txt";
        string outputFilePath = "student_report.txt";

        // e. i. Wrap the entire process in a try-catch block
        try
        {
            Console.WriteLine("Starting student result processing...");
            
            var processor = new StudentResultProcessor();
            
            // e. ii. Call ReadStudentsFromFile
            List<Student> students = processor.ReadStudentsFromFile(inputFilePath);

            Console.WriteLine($"Successfully read {students.Count} student records.");

            // e. iii. Call WriteReportToFile
            processor.WriteReportToFile(students, outputFilePath);

            Console.WriteLine($"Report successfully written to '{outputFilePath}'.");
        }
        // e. iv. Catch and display the following exceptions
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The input file '{inputFilePath}' was not found. Please create the file and try again.");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"Data Error: {ex.Message}");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"Data Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}