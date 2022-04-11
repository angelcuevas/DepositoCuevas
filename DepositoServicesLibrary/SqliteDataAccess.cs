using Dapper;
using DepositoClassLibrary.juegos;
using DepositoServicesLibrary.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DepositoServicesLibrary
{
    public class SqliteDataAccess<T> where T : class
    {

        private static string connectionString;

        private TableQueryInfo tableQueryInfo = TableQueryInfoFactory.getQueryInfo<T>();

        private T item;
        private int existingId;

        static SqliteDataAccess()
        {

            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            string absolutePath = path + "\\deposito.db";
            connectionString = string.Format("Data Source={0};Version=3", absolutePath);

        }
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
                if(output.AsList<T>().Count == 0)
                {
                    return null;
                }
                return output.AsList<T>()[0];
            }
        }

        public int getLastInsertedId(SQLiteConnection cnn)
        {
            
            SQLiteCommand cmd = new SQLiteCommand();
            //cnn.Open();
            cmd.Connection = (SQLiteConnection)cnn;
            cmd.CommandText = "select seq from sqlite_sequence where name = '"+ tableQueryInfo.tableName+"'";
            Int64 LastRowID64 = (Int64)cmd.ExecuteScalar();
            return (int)LastRowID64;
        }

        public int save(T item)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();

                if (doesItExistsAlready(item))
                {
                    if (existingId > 0)
                    {
                        int result = existingId;
                        existingId = 0;
                        return result;

                    }
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

                if(output.AsList<T>().Count > 0)
                {
                    Type t = output.AsList<T>()[0].GetType();
                    PropertyInfo prop = t.GetProperty("Id");
                    existingId = (int)prop.GetValue(output.AsList<T>()[0]);
                }
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

            if (tableQueryInfo.getId(item) == 0)
            {
                return Enumerable.Empty<T>();
            }

            return cnn.Query<T>(tableQueryInfo.SelectString + " where id = " + tableQueryInfo.getId(item), new DynamicParameters());
        }




    }
}
