using StudentsData.Model;
using StudentsData.Service;
using StudentsData.FileHandler;

internal class Program
    {
        static void Main(string[] args)
        {
            StudentsModify sr = new StudentsModify();

            sr.getStudents().AddRange(FileManager.Load());

            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Save & Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());
           
            switch (choice)
            {
                case 1:
                        Console.Write("Enter Student Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();
                        
                        StudentsInfo s = new StudentsInfo()
                    {
                        Id = id,
                        Name = name,
                        Course = course
                    };
                    
                        sr.AddStudentDetails(s);
                        break;

                case 2:
                        foreach (var st in sr.getStudents())
                            Console.WriteLine($"{st.Id} - {st.Name} - {st.Course}");
                        break;

                case 3:
                        Console.Write("Enter ID: ");
                        var res = sr.SearchStudent(int.Parse(Console.ReadLine()));
                        if (res != null)
                            Console.WriteLine($"{res.Id} - {res.Name} - {res.Course}");
                        else
                            Console.WriteLine("Not found");
                        break;

                    case 4:
                        Console.Write("Enter ID to remove: ");
                        if (sr.RemoveStudent(int.Parse(Console.ReadLine())))
                            Console.WriteLine("Removed");
                        else
                            Console.WriteLine("Not found");
                        break;

                    case 5:
                        FileManager.Save(sr.getStudents());
                        Console.WriteLine("Saved. Goodbye!");
                        return;    

                    default:
                    Console.WriteLine("Invalid choice!");
                    break;
                    
                    }
            }
        }
}



  