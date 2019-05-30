using MediaToolkit;
using MediaToolkit.Model;
using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;


namespace _02_06_2018.Classes
{
    public class MusicDownload
    {
        public string URL { get; set; }
        public string DestinationFolder { get; set; }

        public string youtubeDownload(string url)
        {
            URL = url;
            string PcName = Environment.UserName;

            string subPath = @"C:\Users\" + PcName + @"\Music\MusicPlayer\MusicDownloads\";
            bool exists = System.IO.Directory.Exists(subPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            DestinationFolder = subPath;
            var source = subPath;
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(url);
            File.WriteAllBytes(source + vid.FullName, vid.GetBytes());

            var inputFile = new MediaFile { Filename = source + vid.FullName };
            var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }

            return outputFile.Filename;
            //use this to edit the file name
        }

        public string GetTitle(string url)
        {
            var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
            return GetArgs(new WebClient().DownloadString(api), "title", '&');
        }

        public string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            return iqs == -1
                ? string.Empty
                : HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)[key];
        }



    }
}


