using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RainbowSchoolPage_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = ReadStudentData(@"C:\\Users\\vpava.DESKTOP-U064AL2\\OneDrive\\Desktop\\Simplilearn\\AssistedPractice\\PracticeSubmited\\PracticeProblem_3\\students.txt");

           
            students = students.OrderBy(s => s.Name).ToList();

           
            Console.WriteLine("Sorted Student Data:");
            DisplayStudentData(students);

            
            Console.Write("\nEnter student name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(students, searchName);
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> studentList = new List<Student>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');

                    Student student = new Student
                    {
                        Name = data[0].Trim(),
                        Class = data[1].Trim()
                    };

                    studentList.Add(student);
                }
            }

            return studentList;
        }

        static void DisplayStudentData(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"Student found: {foundStudent}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}