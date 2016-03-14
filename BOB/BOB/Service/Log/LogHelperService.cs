using System;
using System.IO;
using System.Threading;
using System.Web;

namespace BOB
{
    public sealed class LogHelperService
    {
        private static LogHelperService _instance = new LogHelperService();
        public static Mutex LogLock = new Mutex();
        public static Mutex BackLogLock = new Mutex();
        public static String PushMessage = "PushMessage";
        /// <summary>
        /// 寫入log
        /// </summary>
        /// <param name="Forder">分類名稱</param>
        /// <param name="Message"></param>
        public static void doLog(string Forder, string Message)
        {
            String FileName = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "logs\\" + Forder + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            FileWrite(FileName, Message);
        }

        /// <summary>
        /// 寫入log
        /// </summary>
        /// <param name="Path">實體路徑</param>
        /// <param name="Forder">分類名稱</param>
        /// <param name="Message"></param>
        public static void doLog(string Path, string Forder, string Message)
        {
            String FileName = Path + "logs\\" + Forder + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            FileWrite(FileName, Message);
        }

        private static void FileWrite(string FilePath, string Message)
        {
            try
            {
                LogLock.WaitOne();

                if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                }

                if (!File.Exists(FilePath))
                {

                    using (StreamWriter f = File.CreateText(FilePath))
                    {
                        f.Flush();
                        f.Close();
                    }
                }
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " : " + Message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch// (Exception ex)
            {
                //throw new Exception("[FILEUtil.FileWrite]" + ex.Message);
            }
            finally
            {
                LogLock.ReleaseMutex();
            }
        }

        /// <summary>
        /// 寫入log(指定檔名)
        /// </summary>
        /// <param name="Forder">分類名稱</param>
        /// <param name="Message"></param>
        public static void doLogForBack(string Forder, string Message, string FName)
        {
            String FileName = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "logs\\" + Forder + "\\" + FName + ".txt";
            BackFileWrite(FileName, Message);
        }


        private static void BackFileWrite(string FilePath, string Message)
        {
            try
            {
                BackLogLock.WaitOne();

                if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                }

                if (!File.Exists(FilePath))
                {

                    using (StreamWriter f = File.CreateText(FilePath))
                    {
                        f.Flush();
                        f.Close();
                    }
                }
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    sw.WriteLine(Message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch// (Exception ex)
            {
                //throw new Exception("[FILEUtil.FileWrite]" + ex.Message);
            }
            finally
            {
                BackLogLock.ReleaseMutex();
            }
        }
    }

    public class HashTable
    {
        public string LoadRequest(HttpRequest Request)
        {
            string Req = string.Empty;
            try
            {
                foreach (string K in Request.QueryString.AllKeys)
                {
                    if (String.IsNullOrEmpty(K)) continue;
                    Req += string.Format("{0}={1}", K, Request.QueryString[K].Trim());
                }

                foreach (string K in Request.Form.AllKeys)
                {
                    if (String.IsNullOrEmpty(K)) continue;
                    Req += string.Format("{0}={1}", K, Request.QueryString[K].Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[參數收集錯誤]" + ex.Message);
            }
            return Req;
        }
    }
}