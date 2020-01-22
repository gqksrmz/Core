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
        private static string constr = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }
        private static string DESDecrypt(string s1)
        {
            byte[] byteInput = Convert.FromBase64String(s1);
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
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            StreamReader streamReader = null;
            string text = string.Empty;
            string result;
            try
            {
                DES des = DES.Create();

                des.Key = key;
                des.IV = iv;
                ICryptoTransform transform = des.CreateDecryptor();
                memoryStream = new MemoryStream(byteInput);
                cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
                streamReader = new StreamReader(cryptoStream);
                text = streamReader.ReadToEnd();
                streamReader.Close();
                cryptoStream.Close();
                memoryStream.Close();
                result = text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                }
                if (memoryStream != null)
                {
                    memoryStream.Close();
                }
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = AppDomain.CurrentDomain.BaseDirectory + "\\config.Config";
            StreamReader streamReader = File.OpenText(text);
            string text2 = streamReader.ReadToEnd();
            text2 = DESDecrypt(text2);
            constr = text2;
            if (string.IsNullOrEmpty(this.txtUName.Text) || string.IsNullOrEmpty(this.txtUPwd.Text))
            {
                MessageBox.Show("账号或者密码为空，请重新输入！");
                return;
            }
            string sqlJudge = @"select count(*) from tblUser where UserID=@UserID";
            SqlParameter pms1 = new SqlParameter("@UserID", this.txtUName.Text);
            int count = (int)ExecuteScalar(sqlJudge, CommandType.Text, pms1);
            if (count > 0)
            {
                MessageBox.Show("您注册的账号已经存在！");
                return;
            }
            //string connStr = "Data Source=127.0.0.1;Initial Catalog=" + txtDBName.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtDBPass.Text;
            string sqlStr = @"insert into tblUser(UserID,UserIDIndex,Password,Create_dt,Update_dt,status,LockService,WorldID) values(@UserID,@UserIDIndex,@Password,@Create_dt,@Update_dt,@status,@LockService,@WorldID)";
            SqlParameter[] pms2 = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.VarChar){ Value = this.txtUName.Text},
                new SqlParameter("@UserIDIndex",SqlDbType.BigInt){ Value=1},
                new SqlParameter("@Password",SqlDbType.VarChar){Value=GenerateMD5( this.txtUPwd.Text)},
                new SqlParameter("@Create_dt",SqlDbType.DateTime){ Value=DateTime.Now},
                new SqlParameter("@Update_dt",SqlDbType.DateTime){ Value=DateTime.Now},
                new SqlParameter("@status",SqlDbType.Int){ Value=1},
                new SqlParameter("@LockService",SqlDbType.Char){ Value="0"},
                new SqlParameter("@WorldID",SqlDbType.VarChar){ Value="1"},
            };
            int rowCount = ExecuteNonQuery(sqlStr, CommandType.Text, pms2);
            if (rowCount > 0)
            {
                MessageBox.Show("注册成功！");
            }
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
        public static Object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pms)
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
                    return cmd.ExecuteScalar();
                }
            }
        }
        //MD5加密
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
