using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Net;
using System.Configuration;
using System.Net.Sockets;
using System.IO;

namespace Maticsoft.DBUtility
{
    public static class TcpHelper
    {
        private static readonly int port = int.Parse(ConfigurationManager.AppSettings["CommomPort"]);
        public static void SendMsg(string msg,string ipStr)
        {
            byte[] data=Encoding.UTF8.GetBytes(msg);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ipStr), port);
            TcpClient client = new TcpClient();
            NetworkStream nws=null;
            try
            {
                client.Connect(remoteEP);
                nws = client.GetStream();
                if (nws.CanWrite)
                {
                    nws.Write(data, 0, data.Length);
                }
                File.AppendAllText(@"D:\我的文档\Desktop\123.txt", "连接" + ipStr + ":" + port.ToString()+"成功\r\n");
            }
            catch
            {
                File.AppendAllText(@"D:\我的文档\Desktop\123.txt", "连接" + ipStr + ":" + port.ToString() + "失败\r\n");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }
    }
}