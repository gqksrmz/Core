using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VideoProject.Core
{
    class DESHelper
    {
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
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            StreamWriter streamWriter = null;
            string result = string.Empty;
            try
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                int i = cryptoProvider.KeySize;
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);
                streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(data);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                streamWriter.Flush();
                result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
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
        //解密
        private static string DESDecrypt(string data)
        {
            byte[] byteInput = Convert.FromBase64String(data);
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
    }
}
