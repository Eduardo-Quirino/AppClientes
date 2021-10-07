using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppClientes.Infra
{
    interface ISQLiteDBConnection
    {
        SQLiteConnection DBConnection();
    }
}
