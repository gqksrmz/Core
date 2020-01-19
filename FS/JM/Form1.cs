using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();

        }
        public static string DESEncrypt(string data)
        {
            byte[] key = new byte[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8
            };
            byte[] iv = new byte[]
            {
                8,
                7,
                6,
                5,
                4,
                3,
                2,
                1
            };
            byte[] byKey = key;
            byte[] byIV = iv;

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //    string connStr = "Data Source=127.0.0.1;Initial Catalog=" + txtDBName.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtDBPass.Text;
            //    sqlConnection = new SqlConnection(connStr);
            //    if (sqlConnection.State != ConnectionState.Open)
            //    {
            //        sqlConnection.Open();
            //    }
            //    string sqlStr = @"intsert into @tableName （UserID,UserIDIndex,Password,Create dt,Update dt,status,LockService,WorldID）
            //                                    values (@UserID,@UserIDIndex,@Password,@Create dt,@Update dt,@status,@LockService,@WorldID)";
            //    SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);
            //    sqlCommand.CommandType = CommandType.StoredProcedure;

            //    sqlCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar)).Value = this.txtUName.Text;
            //    sqlCommand.Parameters.Add(new SqlParameter("@UserIDIndex", SqlDbType.BigInt)).Value = iPassword;
            //    sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = iIP;
            //    sqlCommand.Parameters.Add(new SqlParameter("@Create dt", SqlDbType.DateTime)).Value = iIP;
            //    sqlCommand.Parameters.Add(new SqlParameter("@Update dt", SqlDbType.DateTime)).Value = iIP;
            //    sqlCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.Int)).Value = iIP;
            //    sqlCommand.Parameters.Add(new SqlParameter("@LockService", SqlDbType.Char)).Value = iIP;
            //    sqlCommand.Parameters.Add(new SqlParameter("@WorldID", SqlDbType.VarChar)).Value = iIP;

            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //    if (sqlDataReader.Read())
            //    {
            //        text = string.Format("{0}", sqlDataReader["Result"]);
            //        text2 = string.Format("{0}", sqlDataReader["UID"]);
            //    }
            //    sqlDataReader.Close();
            //    sqlDataReader.Dispose();
        }
    }
}
