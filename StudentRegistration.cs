using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace _1004_Assignment_Project
{
    public class StudentRegistration
    {
        public static void Start(string filePath)
        {
            //JSONSerializer(filePath);
            JSONDeserializer(filePath);
        }

        public static void JSONDeserializer(string filePath)
        {

            if (File.Exists(filePath))
            {
                
               
                using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    List<Student> stud1 = JsonSerializer.Deserialize<List<Student>>(content)!;
                    foreach (var emp in stud1)
                    {
                        Console.WriteLine($"ID: {emp.ID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}, DateOfBirth: {emp.DateOfBirth}, Email: {emp.Email} Address:{emp.Address} ");
                    }

                    // string content = File.ReadAllText(filePath);
                    //List<Student> stud1 = JsonSerializer.Deserialize<List<Student>>(content)!;
                    //Student stud1 = JsonSerializer.Deserialize<Student>(jsonstring)!;
                    //Console.WriteLine($"ID: {stud1.ID}, FirstName: {stud1.FirstName}, LastName: {stud1.LastName}, DateOfBirth: {stud1.DateOfBirth}, Email: {stud1.Email} Address:{stud1.Address} ");


                }

            }
        }
        
        public static void JSONSerializer(string filePath)
        {
                List<Student> Student = new List<Student>();




                Student stud1 = new Student();
                Console.WriteLine("please enter your StudentID: ");
                stud1.ID = Convert.ToInt32((Console.ReadLine()));
                Console.WriteLine("please enter your First name: ");
                stud1.FirstName = Console.ReadLine();
                Console.WriteLine("please enter your Last name: ");
                stud1.LastName = Console.ReadLine();
                Console.Write("Enter your date of birth (e.g. 10/22/1987): ");
                stud1.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("please enter your Email: ");
                stud1.Email = Console.ReadLine();
                Console.WriteLine("please enter your Address: ");
                stud1.Address = Console.ReadLine();
                Console.WriteLine("Thank you! ");

                Student.Add(stud1);


                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Student, options);

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(jsonString);
                }
            

        }
        
    }
}




