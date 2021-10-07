using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App_Clientes.DAL
{
    public class ClienteDAL
    {
        private SQLiteConnection sqlConnection;

        public ClienteDAL()
        {
            this.sqlConnection = DependencyService.Get<ISQLiteDBConnection>().DbConnection();
            this.sqlConnection.CreateTable<Cliente>();
            this.sqlConnection.CreateTable<Usuario>();
        }

        public void Add(Cliente cliente)
        {
            sqlConnection.Insert(cliente);
        }

        public void DeleteById(long id)
        {
            sqlConnection.Delete<Cliente>(id);
        }

        public void Update(Cliente cliente)
        {
            sqlConnection.Update(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return (from t in sqlConnection.Table<Cliente>() select t).OrderBy(i => i.Nome).ToList();
        }

        public Cliente GetClienteById(long id)
        {
            return sqlConnection.Table<Cliente>().FirstOrDefault(t => t.ClienteId == id);
        }

        public Usuario GetUsuarioLogin(string senha)
        {
            return sqlConnection.Table<Usuario>().FirstOrDefault(t => t.Senha == senha);
        }

        public void Add(Usuario usuario)
        {
            sqlConnection.Insert(usuario);
        }
    }
}