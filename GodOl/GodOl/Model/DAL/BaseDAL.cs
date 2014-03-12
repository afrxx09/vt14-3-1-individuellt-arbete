using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace GodOl.Model.DAL
{
    public abstract class BaseDAL
    {
        private static string _connectionString;

        //protected static readonly string GenericErrorMessage = Strings.Generic_DAL_Error_Message;

        static BaseDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["GodOlConnectionString"].ConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}