using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Services.LocalDatabase
{
    public class MockData
    {
        private ISQLiteHelper _db;

        public MockData(ISQLiteHelper sqLite)
        {
            _db = sqLite;
        }

        public void InitMockData()
        {
            InitSetting();
            InitStudent();
            InitClass();
            InitSubject();
            InitScore();
        }

        private void InitClass()
        {
            // Insert or Replace student
            MockClassData mockClassData = new MockClassData();
            _db.InsertAll(mockClassData.Classes);
        }

        private void InitStudent()
        {
            // Insert or Replace student
            MockStudentData mockStudentData = new MockStudentData();
            _db.InsertAll(mockStudentData.Students);
        }

        private void InitSubject()
        {
            
        }

        private void InitScore()
        {
            
        }

        private void InitSetting()
        {
            _db.Insert(new Setting()
            {
                Id = 1,
                IsInitData = true,
                MinStudentAge = 15,
                MaxStudentAge = 20,
                MaxStudentPerClass = 40,
                SubjectPassScore = 5.0f
            });
        }
    }
}
