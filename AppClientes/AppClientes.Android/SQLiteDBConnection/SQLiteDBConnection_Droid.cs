using SQLite;
using System.IO;
using App_Clientes.Droid.SQLiteDBConnection;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDBConnection_Droid))]
namespace App_Clientes.Droid.SQLiteDBConnection
{
    public class SQLiteDBConnection_Droid : ISQLiteDBConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "Clientes.db3";
            string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsFolder, dbName);
            var platform = new SQLitePlatformAndroid();
            return new SQLiteConnection(platform, path);
        }
    }
}