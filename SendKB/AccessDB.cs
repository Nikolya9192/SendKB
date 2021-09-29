using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;

namespace SendKB
{
    class AccessDB
    {

        public static string connectionStrOra = "";
        public static OleDbConnection connectionOra;
     
        #region Login
        public static bool SetOraLoginPass(string Login, string Pass, string Base)
        {
            connectionStrOra = "Provider=\"MSDAORA.1\";User ID=" + Login + ";Data Source=\"" + Base + "\";Password=" + Pass + " ";
            connectionOra = new OleDbConnection(connectionStrOra);
            try
            {
                connectionOra.Open();
            }
            catch
            {
                return false;
            }
            connectionOra.Close();
            return true;
        }
        #endregion

        

        public AccessDB()
        {
            
        }
        public ArrayList Connect(int kodName)
        {
            ArrayList arlPathOutAttach = new ArrayList();                            
            
            using (connectionOra = new OleDbConnection(connectionStrOra))
            {
                connectionOra.Open();
                OleDbTransaction oledbtansact = connectionOra.BeginTransaction();
                OleDbCommand oledbcom = connectionOra.CreateCommand();
                oledbcom.Transaction = oledbtansact;


                try
                {
                        string query = "select t.out_dir from USR_CBS_CLIENTS t where t.odb_ref = " + kodName;
                        
                        oledbcom.CommandText = query;
                        try
                        {
                            OleDbDataReader reader = oledbcom.ExecuteReader();

                            if (reader.HasRows)
                                foreach (DbDataRecord i in reader)
                                {
                                    arlPathOutAttach.Add(i.GetValue(0) + @"\ATTACH").ToString();
                                }
                            reader.Close();

                        }
                        catch
                        { }
                    
                }
                catch
                { }

                return arlPathOutAttach;
            }
            
        }
    
    }
}
