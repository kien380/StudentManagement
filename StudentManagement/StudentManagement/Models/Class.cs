using SQLite.Net.Attributes;

namespace StudentManagement.Models
{
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
