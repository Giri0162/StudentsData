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
                Console.WriteLine("Edit the student details");
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

                        Console.WriteLine("Enter a Phone Number :");
                        long phone = long.Parse(Console.ReadLine());

                        Console.Write("Enter a Address: ");
                        string address = Console.ReadLine();
                        
                        StudentsInfo s = new StudentsInfo()
                    {
                        Id = id,
                        Name = name,
                        Course = course,
                        Phone = phone,
                        Address = address
                    };                
                        sr.AddStudentDetails(s);
                        break;

                case 2:
                        foreach (var st in sr.getStudents().OrderBy(x => x.Id))
                            Console.WriteLine($"{st.Id} - {st.Name} - {st.Course} - {st.Phone} - {st.Address}");

                        break;

                case 3:
                        Console.Write("Enter ID: ");
                        var res = sr.SearchStudent(int.Parse(Console.ReadLine()));
                        if (res != null)
                            Console.WriteLine($"{res.Id} - {res.Name} - {res.Course} - {res.Phone} - {res.Address}");
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

                    case 6:
                        Console.WriteLine("Enter a Id to which student detail you have to edit : ");
                        int eid = int.Parse(Console.ReadLine());

                        var data = sr.SearchStudent(eid);

                        if(data == null)
                    {
                        Console.WriteLine("In this Id there is no student detail!");
                        break;
                    }

                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update Course");
                    Console.WriteLine("3. Update Phone");
                    Console.WriteLine("4. Update Address");
                   int up = int.Parse(Console.ReadLine());

                    switch (up)
                    {
                        case 1:
                            Console.Write("Edit Name: ");
                            string n = Console.ReadLine();
                            sr.EditStudentDetail(eid,newname : n);
                            
                            Console.WriteLine("Name updated!");
                            break;

                        case 2:
                            Console.Write("Edit Course: ");
                            string c = Console.ReadLine();
                            sr.EditStudentDetail(eid,newcourse : c);
                            
                            Console.WriteLine("Course updated!");
                            break;

                        case 3:
                            Console.Write("Edit PhoneNumber: ");
                            long p = long.Parse(Console.ReadLine());
                            sr.EditStudentDetail(eid,newphone : p);
                            
                            Console.WriteLine("PhoneNumber updated!");
                            break; 

                        case 4:
                            Console.Write("Edit Address: ");
                            string a = Console.ReadLine();
                            sr.EditStudentDetail(eid,newaddress : a);
                            
                            Console.WriteLine("Address updated!");
                            break; 

                         default:
                             Console.WriteLine("Invalid option!");
                             break;
                    }
                            break;

                    default:
                    Console.WriteLine("Invalid choice!");
                    break;
                    
                    }
            }
        }
}



  