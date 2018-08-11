using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVData
{
    public class DbConfig : DbConfiguration
    {
        public DbConfig()
        {
            var provider = "Npgsql";
            SetProviderFactory(provider, NpgsqlFactory.Instance);
            SetProviderServices(provider, NpgsqlServices.Instance);
            SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
        }
    }
}
