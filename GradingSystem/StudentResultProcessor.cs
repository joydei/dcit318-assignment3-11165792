using System;
using System.Collections.Generic;
using System.IO;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        List<Student> students = new List<Student>();
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            string? line;
            int lineNumber = 0;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                
                // Skip empty lines and comment lines
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//"))
                {
                    continue;
                }

                string[] fields = line.Split(',');

                // ii. Validate the number of fields
                if (fields.Length != 3)
                {
                    throw new MissingFieldException($"Line {lineNumber}: Incomplete record found: '{line}'. Expected 3 fields, but found {fields.Length}.");
                }

                // iii. Try converting the score to an integer
                int id;
                string fullName = fields[1].Trim();
                int score;

                // Validate and parse ID (optional, but good practice)
                if (!int.TryParse(fields[0].Trim(), out id))
                {
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format found in record: '{line}'.");
                }

                // iv. If parsing fails, throw InvalidScoreFormatException
                if (!int.TryParse(fields[2].Trim(), out score))
                {
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format found in record: '{line}'.");
                }

                // Handle invalid scores (e.g., negative or above 100)
                if (score < 0 || score > 100)
                {
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Score '{score}' is out of the valid range (0-100) in record: '{line}'.");
                }

                // Add valid student to the list
                students.Add(new Student(id, fullName, score));
            }
        }
        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
            }
        }
    }
}