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
    public partial class Form2 : Form
    {
        private static readonly string constr = "Data Source=127.0.0.1;Initial Catalog=BillingDB;User ID=sa;Password=123456";
        public Form2()
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


            //string connStr = "Data Source=127.0.0.1;Initial Catalog=" + txtDBName.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtDBPass.Text;
            string sqlStr = @"intsert into tblUser （UserID,UserIDIndex,Password,Create dt,Update dt,status,LockService,WorldID）
                                            values (@UserID,@UserIDIndex,@Password,@Create dt,@Update dt,@status,@LockService,@WorldID)";
            SqlParameter[] pms =
            {
                new SqlParameter("@UserID",this.txtUName.Text),
                new SqlParameter("@UserIDIndex",1),
                new SqlParameter("@Password",this.txtUPwd.Text),
                new SqlParameter("@Create dt",DateTime.Now),
                new SqlParameter("@Update dt",null),
                new SqlParameter("@status",1),
                new SqlParameter("@LockService",0),
                new SqlParameter("@WorldID",1),
            };
            int rowCount = ExecuteNonQuery(sqlStr, CommandType.Text, pms);
        }

        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = type;
                    //如果paramameter为空直接执行回报错
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
