using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Common
{

    /// <summary>
    /// 系统中所用到的一些常量或是公共参数。
    /// </summary>
    public sealed class SystemVar
    {
        /// <summary>
        /// 系统的ID
        /// </summary>
        public static readonly Guid SystemGuid = new Guid("00000000-0000-0000-0000-000000000000");

        /// <summary>
        /// 明星分类GUID
        /// </summary>
        public static readonly string ClassId_MingXing = "98d62719-bf35-4562-8301-731e4f91c19e";

        /// <summary>
        /// 企业家分类GUID
        /// </summary>
        public static readonly string ClassId_QiYeJia = "ccec93ce-c428-45cd-9025-2901fdbcce13";

        /// <summary>
        /// 社会名人分类GUID
        /// </summary>
        public static readonly string ClassId_SheHuiMingRen = "bd40aabe-fed4-4955-9c0f-d9c52bcd8012";

        /// <summary>
        /// 网络红人分类GUID
        /// </summary>
        public static readonly string ClassId_WangLuoHongRen = "b3c6ac73-8d90-4b69-b98a-1f88a08bcebd";

        /// <summary>
        /// 客户端密码加密密钥
        /// </summary>
        internal const string ClientPswdEncryptKey = "SRwdt201408";

        /// <summary>
        /// 用户凭据加密密钥
        /// </summary>
        internal const string UserInfoEncryptKey = "_SRWDT1409";

        /// <summary>
        /// 初始时间
        /// </summary>
        public static readonly DateTime SystemTime = Convert.ToDateTime("1950-01-01");

        /// <summary>
        /// 相册图片上传路径
        /// </summary>
        static string AlbumFolder = "/UpFile/Album/" + System.DateTime.Now.Year.ToString() + (System.DateTime.Now.Month < 10 ? "0" : "") + System.DateTime.Now.Month.ToString();
        public static string UpLoadImgForAlbum
        {
            get
            {
                if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(AlbumFolder)))
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(AlbumFolder));
                }

                return AlbumFolder;
            }
        }

        /// <summary>
        /// 新闻图片上传路径
        /// </summary>
        static string NewsFolder = "/UpFile/News/" + System.DateTime.Now.Year.ToString() + (System.DateTime.Now.Month < 10 ? "0" : "") + System.DateTime.Now.Month.ToString();
        public static string UpLoadImgForNews
        {
            get
            {
                if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(NewsFolder)))
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(NewsFolder));
                }

                return NewsFolder;
            }
        }

        /// <summary>
        /// 会员头像图片上传路径
        /// </summary>
        static string HeadFolder = "/UpFile/Head/" + System.DateTime.Now.Year.ToString() + (System.DateTime.Now.Month < 10 ? "0" : "") + System.DateTime.Now.Month.ToString();
        public static string UpLoadImgForHead
        {
            get
            {
                if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(HeadFolder)))
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(HeadFolder));
                }

                return HeadFolder;
            }
        }

        /// <summary>
        /// 支付宝收款账号
        /// </summary>
        public const string AlipayAccount = "18662506855@126.com"; //""; 


        /// <summary>
        /// 
        /// </summary>
        public enum EnumTagType
        {
            Person = 1,
            News = 2,
            Album = 3,
            Question = 4
        }

        public enum NewsStatus
        {
            /// <summary>
            /// 未审核
            /// </summary>
            UnChecked,

            /// <summary>
            /// 已审核
            /// </summary>
            Checked
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsCheckSame"></param>
        /// <param name="Folder"></param>
        /// <param name="ExtensionName"></param>
        /// <returns></returns>
        public static string GetNewName(bool IsCheckSame, string Folder, string ExtensionName)
        {
            string FilePath = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ExtensionName;

            if (IsCheckSame)
            {
                bool IsHave = false;
                while (!IsHave)
                {
                    if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(FilePath)))
                    {
                        FilePath = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ExtensionName;
                        continue;
                    }
                    else
                    {
                        IsHave = true;
                        break;
                    }
                }
            }
            else {
                return FilePath;
            }

            return FilePath;
        }
    }
}
