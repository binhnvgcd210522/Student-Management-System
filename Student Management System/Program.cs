using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();
    static List<Instructor> instructors = new List<Instructor>();
    static List<Course> courses = new List<Course>();
    
    static void Main()
    {
        Student student1= new Student(100, "Khiem", "555-777");
        Student student2= new Student(101, "An", "932-231");
        Student student3= new Student(102, "Hoang", "394-111");
        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        Instructor instructor1 = new Instructor(100, "Teacher 1", "123-111");
        Instructor instructor2 = new Instructor(101, "Teacher 2", "292-112");
        Instructor instructor3 = new Instructor(102, "Teacher 3", "492-192");
        instructors.Add(instructor1);
        instructors.Add(instructor2);
        instructors.Add(instructor3);
        Course course1 = new Course(100, "Python", instructor1);
        Course course2 = new Course(101, "Advance programing", instructor3);
        Course course3 = new Course(102, "Cloud computing", instructor1);
        instructor1.InsertCourseTaught(course1);
        instructor1.InsertCourseTaught(course3);
        courses.Add(course1);
        courses.Add(course2);
        courses.Add(course3);

        while (true)
        {
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("| Student Management System Menu:     |");
            Console.WriteLine("| 1. Display Database                 |");
            Console.WriteLine("| 2. Add Object                       |");
            Console.WriteLine("| 3. Edit Information of object       |");
            Console.WriteLine("| 4. Delete Object by ID              |");            
            Console.WriteLine("| 5. Enroll Student in courses        |");
            Console.WriteLine("| 6. Display Object Information by ID |");
            Console.WriteLine("| 7. Exit                             |");
            Console.WriteLine("+-------------------------------------+");
            Console.Write("> Enter your choice: ");            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    DisplayDatabase();
                    break;
                case "2":
                    AddObjectInformationByID();
                    break;
                case "3":                    
                    EditInformationByID();
                    break;
                case "4":
                    DeleteObjectByID();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for the student ID.");
                Console.ResetColor();
                Console.Write("Enter student ID: ");
            }
        }

        Student student = students.Find(s => s.Id == studentID);

        if (student == null)
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student not found.");
            Console.ResetColor();
            return;
        }

        Console.Write("Enter course ID: ");
        int courseID;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out courseID))
            {
                break;
            }
            else
            {                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for the course ID.");
                Console.ResetColor();
                Console.Write("Enter courses ID: ");
            }
        }

        Course course = courses.Find(c => c.CourseID == courseID);

        if (course == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Course not found.");
            Console.ResetColor();            
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for the object ID.");
                Console.ResetColor();
                Console.WriteLine("Enter Object ID again: ");
            }
        }

        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student student = students.Find(s => s.Id == objectID);
            if (student != null)
            {
                Console.WriteLine("Student Information:");
                student.DisplayInfor();
                student.ViewCourses();
            }
            else
            {               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.");
                Console.ResetColor();
            }
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor instructor = instructors.Find(i => i.Id == objectID);
            if (instructor != null)
            {
                Console.WriteLine("Instructor Information:");
                instructor.DisplayInfor();
            }
            else
            {                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Instructor not found.");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Course not found.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid object type.");
            Console.ResetColor();            
        }
    }

    static void AddObjectInformationByID()
    {
        Console.Write("Enter Object Type (Student/Instructor/Course): ");
        string objectType = Console.ReadLine();       
        
        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student newStudent = Student.CreateStudent();
            students.Add(newStudent);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Student added successfully.");
            Console.ResetColor();
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor Instructor = Instructor.CreateInstructor();
            instructors.Add(Instructor);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Instructor added successfully.");
            Console.ResetColor();
        }
        else if (objectType.Equals("Course", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter course name: ");
            string courseName = Console.ReadLine();
            Instructor newInstructor = GetInstructor();
            Course newCourse = Course.CreateCourse(courseName, newInstructor);
            int check = instructors.IndexOf(newInstructor);
            if ((check == -1) && (newInstructor !=null))
            {
                instructors.Add(newInstructor);
                newInstructor.InsertCourseTaught(newCourse);
            }                        
            courses.Add(newCourse);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Course added successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid object type.");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for the object ID.");
                Console.ResetColor();                
            }
        }

        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student student = students.Find(s => s.Id == objectID);
            if (student != null)
            {
                Console.WriteLine("Student Information:");
                student.DisplayInfor();                
                Student newStudent = student.Edit();                
                int index = students.IndexOf(student);
                student = students.Find(s => s.Id == newStudent.Id);
                if ((student != null ) && (newStudent.Id != student.Id))
                {                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Student ID already exist");
                    Console.ResetColor();
                }
                else if (index >= 0) 
                {
                    students[index] = newStudent;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Student is edited.");
                    Console.ResetColor();
                }                
            }
            else
            {                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.");
                Console.ResetColor();
            }
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor instructor = instructors.Find(i => i.Id == objectID);
            if (instructor != null)
            {
                Console.WriteLine("Instructor Information:");
                instructor.DisplayInfor();
                Instructor newInstructor = instructor.Edit();
                int index = instructors.IndexOf(instructor);
                instructor = instructors.Find(s => s.Id == newInstructor.Id);
                if ((instructor != null) && (newInstructor.Id != instructor.Id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Instructor ID already exist");
                    Console.ResetColor();
                }
                if (index >= 0)
                {
                    instructors[index] = newInstructor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Instructor is edited.");
                    Console.ResetColor();
                }                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Instructor not found.");
                Console.ResetColor();
            }
        }
        else if (objectType.Equals("Course", StringComparison.OrdinalIgnoreCase))
        {
            Course course = courses.Find(c => c.CourseID == objectID);
            if (course != null)
            {
                course.DisplayInfo();
                Console.WriteLine("--Edit course information--");
                Console.Write("New ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("New Name: ");
                string name = Console.ReadLine();
                Instructor newInstructor = GetInstructor();
                int check = instructors.IndexOf(newInstructor);
                if (check == -1)
                {
                    instructors.Add(newInstructor);
                }
                Course newCourse = new Course(id, name, newInstructor);
                int index = courses.IndexOf(course);
                course = courses.Find(c => c.CourseID == newCourse.CourseID);                
                if ((course != null) && (newCourse.CourseID != course.CourseID))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Course ID already exist");
                    Console.ResetColor();
                }
                else if ((index >= 0))
                {
                    courses[index] = newCourse;
                    if (newInstructor != null)
                    {                        
                        newInstructor.InsertCourseTaught(newCourse);
                        newInstructor.Remove(course);
                    }                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Course is edited.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("courses not found.");
                Console.ResetColor();                
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid object type.");
            Console.ResetColor();
        }
    }

    static void DeleteObjectByID()
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer for the object ID.");
                Console.ResetColor();
                Console.Write("Enter Object ID again: ");
            }
        }

        if (objectType.Equals("Student", StringComparison.OrdinalIgnoreCase))
        {
            Student student = students.Find(s => s.Id == objectID);
            if (student != null)
            {
                foreach (Course course in student.Courses)
                {
                    course.Remove(student);
                }
                students.Remove(student);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Student is deleted");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.");
                Console.ResetColor();
            }
        }
        else if (objectType.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
        {
            Instructor instructor = instructors.Find(i => i.Id == objectID);
            if (instructor != null)
            {
                foreach (Course course in instructor.coursesTaught)
                {
                    course.Remove(instructor);
                }
                instructors.Remove(instructor);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Instructor is deleted");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Instructor not found.");
                Console.ResetColor();
            }
        }
        else if (objectType.Equals("Course", StringComparison.OrdinalIgnoreCase))
        {
            Course course = courses.Find(c => c.CourseID == objectID);
            if (course != null)
            {
                courses.Remove(course);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Course is deleted");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("courses not found.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid object type.");
            Console.ResetColor();
        }
    }

    static void DisplayDatabase()
    {
        Person person = null;
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine("Instructors:");
        Console.ResetColor();
        foreach (Instructor i in instructors)
        {
            person = i;
            person.DisplayInfor();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Students:");
        Console.ResetColor();
        foreach (Student s in students)
        {
            person = s;
            person.DisplayInfor();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Courses:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (Course c in courses)
        {            
            c.DisplayInfo();
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    static Instructor GetInstructor()
    {
        bool check = true;
        Instructor newInstructor = null;
        while (check == true)
        {
            Console.WriteLine("--Insert instructor--");
            Console.WriteLine("1. Add new instructor.");
            Console.WriteLine("2. Add available instructor.");
            Console.WriteLine("3. Add later.");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    newInstructor = Instructor.CreateInstructor();
                    check = false;
                    break;
                case "2":
                    Console.Write("Enter Instructor ID: ");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        newInstructor = instructors.Find(i => i.Id == id);
                        check = false;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid integer for the Instructor ID.");
                        Console.ResetColor();
                        Console.WriteLine("Enter Instructor ID again: ");
                    }                                   
                    break;
                case "3":
                    newInstructor = null;
                    check = false;
                    break;
                default:                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    Console.ResetColor();
                    break;
            }            
        }
        return newInstructor;        
    }
    
}
