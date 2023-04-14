using System.Text;

public delegate void DExam(string teacherName, string examTask);

class Student
{
    private string _name;
    private string _surname;

    public int Variant { get; set; } = 0;

    public string FullName => $"{_surname} {_name}";

    public Student(string name, string surname)
    {
        _name = name;
        _surname = surname;
    }

    public void Exam(string teacherName, string examTask)
    {
        Console.WriteLine($"{teacherName}\tвидав студенту {this.FullName}      \tзавдання: \"{examTask}\" (В - {Variant})" +
            $"\n=====/\t\t\t=====/\t\t\t\t\t=====/");
    }
}

class Teacher
{
    private event DExam? ExamStudentsList;

    private string _name;
    private string _surname;

    public string FullName => $"{_surname} {_name}";

    public Teacher(string name, string surname)
    {
        _name = name;
        _surname = surname;
    }

    public void AddExamStudent(Student student)
    {
        ExamStudentsList += student.Exam;
    }

    public void Exam(string examTask)
    {
        if (ExamStudentsList != null)
        {
            ExamStudentsList(this.FullName, examTask);
        }
    }
}

static class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string[] names =    { "Андрій",   "Тетяна",     "Нікіта",  "Володимир",  "Олексій",  "Олександр",  "Єгор",       "Артем",    "Олександр",  "Ірина",    "Андрій",  "Даниїл" };
        string[] surnames = { "Василіу",  "Деревянко",  "Козар",   "Марциняк",   "Лакуста",  "Меленко",    "Григорець",  "Ботнарь",  "Василіу",    "Олексюк",  "Чумак",    "Петрюк" };

        Teacher teacher = new("Леонід", "Українець");
        List<Student> students = new List<Student>();

        for (int i = 0; i < names.Length - 1; i++) 
        {
            students.Add(new Student(names[i], surnames[i]) { Variant = i % 2 + 1 });
        }

        foreach (Student student in students)
        {
            teacher.AddExamStudent(student);
        }

        teacher.Exam("іспит");
    }
}