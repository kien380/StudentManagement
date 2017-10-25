using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

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

        [Ignore]
        public string Avatar => Gender == 0 ? "student_girl.png" : "student_boy.png";

        [Ignore]
        public string GenderString => Gender == 0 ? "Nữ" : "Nam";
        
        [Ignore]
        public string GenderIcon => Gender == 0 ? "\uf278" : "\uf2a1";

        [Ignore]
        public Color GenderColor => Gender == 0 
            ? (Color) Application.Current.Resources["PinkColor"] 
            : Color.Green;

        [Ignore]
        public string DoBstring => DoB.ToString("dd-MM-yyyy");
    }
}
