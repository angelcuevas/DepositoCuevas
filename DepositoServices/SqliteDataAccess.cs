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

        private static string connectionString = @"Data Source=B:\PROJECTS\VISUAL STUDIO\DepositoCuevas\DepositoCuevas\deposito.db;Version=3;";

        private TableQueryInfo tableQueryInfo = TableQueryInfoFactory.getQueryInfo<T>();

        private T item; 
            
        public List<T> getAll(string where = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {

                string qry = tableQueryInfo.SelectString;
                if(where != "")
                {
                    qry += " WHERE " + where; 
                }

                var output = cnn.Query<T>(qry, new DynamicParameters());
                return output.AsList<T>();
            }
        }

        public T getOne(string where, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                var output = cnn.Query<T>(tableQueryInfo.SelectString + " WHERE " + where, parameters);
                return output.AsList<T>()[0];
            }
        }

        public int getLastInsertedId(SQLiteConnection cnn)
        {
            
            SQLiteCommand cmd = new SQLiteCommand();
            cnn.Open();
            cmd.Connection = (SQLiteConnection)cnn;
            cmd.CommandText = "select seq from sqlite_sequence where name = '"+ tableQueryInfo.tableName+"'";
            Int64 LastRowID64 = (Int64)cmd.ExecuteScalar();
            return (int)LastRowID64;
        }

        public int save(T item)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                if (doesItExistsAlready(item))
                {
                    return -1; 
                }
                cnn.Execute(tableQueryInfo.InsertString, item);
                
                return getLastInsertedId((SQLiteConnection)cnn);
            }
        }

        public bool update(T item, string where)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                
                cnn.Execute(tableQueryInfo.UpdateString + " WHERE " + where , item);
                Console.WriteLine("x " + tableQueryInfo.UpdateString + " WHERE " + where);
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
