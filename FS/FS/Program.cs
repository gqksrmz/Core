using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FS
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s1 =
            //    "CbQ03lGTJJ/MVucFeRf+axyzKGbegaRYKlfx6FdnoecnHW275/dnjewrv1ctLdhj0ua5We0tVH54AogrSyCKQjOfVK0+YQMtra8Cwy1ZxME=";
            //byte[] byteInput = Convert.FromBase64String(s1);
            //string text2 = Program.DESDecrypt(byteInput);
            string s2 = "Data Source=127.0.0.1;Initial Catalog=BillingDB;User ID=sa;Password=!sql716416";
            string result = Program.DESEncrypt(s2);
            Console.ReadKey();
        }
        private static string DESDecrypt(byte[] byteInput)
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
