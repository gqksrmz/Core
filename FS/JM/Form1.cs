﻿using System;
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
            this.txtIP.Text = "127.0.0.1";
            this.txtDBName.Text = "BillingDB";
            this.txtUserName.Text = "sa";
            this.txtDBPass.Text = "123456";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s2 = "Data Source="+this.txtIP.Text+";Initial Catalog=" + this.txtDBName.Text + ";User ID=" + this.txtUserName.Text + ";Password=" + this.txtDBPass.Text;
            textBox2.Text = Form1.DESEncrypt(s2);
            File.WriteAllText(Application.StartupPath + "\\config.config",Form1.DESEncrypt(s2));
        }
        //BillingDB  
        //加密
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

    }
}
