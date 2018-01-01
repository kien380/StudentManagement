using SQLite.Net.Attributes;

namespace StudentManagement.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [Ignore]
        public float ScoreAvg { get; set; }

        [Ignore]
        public int Semester { get; set; }
    }
}
