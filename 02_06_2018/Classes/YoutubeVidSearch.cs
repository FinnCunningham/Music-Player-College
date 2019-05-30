using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_06_2018.Classes
{
    class YoutubeSearch
    {

        //in the main form:
        //YoutubeSearch search = new YoutubeSearch();
        //List<VideoInfomation> videoList = search.SearchQuery("6ix9ine", 1);
        List<VideoInfomation> items;

        WebClient webclient;

        string title;
        string author;
        string description;
        string duration;
        string url;
        string thumbnail;

        public List<VideoInfomation> SearchQuery(string querystring, int querypages)
        {
            items = new List<VideoInfomation>();

            webclient = new WebClient();

            // Do search
            for (int i = 1; i <= querypages; i++)
            {
                // Search address
                string html = webclient.DownloadString("https://www.youtube.com/results?search_query=" + querystring + "&page=" + i);

                // Search string
                string pattern = "<div class=\"yt-lockup-content\">.*?title=\"(?<NAME>.*?)\".*?</div></div></div></li>";
                MatchCollection result = Regex.Matches(html, pattern, RegexOptions.Singleline);

                for (int ctr = 0; ctr <= result.Count - 1; ctr++)
                {
                    // Title
                    title = result[ctr].Groups[1].Value;

                    // Author
                    author = VideoItemHelper.cull(result[ctr].Value, "/user/", "class").Replace('"', ' ').TrimStart().TrimEnd();

                    // Description
                    description = VideoItemHelper.cull(result[ctr].Value, "dir=\"ltr\" class=\"yt-uix-redirect-link\">", "</div>");

                    // Duration
                    duration = VideoItemHelper.cull(VideoItemHelper.cull(result[ctr].Value, "id=\"description-id-", "span"), ": ", "<").Replace(".", "");

                    // Url
                    url = string.Concat("http://www.youtube.com/watch?v=", VideoItemHelper.cull(result[ctr].Value, "watch?v=", "\""));

                    // Thumbnail
                    thumbnail = "https://i.ytimg.com/vi/" + VideoItemHelper.cull(result[ctr].Value, "watch?v=", "\"") + "/mqdefault.jpg";

                    // Remove playlists
                    if (title != "__title__")
                    {
                        if (duration != "")
                        {
                            // Add item to list
                            items.Add(new VideoInfomation() { Title = title, Author = author, Description = description, Duration = duration, Url = url, Thumbnail = thumbnail, });
                        }
                    }
                }
            }

            return items;
        }
    }

    class VideoInfomation
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
    }

    public class VideoItemHelper
    {
        public static string cull(string strSource, string strStart, string strEnd)
        {
            int Start, End;

            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);

                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
