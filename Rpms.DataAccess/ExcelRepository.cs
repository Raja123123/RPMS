using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace Rpms.DataAccess
{
    public class ExcelRepository<T>: IExcelRepository<T>
    {
        public string FullPath { get; set; }
        public string Extension { get; set; }
        public string ExtendedPropertie { get; set; }
        public string ConnectionString { get; set; }
        public string Provider { get; set; }

        private readonly Utility _utility;
        public ExcelRepository(string fullPath)
        {
            FullPath = fullPath;
            Extension = Path.GetExtension(fullPath);
            switch (Extension.ToLower())
            {
                case ".xls":
                    ExtendedPropertie = "Excel 8.0";
                    Provider = "Microsoft.Jet.OLEDB.4.0";
                    break;
                case ".xlsx":
                    ExtendedPropertie = "Excel 12.0";
                    Provider = "Microsoft.ACE.OLEDB.12.0";
                    break;
                default:
                    throw new Exception("Invalid extension");
                    
            }
            ConnectionString = $"Provider={Provider};Data Source = '{fullPath}';Extended Properties=\"{ExtendedPropertie};HDR=YES;\"";

            _utility = new Utility();
        }


        public IEnumerable<T> All() {

            DataTable dataTable; 
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    var allFields = _utility.GetColumns<T>();
                    var query = $"select {string.Join(",", allFields.Select(d => "[" + d.Value + "]"))} from [{_utility.GetSheetName<T>()}$]";
                    OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
                    (query, conn);
                    DataSet excelDataSet = new DataSet();
                    objDA.Fill(excelDataSet);
                    dataTable = excelDataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                    conn.Close();
                    conn.Dispose();
                }
                finally {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return dataTable.DataTableToList<T>();
        }
        public T Add(T entity) {


            using (OleDbCommand cmd = new OleDbCommand())
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                 
                    var allFields = _utility.GetAllColumnValues<T>(entity);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = $"Insert into [{_utility.GetSheetName<T>()}$] ({string.Join(",", allFields.Select(d => "[" + d.Key + "]"))}) VALUES ({string.Join(",", allFields.Select(d =>  "'" +d.Value + "'"))});";
                    cmd.ExecuteNonQuery();
                
            }
            return entity;
        }
        public bool Delete(Guid ID) {
            var response = false;
            using (OleDbCommand cmd = new OleDbCommand())
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                 

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = $"UPDATE [{_utility.GetSheetName<T>()}$] SET Status = 'Inactive'  WHERE ID = '{ID}';";
                    cmd.ExecuteNonQuery();
                    response = true;
               
            }
            return response;
        }
        public bool Update(Guid ID, T entity) {
            var response = false;

            using (OleDbCommand cmd = new OleDbCommand())
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                
                    var allFields = _utility.GetRuntimeColumnValues<T>(entity);

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = $"UPDATE [{_utility.GetSheetName<T>()}$] SET {string.Join(",", allFields.Select(d => "[" + d.Key  +"] = '" + d.Value + "'"))}  WHERE ID = '{ID}';";
                    cmd.ExecuteNonQuery();
                    response = true;
            }
            return response;
        }
        public T FindById(Guid ID) {
            DataTable dataTable;

            using (OleDbCommand cmd = new OleDbCommand())
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                conn.Open();

                var allFields = _utility.GetColumns<T>();
                var query = $"select {string.Join(",", allFields.Select(d => "[" + d.Value + "]"))} from [{_utility.GetSheetName<T>()}$] WHERE ID='{ID}'";
                OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
                (query, conn);
                DataSet excelDataSet = new DataSet();
                objDA.Fill(excelDataSet);
                dataTable = excelDataSet.Tables[0];
            }

            return dataTable.DataTableToList<T>().FirstOrDefault();
        }


    }
}
