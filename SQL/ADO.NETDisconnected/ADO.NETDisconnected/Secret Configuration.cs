using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NETDisconnected
{
    class Secret_Configuration
    {
        public const string ConnectionString =
    "Server = tcp:mages1902sql.database.windows.net,1433; Initial Catalog = Chinook; " +
    "Persist Security Info = False; User ID = { your_username }; Password ={ your_password}; " +
    "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; " +
    "Connection Timeout = 30;";
    }
}
