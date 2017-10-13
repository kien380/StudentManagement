using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using StudentManagement.Droid.Services.LocalDatabase;
using StudentManagement.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection))]
namespace StudentManagement.Droid.Services.LocalDatabase
{
    public class DatabaseConnection : IDatabaseConnection
    {
        string GetPath(string databaseName)
        {
            var sqliteFilename = $"{databaseName}.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }

        public SQLiteConnection DbConnection(string databaseName)
        {
            return new SQLiteConnection(new SQLitePlatformAndroid(), GetPath(databaseName));
        }

        public long GetSize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo.Length;
        }
    }
}