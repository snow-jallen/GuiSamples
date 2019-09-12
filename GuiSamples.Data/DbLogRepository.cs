using Dapper;
using System.Collections.Generic;
using System.Data;

namespace GuiSamples.Data
{
    public class DbLogRepository
    {
        private readonly IDbConnection connection;

        public DbLogRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void AddLog(string logMessage)
        {
            connection.Execute(@"insert into log (message) values (@logMessage)", new { logMessage });
        }

        public IEnumerable<DbLog> GetLogs()
        {
            return connection.Query<DbLog>("select id, message from log");
        }
    }
}
