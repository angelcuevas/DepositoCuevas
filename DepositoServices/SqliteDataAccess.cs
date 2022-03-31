using Dapper;
using DepositoLib.juegos;
using DepositoServices.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;



namespace DepositoServices
{
    public class SqliteDataAccess<T> where T : class
    {

        private static string connectionString = @"Data Source=.\deposito.db;Version=3;";

        private TableQueryInfo tableQueryInfo = TableQueryInfoFactory.getQueryInfo<T>();

        private T item; 
            
        public List<T> getAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {   
                var output = cnn.Query<T>(tableQueryInfo.SelectString, new DynamicParameters());
                return output.AsList<T>();
            }
        }
        public bool save(T item)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                if (doesItExistsAlready(item))
                {
                    return false; 
                }
                cnn.Execute(tableQueryInfo.InsertString, item);
                return true;
            }
        }

        public bool doesItExistsAlready(T item)
        {
            this.item = item; 
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                IEnumerable<T> output = getQueryResult(cnn);
                return output.AsList<T>().Count > 0;
            }
        }

        private IEnumerable<T> getQueryResult(IDbConnection cnn)
        {
            if(tableQueryInfo.getDuplicityParameters(this.item).Count > 0)
            {
                var parameters = new DynamicParameters();

                foreach (var propiedad in tableQueryInfo.getDuplicityParameters(this.item))
                {
                    
                    parameters.Add(propiedad.Key, propiedad.Value);
                }



                return cnn.Query<T>(tableQueryInfo.SelectString + " WHERE " + tableQueryInfo.duclicityString, parameters);
            }



            return cnn.Query<T>(tableQueryInfo.SelectString + " where id = " + tableQueryInfo.getId(item), new DynamicParameters());
        }




    }
}
