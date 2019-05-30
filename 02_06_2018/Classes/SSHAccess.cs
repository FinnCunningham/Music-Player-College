using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06_2018.Classes
{
    public class SSHAccess
    {
        public void connect()
        {
            string PcName = Environment.UserName;
            string ipAddress = "192.168.0.21";
            string username = "pi";
            string password = "flower";
            string sourcePath = @"/home/pi/Music/Dat stick.mp3";
            string destinationPath = @"C:\Users\" + PcName + @"\Music\NewMusic";

            bool exists = System.IO.Directory.Exists(destinationPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(destinationPath);

            var connectionInfo = new ConnectionInfo(ipAddress,
                                        username,
                                        new PasswordAuthenticationMethod(username, password));
                                        //new PrivateKeyAuthenticationMethod("rsa.key"));
            using (var client = new SftpClient(connectionInfo))
            {
                client.Connect();
                string info = client.WorkingDirectory;
                MemoryStream mem = new MemoryStream();
                //client.Open(sourcePath, FileMode.Open);
                using (Stream fileStream = File.Create(destinationPath))
                {
                    client.DownloadFile(sourcePath, fileStream);
                }
                
            }
            //Sftp ssh = new Sftp(ipAddress, username, password);
            //try
            //{
            //    ssh.Connect();
            //}
            //catch (Exception e)
            //{
            //    string error = e.Message;
                
            //}
            
            //ssh.Get(sourcePath, destinationPath);
            //ssh.Close();
        }

    }
}
