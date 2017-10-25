using System;
using SQLite.Net.Attributes;

namespace StudentManagement.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FullName { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public int Gender { get; set; }

        public DateTime DoB { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
