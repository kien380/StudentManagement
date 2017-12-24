using System.Collections.Generic;
using System.Linq;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Helpers
{
    public class UserHelper
    {
        private List<User> _users;
        private static UserHelper _instance;
        public static UserHelper Instance => _instance ?? (_instance = new UserHelper());

        public UserHelper()
        {
            InitData();
        }

        public bool Login(ISQLiteHelper db, string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName.ToLower().Equals(username.Trim().ToLower()) 
                                                  && u.Password.Equals(password));
            if (user == null)
                return false;

            db.Insert(user);

            return true;
        }

        public void Logout(ISQLiteHelper db)
        {
            db.Delete(db.GetUser());
        }

        
        private void InitData()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Nguyễn Văn Bảo",
                    Avatar = "student_boy_1.png",
                    Role = RoleManager.StudentRole,
                    UserName = "baonv@gmail.com",
                    Password = "bao123"
                },
                new User
                {
                    Id = 1,
                    Name = "Hồ Hoàng Khang",
                    Avatar = "student_boy.png",
                    Role = RoleManager.StudentRole,
                    UserName = "khanghh@gmail.com",
                    Password = "khang123"
                },
                new User
                {
                    Id = 1,
                    Name = "Phan Tấn Thành",
                    Avatar = "teacher_4.png",
                    Role = RoleManager.TeacherRole,
                    UserName = "thanhpt@gmail.com",
                    Password = "thanh123"
                },
                new User
                {
                    Id = 1,
                    Name = "Huỳnh Hoa Trung Kiên",
                    Avatar = "teacher_5.png",
                    Role = RoleManager.PrincipalRole,
                    UserName = "kienhht@gmail.com",
                    Password = "kien123"
                },
            };
        }
    }
}
