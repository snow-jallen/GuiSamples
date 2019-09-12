using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GuiSamples.Data
{
    public static class ConnectionFactory
    {
        public static IDbConnection Create(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
