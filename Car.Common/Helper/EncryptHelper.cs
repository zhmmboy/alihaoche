using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Car.Common
{
    /// <summary>
    /// 加密解密助手类
    /// </summary>
    public class EncryptHelper
    {
        #region Base64

        /// <summary>
        /// 原始Base64加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] Base64Encrypt(byte[] source)
        {
            if (source == null || source.Length == 0)
            {
                return null;
            }
            ToBase64Transform tb64 = new ToBase64Transform();
            using (MemoryStream ms = new MemoryStream())
            {
                int pos = 0;
                byte[] buff;
                while (pos + 3 < source.Length)
                {
                    buff = tb64.TransformFinalBlock(source, pos, 3);
                    ms.Write(buff, 0, buff.Length);
                    pos += 3;
                }
                buff = tb64.TransformFinalBlock(source, pos, source.Length - pos);
                ms.Write(buff, 0, buff.Length);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 原始Base64解密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] Base64Decrypt(byte[] source)
        {
            if (source == null || source.Length == 0)
            {
                return null;
            }
            FromBase64Transform fb64 = new FromBase64Transform();
            using (MemoryStream ms = new MemoryStream())
            {
                int pos = 0;
                byte[] buff;
                while (pos + 4 < source.Length)
                {
                    buff = fb64.TransformFinalBlock(source, pos, 4);
                    ms.Write(buff, 0, buff.Length);
                    pos += 4;
                }
                buff = fb64.TransformFinalBlock(source, pos, source.Length - pos);
                ms.Write(buff, 0, buff.Length);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Base64加密(字符串)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string source, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(source));
        }

        /// <summary>
        /// Base64解密(字符串)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string source, Encoding encoding)
        {
            return encoding.GetString(Convert.FromBase64String(source));
        }

        /// <summary>
        /// Base64加密(字符串utf-8)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string source)
        {
            return Base64Encrypt(source, Encoding.UTF8);
        }

        /// <summary>
        /// Base64解密(字符串utf-8)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string source)
        {
            return Base64Decrypt(source, Encoding.UTF8);
        }

        #endregion

        #region Md5
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strValue">需要加密的字符串</param>
        /// <param name="isUpper">是否大写</param>
        /// <param name="isSixteenBit">是否16位</param>
        /// <returns></returns>
        public static string Md5(string strValue, bool isUpper, bool isSixteenBit)
        {
            byte[] md5Bytes = Encoding.UTF8.GetBytes(strValue);
            return Md5(md5Bytes, isUpper, isSixteenBit);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="md5Bytes">字节</param>
        /// <returns></returns>
        public static string Md5(byte[] md5Bytes)
        {
            return Md5(md5Bytes, false, false);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="md5Bytes">字节</param>
        /// <param name="isUpper">是否大写</param>
        /// <param name="isSixteenBit">是否16位</param>
        /// <returns></returns>
        public static string Md5(byte[] bytes, bool isUpper, bool isSixteenBit)
        {
            byte[] md5Bytes = MD5.Create().ComputeHash(bytes);
            string format = isUpper ? "{0:X2}" : "{0:x2}";

            StringBuilder builder = new StringBuilder();

            foreach (byte md5Byte in md5Bytes)
            {
                builder.AppendFormat(format, md5Byte);
            }

            return isSixteenBit ? builder.ToString().Substring(8, 16) : builder.ToString();
        }

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="strValue">需要加密的字符串</param>
        /// <param name="isUpper">是否大写</param>
        /// <returns></returns>
        public static string Md5(string strValue, bool isUpper)
        {
            return Md5(strValue, isUpper, false);
        }

        /// <summary>
        /// MD5加密(32位小写)
        /// </summary>
        /// <param name="strValue">需要加密的字符串</param>
        /// <returns></returns>
        public static string Md5(string strValue)
        {
            return Md5(strValue, false, false);
        }
        #endregion

        #region 加密解密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="clearData">源数据</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv)
        {
            byte[] encryptedData;
            using (MemoryStream ms = new MemoryStream())
            {
                Rijndael alg = Rijndael.Create();

                alg.Key = key;
                alg.IV = iv;

                CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(clearData, 0, clearData.Length);

                cs.Close();

                encryptedData = ms.ToArray();
            }

            return encryptedData;
        }

        /// <summary>
        /// 加密(字符串)
        /// </summary>
        /// <param name="clearText">源字符串</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static string Encrypt(string clearText, string password)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
                                 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);

        }

        /// <summary>
        /// 加密(数据)
        /// </summary>
        /// <param name="clearData">源数据</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] clearData, string password)
        {
            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
                                 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);

            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));

        }

        /// <summary>
        /// 加密(文件)
        /// </summary>
        /// <param name="fileIn">源文件路径</param>
        /// <param name="fileOut">加密文件路径</param>
        /// <param name="password">密码</param>
        public static void Encrypt(string fileIn, string fileOut, string password)
        {

            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
                                 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);

            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            cs.Close();
            fsIn.Close();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherData">加密数据</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipherData, byte[] key, byte[] iv)
        {
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();

            alg.Key = key;
            alg.IV = iv;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);

            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        /// <summary>
        /// 解密(字符串)
        /// </summary>
        /// <param name="cipherText">加密字符串</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
                                 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Encoding.Unicode.GetString(decryptedData);
        }

        /// <summary>
        /// 解密(数据)
        /// </summary>
        /// <param name="cipherData">加密数据</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipherData, string password)
        {
            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
                                 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);

            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        /// <summary>
        /// 解密(文件)
        /// </summary>
        /// <param name="fileIn">加密文件路径</param>
        /// <param name="fileOut">解密文件路径</param>
        /// <param name="password">密码</param>
        public static void Decrypt(string fileIn, string fileOut, string password)
        {

            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] rgb = new byte[]
                             {
                                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
                                 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                             };
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, rgb);
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                cs.Write(buffer, 0, bytesRead);

            } while (bytesRead != 0);

            cs.Close();

            fsIn.Close();
        }

        #endregion

        #region 客户端密码加密和解密

        /// <summary>
        /// 对客户端要保存的密码进行加密
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns></returns>
        public static string EncryptClientPswd(string pswd)
        {
            return Encrypt(pswd,SystemVar.ClientPswdEncryptKey);
        }

        /// <summary>
        /// 对客户端保存的密码进行解密
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns></returns>
        public static string DecryptClientPswd(string pswd)
        {
            return Decrypt(pswd,SystemVar.ClientPswdEncryptKey);
        }

        #endregion


        #region 用户凭据加密和解密

        /// <summary>
        /// 对用户凭据进行加密
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static string EncryptUserInfo(string userInfo)
        {
            return Encrypt(userInfo, SystemVar.UserInfoEncryptKey);
        }

        /// <summary>
        /// 对用户凭据进行解密
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static string DecryptUserInfo(string userInfo)
        {
            return Decrypt(userInfo, SystemVar.UserInfoEncryptKey);
        }

        #endregion
    }
}
