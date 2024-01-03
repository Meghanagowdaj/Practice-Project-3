using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve_student_data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "E:\\Practice project 3\\data.txt";
            List<Student> students = ReadStudentData(filePath);

            var sortedStudents = students.OrderBy(s => s.Name, StringComparer.OrdinalIgnoreCase).ToList();

            Console.WriteLine("Sorted Student Data:");
            DisplayStudents(sortedStudents);

            Console.Write("\nEnter a student name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(sortedStudents, searchName);
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0].Trim();
                        string studentClass = parts[1].Trim();
                        students.Add(new Student(name, studentClass));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found. Make sure to provide the correct file path.");
            }
            return students;
        }

        static void DisplayStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.StudentClass}");
            }
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"\nStudent found: {foundStudent.Name}, {foundStudent.StudentClass}");
            }
            else
            {
                Console.WriteLine("\nStudent not found.");
            }
        }
    }
    class Student
    {
        public string Name { get; }
        public string StudentClass { get; }
        public Student(string name, string studentClass)
        {
            Name = name;
            StudentClass = studentClass;
        }
    }
}


