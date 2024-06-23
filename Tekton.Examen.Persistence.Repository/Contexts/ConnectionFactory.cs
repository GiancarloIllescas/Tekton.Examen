using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekton.Examen.Cross.Common;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;


namespace Tekton.Examen.Persistence.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuracion)
        {
            this._configuration = configuracion;
        }


        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (this._configuration == null) return null;

                sqlConnection.ConnectionString = this._configuration.GetConnectionString("bdTekton");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
