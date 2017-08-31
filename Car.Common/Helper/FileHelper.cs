using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace Car.Common
{
    public class FileHelper
    {
        #region 内部方法
        private List<FileInfo> fileInfos = new List<FileInfo>();

        /// <summary>
        /// 递归获得目录及子目录下所有文件
        /// </summary>
        /// <param name="dir"></param>
        private void GetAllDirList(DirectoryInfo dir)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                fileInfos.Add(file);
            }
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                GetAllDirList(subDir);
            }
        }
        #endregion

        /// <summary>
        /// 获得目录及子目录下所有文件信息
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static FileInfo[] DirFiles(string basePath)
        {
            DirectoryInfo dir = new DirectoryInfo(basePath);
            FileHelper fh = new FileHelper();
            try
            {
                fh.GetAllDirList(dir);
            }
            catch (Exception)
            {
            }
            return fh.fileInfos.ToArray();
        }

        /// <summary>
        /// 下载网络文件
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DownloadFile(string uri, string fileName)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                if (resStream == null)
                {
                    return false;
                }
                StreamReader reader = new StreamReader(resStream, Encoding.Default);
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(reader.ReadToEnd());
                writer.Flush();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 下载网络字符串
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string DownloadString(string uri)
        {
            return DownloadString(uri, Encoding.Default);
        }

        /// <summary>
        /// 下载网络字符串
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DownloadString(string uri, Encoding encoding)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                if (resStream == null)
                {
                    return "";
                }
                StreamReader reader = new StreamReader(resStream, encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string GetFileString(string filename)
        {
            try
            {
                return File.ReadAllText(filename);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获得文件的二进制流
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static byte[] GetBinaryFile(string filename)
        {
            if (File.Exists(filename))
            {
                FileStream theStream = File.OpenRead(filename);
                int readByte;
                MemoryStream ms = new MemoryStream();
                while ((readByte = theStream.ReadByte()) != -1)
                {
                    ms.WriteByte(((byte)readByte));
                }
                byte[] bytes = ms.ToArray();
                ms.Dispose();
                theStream.Dispose();
                return bytes;
            }
            return new byte[0];
        }

        /// <summary>
        /// 将二进制流保存成文件
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveFile(byte[] bytes, string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || bytes == null || bytes.Length <= 0)
            {
                return false;
            }

            string path = Path.GetDirectoryName(fileName);

            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                MemoryStream ms = new MemoryStream(bytes);
                FileStream fs = new FileStream(fileName, FileMode.Create);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 创建文件目录
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateDir(string dir)
        {
            if (string.IsNullOrEmpty(dir) || string.IsNullOrEmpty(dir.Trim()))
            {
                return;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateDirForFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(filePath.Trim()))
            {
                return;
            }
            FileInfo fileInfo = new FileInfo(filePath);
            DirectoryInfo dirInfo = fileInfo.Directory;
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        public static string GetRelativePath(string baseDirectory, string path)
        {
            if (!Path.IsPathRooted(path))
            {
                throw new ArgumentException("The path is already relative.");
            }

            char slash = Path.DirectorySeparatorChar;
            string[] baseDirs = baseDirectory.Trim(slash).Split(slash);
            string[] pathDirs = path.Trim(slash).Split(slash);

            List<string> relPath = new List<string>();
            int count = 0;

            for (int i = 0; i < baseDirs.Length && i < pathDirs.Length; i++)
            {
                count = i;
                if (string.Compare(baseDirs[i], pathDirs[i], true) != 0)
                {
                    break;
                }
            }

            int backtracks = baseDirs.Length - count;
            for (int j = 0; j < backtracks; j++)
            {
                relPath.Add("..");
            }

            for (int k = count; k < pathDirs.Length; k++)
            {
                relPath.Add(pathDirs[k]);
            }

            string relativePath = string.Join(slash.ToString(), relPath.ToArray());

            return (relativePath.Length > 0) ? relativePath : ".";
        }

        public static string GetSubDirectory(string baseDirectory, string relativePath)
        {
            string tmpPath = relativePath;
            if (string.IsNullOrEmpty(tmpPath) || string.IsNullOrEmpty(tmpPath.Trim()) || tmpPath.Equals("."))
            {
                return baseDirectory;
            }
            if (tmpPath.StartsWith(".\\"))
            {
                tmpPath = tmpPath.Substring(2);
            }
            while (tmpPath[0] == Path.DirectorySeparatorChar)
            {
                tmpPath = tmpPath.Substring(1);
            }
            if (tmpPath.Contains(".."))
            {
                throw new Exception("存在特殊目录符号");
            }
            return Path.Combine(baseDirectory, tmpPath);
        }

        public static void DeleteOnExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// 路径拼接
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="relatePath"></param>
        /// <returns></returns>
        public static string PathCombine(string basePath, string relatePath)
        {
            if (basePath == null || relatePath == null)
            {
                return basePath;
            }
            basePath = basePath.Replace('/', '\\');
            relatePath = relatePath.Replace('/', '\\');
            if (!basePath.EndsWith("\\"))
            {
                basePath += '\\';
            }
            if (relatePath.StartsWith("\\"))
            {
                relatePath = relatePath.Substring(1);
            }
            return Path.Combine(basePath, relatePath);

        }


        /// <summary>
        /// 获取图片标志
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string[] GetImgTag(string htmlStr)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string[] strAry = new string[regObj.Matches(htmlStr).Count];
            int i = 0;
            foreach (Match matchItem in regObj.Matches(htmlStr))
            {
                strAry[i] = GetImgUrl(matchItem.Value);
                i++;
            }
            return strAry;
        }

        /// <summary>
        /// 获取图片URL地址
        /// </summary>
        /// <param name="imgTagStr"></param>
        /// <returns></returns>
        private static string GetImgUrl(string imgTagStr)
        {
            string str = "";
            Regex regObj = new Regex(@"(?<=src\="").*?(?="")", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match matchItem in regObj.Matches(imgTagStr))
            {
                str = matchItem.Value;
            }
            return str;
        }

        /// <summary>
        /// 上传文件到服务器
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="localUrl"></param>
        /// <returns></returns>
        public static bool UploadFile(string serverUrl, string localUrl)
        {
            WebClient wc = new WebClient();
            wc.UploadFile(serverUrl, localUrl);

            return true;
        }
    }
}
