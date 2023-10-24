using System;
using System.Collections.Generic;

class Program
{

    static List<Student> students = new List<Student>();
    static List<Instructor> instructors = new List<Instructor>();
    static List<Course> courses = new List<Course>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("| Student Management System Menu:     |");
            Console.WriteLine("| 1. Display Database                 |");
            Console.WriteLine("| 2. Add Student                      |");
            Console.WriteLine("| 3. Add Instructor                   |");
            Console.WriteLine("| 4. Add Course                       |");
            Console.WriteLine("| 5. Enroll Student in Course         |");
            Console.WriteLine("| 6. Edit Information of object       |");
            Console.WriteLine("| 7. Display Object Information by ID |");
            Console.WriteLine("| 8. Exit                             |");
            Console.WriteLine("+-------------------------------------+");
            Console.Write("> Enter your choice: ");            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    displayDatabase();
                    break;
                case "2":
                    Student newStudent = Student.CreateStudent();
                    students.Add(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;

                case "3":
                    Instructor newInstructor = Instructor.CreateInstructor();
                    instructors.Add(newInstructor);
                    Console.WriteLine("Instructor added successfully.");
                    break;

                case "4":
                    Console.Write("Enter course name: ");
                    string courseName = Console.ReadLine();                                        
                    bool check = true;
                    Instructor newInstructor1 = null;
                    while (check == true )
                    {
                        Console.WriteLine("--Insert instructor--");
                        Console.WriteLine("1. Add new instructor.");
                        Console.WriteLine("2. Add available instructor.");
                        Console.WriteLine("3. Add later.");
                        Console.Write("Your choice: ");
                        string choice1 = Console.ReadLine();
                        switch (choice1)
                        {
                            case "1":
                                newInstructor1 = Instructor.CreateInstructor();
                                check = false;
                                break;
                            case "2":
                                Console.Write("Enter Instructor ID: ");
                                int id;
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for the Instructor ID.");
                                }
                                newInstructor1 = instructors.Find(i => i.Id == id);
                                check = false;
                                break;
                            case "3":
                                newInstructor1 = null;
                                check = false;
                                break;                                
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                        Console.WriteLine("Course added successfully.");                        
                    }
                    instructors.Add(newInstructor1);
                    Course newCourse = Course.CreateCourse(courseName, newInstructor1);
                    courses.Add(newCourse);
                    break;
                case "5":
                    EnrollStudentInCourse();
                    break;

                case "6":
                    DisplayObjectInformationByID();
                    break;

                case "7":
                    Console.WriteLine("Exiting the program");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void EnrollStudentInCourse()
    {
        Console.Write("Enter Student ID: ");
        int studentID;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out studentID))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the student ID.");
            }
        }

        Student student = students.Find(s => s.Id == studentID);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter Course ID: ");
        int courseID;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out courseID))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the course ID.");
            }
        }

        Course course = courses.Find(c => c.CourseID == courseID);

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        student.EnrollInCourse(course);

    }


    static void DisplayObjectInformationByID()
    {
        Console.Write("Enter Object Type (Student/Instructor/Course): ");
        string objectType = Console.ReadLine();

        Console.Write("Enter Object ID: ");
        int objectID;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out objectID))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the object ID.");
            }
        }

        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student student = students.Find(s => s.Id == objectID);
            if (student != null)
            {
                Console.WriteLine("Student Information:");
                student.DisplayInfo();
                student.ViewCourses();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor instructor = instructors.Find(i => i.Id == objectID);
            if (instructor != null)
            {
                Console.WriteLine("Instructor Information:");
                instructor.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Instructor not found.");
            }
        }
        else if (objectType.Equals("Course", StringComparison.OrdinalIgnoreCase))
        {
            Course course = courses.Find(c => c.CourseID == objectID);
            if (course != null)
            {
                course.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid object type.");
        }
    }

    static void EditInformationByID()
    {
        Console.Write("Enter Object Type (Student/Instructor/Course): ");
        string objectType = Console.ReadLine();

        Console.Write("Enter Object ID: ");
        int objectID;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out objectID))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the object ID.");
            }
        }

        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student student = students.Find(s => s.Id == objectID);
            if (student != null)
            {
                Console.WriteLine("Student Information:");
                student.DisplayInfo();
                student.ViewCourses();
                int index = students.IndexOf(student);
                if (index >= 0) 
                {
                    students[index] = student;
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor instructor = instructors.Find(i => i.Id == objectID);
            if (instructor != null)
            {
                Console.WriteLine("Instructor Information:");
                instructor.DisplayInfo();
                int index = instructors.IndexOf(instructor);
                if (index >= 0)
                {
                    instructors[index] = instructor;
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Instructor not found.");
            }
        }
        else if (objectType.Equals("Course", StringComparison.OrdinalIgnoreCase))
        {
            Course course = courses.Find(c => c.CourseID == objectID);
            if (course != null)
            {
                course.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid object type.");
        }
    }

    static void displayDatabase()
    {
        Console.WriteLine("Instructors:");
        foreach (Instructor i in instructors)
        {
            Console.WriteLine($"ID: {i.Id}, Name: {i.Name}");
        }
        Console.WriteLine("Students: ");
        foreach (Student s in students)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
        }
        Console.WriteLine("Couses: ");
        foreach (Course c in courses)
        {
            Console.WriteLine($"ID: {c.CourseID}, Name: {c.CourseName}");
        }
    }
}
