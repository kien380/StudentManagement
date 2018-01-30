using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using StudentManagement.Interfaces;
using StudentManagement.Models;

namespace StudentManagement.Services.LocalDatabase
{
    public class SQLiteHelper : ISQLiteHelper
    {
        #region Attributes
        const string DatabaseName = "StudentManagement";

        protected SQLiteConnection Database;

        protected static readonly object Locker = new object();

        #endregion

        #region Constructors

        public SQLiteHelper(IDatabaseConnection databaseConnection)
        {
            Init(databaseConnection);
        }

        #endregion

        #region Inits

        private void Init(IDatabaseConnection databaseConnection)
        {
            if (Database != null) return;

            // Connect database
            Database = databaseConnection.DbConnection(DatabaseName);

            // Create database
            var listTable = new List<Type>{
                typeof(Class),
                typeof(Score),
                typeof(Setting),
                typeof(Student),
                typeof(Subject),
                typeof(User)
            };

            foreach (var table in listTable)
            {
                CreateTable(table);
            }
        }

        #endregion

        #region Methods

        #region Create Database

        private void CreateTable<T>(T table) where T : Type
        {
            lock (Locker)
            {
                try
                {
                    Database.CreateTable(table);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"CreateTable: {e}");
                }
            }
        }
        #endregion

        #region Gets

        /// <summary>
        /// Return data of multiple table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        public T GetWithChildren<T>(string primaryKey, bool isRecursive = false) where T : class, new()
        {
            lock (Locker)
            {
                try
                {
                    return Database.GetWithChildren<T>(primaryKey, isRecursive);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"GetWithChildren - primaryKey: {e}");
                    return null;
                }
            }
        }

        public T Get<T>(string primarykey) where T : class, new()
        {
            lock (Locker)
            {
                try
                {
                    return Database.Get<T>(primarykey);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Get - primaryKey: {e}");
                    return null;
                }
            }
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            try
            {
                lock (Locker)
                {
                    return Database.Table<T>().Where(predicate).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Get - Expression: {e}");
                return null;
            }
        }


        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            lock (Locker)
            {
                try
                {
                    return Database.Table<T>().Where(predicate).ToList();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Get - Expression: {e}");
                    return null;
                }
            }
        }

        public Setting GetSetting()
        {
            try
            {
                var setting = Database.Get<Setting>(s => s.Id == 1);
                if (setting == null)
                    return new Setting
                    {
                        Id = 1,
                        IsInitData = true,
                        MinStudentAge = 15,
                        MaxStudentAge = 20,
                        MaxStudentPerClass = 40,
                        SubjectPassScore = 5.0f
                    };
                return setting;
            }
            catch (Exception e)
            {
                return new Setting
                {
                    Id = 1,
                    IsInitData = true,
                    MinStudentAge = 15,
                    MaxStudentAge = 20,
                    MaxStudentPerClass = 40,
                    SubjectPassScore = 5.0f
                };
            }
        }

        public User GetUser()
        {
            try
            {
                var user = Database.Get<User>(s => s.Id > 0);
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region Inserts

        public int Insert<T>(T obj)
        {
            lock (Locker)
            {
                try
                {
                    return Database.InsertOrReplace(obj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - Insert: {e}");
                    return -1;
                }
            }
        }

        public int InsertAll<T>(IEnumerable<T> list)
        {
            lock (Locker)
            {
                try
                {
                    return Database.InsertOrReplaceAll(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - InsertAll: {e}");
                    return -1;
                }
            }
        }

        public void InsertWithChildren<T>(T obj, bool isRecursive = false)
        {
            lock (Locker)
            {
                try
                {
                    Database.InsertWithChildren(obj, isRecursive);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - InsertWithChildren: {e}");
                }
            }
        }

        #endregion

        #region Updates

        public int Update<T>(T obj)
        {
            lock (Locker)
            {
                try
                {
                    return Database.Update(obj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - Update: {e}");
                    return -1;
                }
            }
        }

        public void UpdateWithChildren<T>(T obj)
        {
            lock (Locker)
            {
                try
                {
                    Database.UpdateWithChildren(obj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - UpdateWithChildren {e}");
                }
            }
        }

        #endregion

        #region Deletes

        public int Delete<T>(string id)
        {
            lock (Locker)
            {
                try
                {
                    return Database.Delete<T>(id);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - Delete: {e}");
                    return -1;
                }
            }
        }

        public void Delete<T>(T obj, bool isRecursive = false)
        {
            lock (Locker)
            {
                try
                {
                    Database.Delete(obj, isRecursive);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - void Delete: {e}");
                }
            }
        }

        public int DeleteAll<T>()
        {
            lock (Locker)
            {
                try
                {
                    return Database.DeleteAll<T>();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - DeleteAll: {e}");
                    return -1;
                }
            }
        }

        public void DeleteAll<T>(IEnumerable<T> obj)
        {
            lock (Locker)
            {
                try
                {
                    Database.DeleteAll(obj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"SQLiteHelper - DeleteAll: {e}");
                }
            }
        }

        #endregion
        
        #endregion
    }
}
