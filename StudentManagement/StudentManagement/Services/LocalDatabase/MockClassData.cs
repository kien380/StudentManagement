using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Services.LocalDatabase
{
    public class MockClassData
    {
        public List<Class> Classes { get; private set; }

        public MockClassData()
        {
            AddClass();
        }

        private void AddClass()
        {
            Classes = new List<Class>
            {
                new Class{ Id = 2001, Name = "10A1" },
                new Class{ Id = 2002, Name = "10A2" },
                new Class{ Id = 2003, Name = "10A3" },
                new Class{ Id = 2004, Name = "10A4" },
                new Class{ Id = 2005, Name = "11A1" },
                new Class{ Id = 2006, Name = "11A2" },
                new Class{ Id = 2007, Name = "11A3" },
                new Class{ Id = 2008, Name = "12A1" },
                new Class{ Id = 2009, Name = "12A2" },
            };
        }
    }
}
