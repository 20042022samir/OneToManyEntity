using AcademyProjectEntity.Contexts;
using AcademyProjectEntity.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("please");

AcademyDBcontextt academyCtx=new AcademyDBcontextt();
List<Group> groups=academyCtx.groups.ToList();
List<Student> students=academyCtx.studentss.ToList();



void CreateGroup()
{
    Console.WriteLine("enter the name of group:");
    AGAIN:
    string name=Console.ReadLine();
    if (!Check(name))
    {
        Console.WriteLine("name not accapted enter again:"); goto AGAIN;
    }
    academyCtx.groups.Add(new Group()
    {
        name=name,
        CreatedDaate=DateTime.Now,
        IsDeleted=false,
    });
    academyCtx.SaveChanges();
}

void GetAllGroups()
{
    if (groups.Count == 0)
    {
        Console.WriteLine("not a single group was added!");
        return;
    }
    foreach (var item in groups)
    {
        Console.WriteLine(item.name+"  "+item.Id+"     "+item.CreatedDaate);
    }
}

void FindGroup()
{
    Console.WriteLine("enter id of the goroup you wanna find:");
    int.TryParse(Console.ReadLine(), out int findGroupId);
    Group? group=academyCtx.groups.ToList().FirstOrDefault(a=>a.Id==findGroupId);
    if (group == null)
    {
        Console.WriteLine("group with such an id does not exist"); return;
    }
    Console.WriteLine(group.name+"  "+group.Id+"  "+group.IsDeleted);
    Console.WriteLine("do you wanna see students in that group as well?");
    Console.WriteLine("1-->YES");
    Console.WriteLine("2-->NO");
    int.TryParse(Console.ReadLine(), out int choicee);
    switch (choicee)
    {
        case 1:
            if(group.students.Count == 0)
            {
                Console.WriteLine("this group does not have student!");
            }
            foreach (var st in group.students)
            {
                Console.WriteLine(st.name+"  "+st.surname+"  "+st.Id);
            } break;
        case 2:
            break;
        default:
            break;
    }
}

void UpdateGroup()
{
    Console.WriteLine("enter id of the group you wanna update");
    int.TryParse(Console.ReadLine(), out int updateGroupId);
    Group? groupp=academyCtx.groups.FirstOrDefault(x=>x.Id==updateGroupId);
    if (groupp == null)
    {
        Console.WriteLine("group with such an id does not exist"); return;
    }
    Console.WriteLine("enter the new name");
    string? newGroupName=Console.ReadLine();
    groupp.name = newGroupName;
    academyCtx.SaveChanges();
}

void DeleteGroup()
{
    Console.WriteLine("enter id of the group you wanna delete:");
    int.TryParse(Console.ReadLine(), out int deletGroupId);
    Group? group= academyCtx.groups.ToList().FirstOrDefault(z=>z.Id==deletGroupId);
    if (group == null)
    {
        Console.WriteLine("group with such an Id does not exist"); return;
    }
    academyCtx.groups.ToList().Remove(group);
    academyCtx.SaveChanges();
}

void DeleteAllGroups()
{
    foreach (var item in academyCtx.groups.ToList())
    {
        academyCtx.groups.ToList().Remove(item);
    }
    academyCtx.SaveChanges();
    Console.WriteLine("deleted compleately!");
}






void CreateStudent()
{
    Console.WriteLine("enter name of the student:");
    AGAIN3:
    string studentName = Console.ReadLine();
    if (!Check(studentName))
    {
        Console.WriteLine("name not accapted enter again:"); goto AGAIN3;
    }
    Console.WriteLine("enter surname of the student:");
    string studentSurname=Console.ReadLine();
    Console.WriteLine("enter id of the group you wanna add this student:");
    AGAIN4:
    int.TryParse(Console.ReadLine(), out int groupId);
    Group? group=academyCtx.groups.ToList().FirstOrDefault(a=>a.Id==groupId);
    if (group == null)
    {
        Console.WriteLine("grop with such an id does not exist enter again:");
        goto AGAIN4;
    }
    Student student = new Student()
    {
        name=studentName,
        surname=studentSurname,
        group=group
    };
    academyCtx.studentss.Add(student);
    academyCtx.SaveChanges();
}

void GetAllStudents()
{
    List<Student> students = academyCtx.studentss
        .Include(x=>x.group)
        .ToList();
    foreach (Student student in students)
    {
        Console.WriteLine(student.name+"  "+student.surname+"  "+student.Id);
    }
}

void UpdateStudent()
{
    Console.WriteLine("enter id of the student you wanna update");
    int.TryParse(Console.ReadLine(), out int studentId);
    Student? student=academyCtx.studentss.ToList().FirstOrDefault(a=>a.Id== studentId);
    if (student == null)
    {
        Console.WriteLine("student with such an Id does not exist");
        return;
    }
    Console.WriteLine("what you wanna change?");
    Console.WriteLine("1-->Name");
    Console.WriteLine("2-->Surname");
    int.TryParse(Console.ReadLine(), out int SelectUpdate);
    switch (SelectUpdate)
    {
        case 1:
            Console.WriteLine("enter new name");
            string newName=Console.ReadLine();
            student.name = newName;
            academyCtx.SaveChanges(); break;
        case 2:
            Console.WriteLine("enter the new surname");
            string newSurname=Console.ReadLine();
            student.surname = newSurname;
            academyCtx.SaveChanges();  break;
        default:
            break;
    }
}

void DeleteStudent()
{
    Console.WriteLine("enter id of the student you wanna delete");
    int.TryParse(Console.ReadLine(), out int deleteIdStudent);
    Student? student=academyCtx.studentss.FirstOrDefault(z=>z.Id== deleteIdStudent);
    if (student == null)
    {
        Console.WriteLine("student with such an id does not exist"); return;
    }
    academyCtx.studentss.ToList().Remove(student);
    academyCtx.SaveChanges();
}

void GetStudent()
{
    Console.WriteLine("enter id of the student:");
    int.TryParse(Console.ReadLine(), out int findId);
    Student? student=academyCtx.studentss.FirstOrDefault(a=>a.Id==findId);
    if (student == null)
    {
        Console.WriteLine("student with such an id does not exist"); return;
    }
    Console.WriteLine(student.name+"  "+student.surname+"  "+student.Id);
}

DeleteGroup();

bool Check(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        if (char.IsDigit(data[i]))
        {
            return false;
        }
    }
    return true;
}

