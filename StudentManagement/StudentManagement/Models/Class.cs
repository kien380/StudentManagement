using System.Linq;
using SQLite.Net.Attributes;
using StudentManagement.Interfaces;

namespace StudentManagement.Models
{
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [Ignore]
        public int Students { get; private set; }

        [Ignore]
        public int Boys { get; private set; }

        [Ignore]
        public int Girls { get; private set; }

        [Ignore]
        public int MaxStudents { get; private set; }

        [Ignore]
        public bool IsFull { get; private set; }

        public void CountStudent(ISQLiteHelper db)
        {
            var students = db.GetList<Student>(s => s.ClassId == Id);
            Students = students?.Count() ?? 0;
            Boys = students?.Count(s => s.Gender == 1) ?? 0;
            Girls = Students - Boys;

            MaxStudents = db.GetSetting().MaxStudentPerClass;
            IsFull = Students >= MaxStudents;
        }
    }
}
