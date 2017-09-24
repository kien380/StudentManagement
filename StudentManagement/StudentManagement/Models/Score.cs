using SQLite.Net.Attributes;

namespace StudentManagement.Models
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [PrimaryKey]
        public int StudentId { get; set; }

        [PrimaryKey]
        public int SubjectId { get; set; }

        [PrimaryKey]
        public int Semester { get; set; }

        public float Score15M { get; set; }

        public float Score45M { get; set; }

        public float ScoreFinal { get; set; }

        [Ignore]
        public float ScoreAverage => (Score15M + Score45M * 2 + ScoreFinal * 3) / 6;
    }
}
