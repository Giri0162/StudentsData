using StudentsData.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentsData.Service
{
public class StudentsModify{

    private List <StudentsInfo> li = new List<StudentsInfo>();

    public void AddStudentDetails(StudentsInfo s)
    {
        if(li.Any(x => x.Id == s.Id))
            {
                Console.WriteLine("This Id is Already Exists!");
            }
            else
            {
                li.Add(s);
                Console.WriteLine("Student Details Added Succesfully");
            }     
    }

    public List<StudentsInfo> getStudents()
    {
        return li;
    }

    public StudentsInfo SearchStudent(int id)
    {
        return li.FirstOrDefault(X => X.Id == id);
    }

    public bool RemoveStudent(int id)
    {
        var i = SearchStudent(id);
        if(i != null)   
        {
            li.Remove(i);
            return true;
        }
        return false;
    }

}
}