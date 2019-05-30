using _02_06_2018.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_06_2018
{
    public partial class FrmFindYoutubeVideo : Form
    {
        public FrmFindYoutubeVideo()
        {
            InitializeComponent();
            txtVideoName.Focus();
        }

        private void btnFindVideos_Click(object sender, EventArgs e)
        {
            rtbVideos.Clear();
            rtbVideos.Focus();
            string videoName = txtVideoName.Text;
            YoutubeSearch search = new YoutubeSearch();
            List<VideoInfomation> videoList = search.SearchQuery(videoName, 1);
            foreach (var item in videoList)
            {
                rtbVideos.Text += item.Url + " " + item.Title + " " + item.Duration + "\n";
                
            }
            
        }

        private void rtbVideos_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Clipboard.SetText(e.LinkText);
        }
    }
}
