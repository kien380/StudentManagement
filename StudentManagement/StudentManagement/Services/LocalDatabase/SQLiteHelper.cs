﻿using System;
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
            var listTable = new List<Type>(){typeof(Class), typeof(Score),
                                        typeof(Setting), typeof(Student),
                                        typeof(Subject)
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
        #endregion

        #region Searchs

        //public IEnumerable<StudentModel> SearchStudents<TStudentModel>(string searchInfo, string classId)
        //{
        //    lock (Locker)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                return Database.Table<StudentModel>().OrderBy(x => x.FirstName)
        //                    .Where(x => x.Birthdate.CompareTo(Convert.ToDateTime(searchInfo)) == -1).ToList();
        //            }
        //            catch (Exception e)
        //            {
        //                return Database.Table<StudentModel>().OrderBy(x => x.FirstName)
        //                    .Where(x => x.FirstName.Contains(searchInfo) || x.LastName.Contains(searchInfo)).ToList();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine($"SQLiteHelper - Search: {e}");
        //            return null;
        //        }
        //    }
        //}

        //public IEnumerable<ClassModel> SearchClasses<TClassModel>(string searchInfo, string classId)
        //{
        //    lock (Locker)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                return Database.Table<ClassModel>().OrderBy(x => x.StartDate)
        //                    .Where(x => x.EndDate.CompareTo(Convert.ToDateTime(searchInfo)) == 0
        //                    || x.StartDate.CompareTo(Convert.ToDateTime(searchInfo)) == 0).ToList();
        //            }
        //            catch (Exception e)
        //            {
        //                return Database.Table<ClassModel>().OrderBy(x => x.Name)
        //                    .Where(x => x.Name.Contains(searchInfo)).ToList();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine($"SQLiteHelper - Search: {e}");
        //            return null;
        //        }
        //    }
        //}

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

        #region Checks

        //public bool CheckAccount(string username, string password)
        //{
        //    lock (Locker)
        //    {
        //        try
        //        {
        //            var user = Database.Table<UserInfoModel>().FirstOrDefault(x => x.UserName == username
        //                                                                           && x.Hash256 ==
        //                                                                           Crypto.EncryptAes(password,
        //                                                                               x.Lecture.Token));

        //            if (user != null)
        //            {
        //                return user.Hash256 == Crypto.EncryptAes(password, user.Lecture.Token);
        //            }

        //            return false;
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine($"CheckAccount: {e}");
        //            return false;
        //        }
        //    }
        //}

        //public bool CheckLogin()
        //{
        //    lock (Locker)
        //    {
        //        try
        //        {
        //            return Database.Get<UserInfoModel>(Database.Table<UserInfoModel>()
        //                       .FirstOrDefault(x => x.IsLogin)) != null;
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine($"CheckLogin: {e}");
        //            return false;
        //        }
        //    }
        //}

        #endregion

        #endregion
    }
}