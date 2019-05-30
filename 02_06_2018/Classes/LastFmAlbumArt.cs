using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using DotLastFm;
using DotLastFm.Api;

namespace _02_06_2018
{
    class LastFmAlbumArt
    {
        public bool skipQ { get; set; }
        public string GetHtmlCode(string name)
        {
            skipQ = false;
            string url = "https://www.google.com/search?q=" + name + "&tbm=isch";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        public List<string> GetUrls(string html)
        {
            var urls = new List<string>();
            int ndx = html.IndexOf("class=\"images_table\"", StringComparison.Ordinal);
            try
            {
                ndx = html.IndexOf("<img", ndx, StringComparison.Ordinal);
            }
            catch{skipQ = true;}


            while (ndx >= 0)
            {
                ndx = html.IndexOf("src=\"", ndx, StringComparison.Ordinal);
                ndx = ndx + 5;
                int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                string url = html.Substring(ndx, ndx2 - ndx);
                urls.Add(url);
                ndx = html.IndexOf("<img", ndx, StringComparison.Ordinal);
            }
            return urls;
        }

        public byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000);

                    return bytes;
                }
            }

            // return null;
        }

        private void finish()
        {

        }

    }
}
