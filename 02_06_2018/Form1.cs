using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _02_06_2018
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer wPlayer = new WMPLib.WindowsMediaPlayer();
        bool playQ = false;
        string duration;
        string name;
        PlaylistClass playlistClass;
        //public string playlistName;
        string songTitle;
        string playlistPath;
        string programPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string currentPlaylist = @"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Playlists\playlist";
        List<string> playlists = new List<string>();
        static string lstbackColor = "#223747";
        static string selectedTextColor = "#00c41d";
        static string textCol = "#ffffff";
        string colorType = "Normal mode";
        List<string> folder;
        List<string> newUrls;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Music Player";
            lblPlaylistName.Text = "Local songs";

            this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts

            this.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 + 80);
            init();
            addSongs();
            /*Updates
             * Create a Settings file to keep data when it runs next
             * Optimisations
             * 
             */




            //playlistPath = @"C:\Users\Finn\Music\MusicPlayer\Playlist";
            //buttonColorChange();
        }

        private void init()
        {
            //Classes.SSHAccess access = new Classes.SSHAccess();
            //access.connect();
            string PcName = Environment.UserName;
            //Create folder music player
            string subPath = @"C:\Users\" + PcName + @"\Music\MusicPlayer"; // your code goes here
            bool exists = System.IO.Directory.Exists(subPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            playlistPath = @"C:\Users\" + PcName + @"\Music\MusicPlayer\Playlist"; // your code goes here
            bool playlistPathExists = System.IO.Directory.Exists(playlistPath);
            if (!playlistPathExists)
                System.IO.Directory.CreateDirectory(playlistPath);

            //foreach (Control ctrl in flowLayoutPanel1.Controls)
            //    if (ctrl.GetType() == typeof(VScrollBar))
            //        ctrl.Width = 10;

            //DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Playlists\");
            //DirectoryInfo directory = new DirectoryInfo(@"F:\Visual_Studio_Projects\improved\a_Improved\02_06_2018\02_06_2018\Playlists\");
            DirectoryInfo directory = new DirectoryInfo(playlistPath);
            FileInfo[] files = directory.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                playlists.Add(files[i].Name);
            }


            playlistClass = new PlaylistClass(wPlayer);
            musicTimer.Enabled = false;
            songLengthBar.Minimum = 0;
            songLengthBar.Maximum = 100;
            volumeBar.Minimum = 0;
            volumeBar.Maximum = 100;
            volumeBar.Value = 25;

            wPlayer.settings.volume = volumeBar.Value;

            createButton();

            int horizontalMargin = (int)(0.5 * (this.flowLayoutPanel1.Width - this.lblPlaylists.Width));
            this.lblPlaylists.Margin = new Padding(horizontalMargin, 0, horizontalMargin, 0);
        }

        private void addSongs()
        {
            ArrayList tempUrl;
            string PcName = Environment.UserName;


            //tempUrl = DirSearch(@"C:\Users\" + PcName + @"\Music");
            tempUrl = SearchAccessibleFiles(@"C:\Users\" + PcName + @"\Music", ".mp3");
            folder = new List<string>();
            string[] urls = (string[])tempUrl.ToArray(typeof(string));
           newUrls = new List<string>();
            foreach (var item in urls)
            {
                string tempFolder = Path.GetFileName(Path.GetDirectoryName(item));
                if (!folder.Contains(tempFolder))
                {
                    if (tempFolder == "MusicDownloads")
                    {
                        tempFolder = @"MusicPlayer\MusicDownloads";
                    }
                    folder.Add(tempFolder);
                }

                //  folder.Add(item.Substring(0, urls.Length));
            }
            folder = folder.Distinct().ToList();
            if (folder.Count != 0)
            {
                using (frmMusicFolders musicFolders = new frmMusicFolders(folder))
                {
                    musicFolders.ShowDialog(this);
                    folder = musicFolders.foldersAccepted;
                }
                tempUrl.Clear();
                for (int i = 0; i < folder.Count; i++)
                {
                    string tempPath = @"C:\Users\" + PcName + @"\Music\" + folder[i];
                    tempUrl = DirSearch(tempPath);
                    var files = Directory.EnumerateFiles(tempPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".mp3") /*|| s.EndsWith(".jpg")*/);
                    var list = new List<string>(files);
                    foreach (string item in list)
                    {
                        newUrls.Add(item);
                    }

                }
                string[] newurlsArray;
                newurlsArray = newUrls.ToArray();
                playlistClass.AddSongs(newurlsArray);
                for (int i = 0; i < playlistClass.SongsInPlaylist.Count; i++)
                {
                    lstBoxSongs.Items.Add(playlistClass.names[i]);
                }
                wPlayer.settings.autoStart = false;

                playlistClass.Play();
            }

            lblPlaylistName.Text = "Local songs";
        }

        private void addLocalSongs()
        {
            playlistClass.SongsInPlaylist.Clear();
            playlistClass.names.Clear();
            newUrls.Clear();
            lstBoxSongs.Items.Clear();
            string PcName = Environment.UserName;
            if (folder.Count != 0)
            {
                for (int i = 0; i < folder.Count; i++)
                {
                    string tempPath = @"C:\Users\" + PcName + @"\Music\" + folder[i];
                    //tempUrl = DirSearch(tempPath);
                    var files = Directory.EnumerateFiles(tempPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".mp3") /*|| s.EndsWith(".jpg")*/);
                    var list = new List<string>(files);
                    foreach (string item in list)
                    {
                        newUrls.Add(item);
                    }

                }
                string[] newurlsArray;
                newurlsArray = newUrls.ToArray();
                playlistClass.AddSongs(newurlsArray);
                for (int i = 0; i < playlistClass.SongsInPlaylist.Count; i++)
                {
                    lstBoxSongs.Items.Add(playlistClass.names[i]);
                }
                wPlayer.settings.autoStart = false;

                playlistClass.Play();
            }
        }

        private void createButton()
        {
            flowLayoutPanel1.VerticalScroll.Enabled = true;
            flowLayoutPanel1.VerticalScroll.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(btnAddSongs);
            flowLayoutPanel1.Controls.Add(btnAddFolder);
            flowLayoutPanel1.Controls.Add(btnCreatePlaylist);
            flowLayoutPanel1.Controls.Add(lblPlaylists);
            int buttonNum = 80;
            string finalValue = "";
            playlists.Clear();
            DirectoryInfo directory = new DirectoryInfo(playlistPath);
            FileInfo[] files = directory.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                playlists.Add(files[i].Name);
            }
            for (int i = 0; i < playlists.Count; i++)
            {
                finalValue = playlists[i];
                buttonNum += 80;
                Button b = new Button();
                b.ForeColor = ColorTranslator.FromHtml(textCol);

                b.Text = playlists[i].Substring(0, playlists[i].Length - 4);
                b.Location = new Point(3, 185 + buttonNum);
                b.Size = new Size(175, 43);
                b.Font = new Font("Arial", 12);
                b.FlatAppearance.BorderSize = 0;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //b.Click += new EventHandler(openPlaylist_click);
                //string singleName = playlists[i];

                //name sends the index of the button since the name is an index.
                //b.Click += new EventHandler((sender2, e2) => openPlaylist_click(sender2, e2));
                b.Click += new EventHandler((sender2, e2) => openPlaylist_click(sender2, e2));
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        //private void buttonColorChange()
        //{
        //    btnAddFolder.MouseEnter += OnMouseEnterButton1;
        //    btnAddFolder.MouseLeave += OnMouseLeaveButton1;
        //}

        private void getImage()
        {

            LastFmAlbumArt art = new LastFmAlbumArt();
            TagLib.File tagFile = TagLib.File.Create(playlistClass.SongsInPlaylist[playlistClass.currentIndex].ToString());
            songTitle = tagFile.Tag.Title;
            string[] songArtists = tagFile.Tag.Performers;
            string urlName = songTitle + " " + String.Join(" ", songArtists);


            string html = art.GetHtmlCode(urlName);
            List<string> urls = art.GetUrls(html);
            if (art.skipQ == false)
            {
                string luckyUrl = urls[0];

                byte[] image = art.GetImage(luckyUrl);
                if (image != null)
                {
                    using (var ms = new MemoryStream(image))
                    {
                        pbImage.Image = Image.FromStream(ms);
                    }
                }
                //pbImage.Image.Size = new Size(197, 199);
                pbImage.BackgroundImageLayout = ImageLayout.Zoom;
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                string urlNameTemp = "6ix9ine album";
                string htmlTemp = art.GetHtmlCode(urlNameTemp);
                List<string> urlsTemp = art.GetUrls(htmlTemp);
                string luckyUrl = urlsTemp[0];

                byte[] image = art.GetImage(luckyUrl);
                if (image != null)
                {
                    using (var ms = new MemoryStream(image))
                    {
                        pbImage.Image = Image.FromStream(ms);
                    }
                }
                //pbImage.Image.Size = new Size(197, 199);
                pbImage.BackgroundImageLayout = ImageLayout.Zoom;
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;

            }


        }

        private void openPlaylist_click(object sender, EventArgs e)
        {

            string playlistNameTemp = (sender as Button).Text;
            //add delete playlist
            //string[] lines = File.ReadAllLines(usbPath + @"\Playlists\" + playlistNameTemp + ".txt");
            string[] lines = File.ReadAllLines(playlistPath + @"\" + playlistNameTemp + ".txt");
            foreach (var line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            if (lines.Count() != 0)
            {
                changeSongs(lines);
            }
            else
            {
                playlistClass.DeletePlaylist();
                playlistClass.names.Clear();
                lstBoxSongs.Items.Clear();

            }
            //removes the .txt
            lblPlaylistName.Text = playlistNameTemp;

            //if ()
            //{

            //}

        }

        private void changeSongs(string[] songs)
        {
            playlistClass.DeletePlaylist();
            playlistClass.names.Clear();
            playlistClass.AddSongs(songs);
            lstBoxSongs.Items.Clear();
            for (int i = 0; i < songs.Count(); i++)
            {
                lstBoxSongs.Items.Add(playlistClass.names[i]);
            }
            wPlayer.URL = playlistClass.SongsInPlaylist[0].ToString();
        }

        private void sendData()
        {
            Song song = new Song(wPlayer.currentMedia.name, wPlayer.currentMedia.durationString);
            name = song.SongName;
            duration = song.SongFullDuration;
            lblLengthEnd.Text = duration;
            lblNowPlaying.Text = wPlayer.currentMedia.name;
            lblNowPlaying.ForeColor = ColorTranslator.FromHtml(textCol);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            playSong();
        }



        private void playSong()
        {
            //double maxVal = max();


            if (playQ == false && lstBoxSongs.Items.Count != 0)
            {
                //btnPlay.BackgroundImage = Image.FromFile(@"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Icons\pauseIcon.png");
                btnPlay.BackgroundImage = Resource1.pauseIcon;
                //btnPlay.BackgroundImage = Image.FromFile(programPath + @"\Icons\pauseIcon.png");
                musicTimer.Enabled = true;

                wPlayer.controls.currentPosition = songLengthBar.Value;

                wPlayer.controls.play();
                playQ = true;
                lstBoxSongs.SetSelected(playlistClass.currentIndex, true);
                getImage();
                sendData();
            }

            else
            {
                //btnPlay.BackgroundImage = Image.FromFile(@"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Icons\play.ico");
                btnPlay.BackgroundImage = Resource1.playIcon;
                //btnPlay.BackgroundImage = Image.FromFile(programPath + @"\Icons\play.ico");
                wPlayer.controls.pause();
                playQ = false;
                sendData();
            }
            
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            wPlayer.settings.volume = volumeBar.Value;
        }

        private void musicTimer_Tick(object sender, EventArgs e)
        {
            if (wPlayer.currentMedia != null)
            {
                songLengthBar.Maximum = (int)wPlayer.controls.currentItem.duration;
                lblLengthStart.Text = wPlayer.controls.currentPositionString;
                double percent = ((double)wPlayer.controls.currentPosition / wPlayer.controls.currentItem.duration);
                try
                {
                    songLengthBar.Value = (int)(percent * songLengthBar.Maximum);
                }
                catch (Exception)
                {
                    //sometimes it fails on the first loop
                }

            }
            if (duration == "00:00")
            {
                sendData();
            }

            if (playlistClass.changeLst == true)
            {
                sendData();
                lstBoxSongs.SetSelected(playlistClass.currentIndex, true);
                playlistClass.changeLst = false;
            }

        }

        private void songLengthBar_Scroll(object sender, EventArgs e)
        {
            wPlayer.controls.currentPosition = songLengthBar.Value;
        }

        ArrayList SearchAccessibleFiles(string root, string searchTerm)
        {
            var files = new ArrayList();

            foreach (var file in Directory.EnumerateFiles(root).Where(m => m.Contains(searchTerm)))
            {
                files.Add(file);
            }
            foreach (var subDir in Directory.EnumerateDirectories(root))
            {
                try
                {
                    files.AddRange(SearchAccessibleFiles(subDir, searchTerm));
                }
                catch (UnauthorizedAccessException ex)
                {
                    // ...
                }
            }

            return files;
        }

        public static ArrayList DirSearch(string sDir)
        {
            ArrayList fileList = new ArrayList();
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, "*.mp3"))
                    {
                        string extension = Path.GetExtension(f);
                        if (extension != null && (extension.Equals(".mp3")))
                        {
                            fileList.Add(f);
                        }
                    }
                    DirSearch(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return fileList;
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            int count = playlistClass.SongsInPlaylist.Count - 1;
            int maxVal = playlistClass.SongsInPlaylist.Count - 1;
            if (playlistClass.currentIndex != maxVal && playlistClass.currentIndex != 0)
            {
                TagLib.File tagFile = TagLib.File.Create(playlistClass.SongsInPlaylist[playlistClass.currentIndex + 1].ToString());
                songTitle = tagFile.Tag.Title;
            }

            if (playlistClass.currentIndex != count && lstBoxSongs.Items.Count != 0)
            {
                playlistClass.NextSong();
                lstBoxSongs.SetSelected(playlistClass.currentIndex, true);
                btnPlay.BackgroundImage = Resource1.pauseIcon;
                //btnPlay.BackgroundImage = Image.FromFile(programPath + @"\Icons\pauseIcon.png");
                sendData();
                getImage();
            }
            else
            {

            }
            //btnPlay.BackgroundImage = Image.FromFile(@"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Icons\pauseIcon.png");

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int count = playlistClass.SongsInPlaylist.Count - 1;

            int maxVal = playlistClass.SongsInPlaylist.Count - 1;
            if (playlistClass.currentIndex != maxVal && playlistClass.currentIndex != 0)
            {
                TagLib.File tagFile = TagLib.File.Create(playlistClass.SongsInPlaylist[playlistClass.currentIndex + 1].ToString());
                songTitle = tagFile.Tag.Title;
            }

            if (playlistClass.currentIndex != 0 && lstBoxSongs.Items.Count != 0)
            {
                playlistClass.PrevSong();

                lstBoxSongs.SetSelected(playlistClass.currentIndex, true);
                //btnPlay.BackgroundImage = Image.FromFile(@"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Icons\pauseIcon.png");
                btnPlay.BackgroundImage = Resource1.pauseIcon;
                // btnPlay.BackgroundImage = Image.FromFile(programPath + @"\Icons\pauseIcon.png");
                //needs to send data after changing song to know what the duration is.
                sendData();
                getImage();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNowPlaying.ForeColor = Color.White;
            lblNowPlaying.Font = new Font("Arial", 12);
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            //flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.VerticalScroll.Visible = true;            
            
            flowLayoutPanel1.VerticalScroll.Enabled = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = false;
            //flowLayoutPanel1.VerticalScroll.Maximum = flowLayoutPanel1.Height;
        }

        private void lstBoxSongs_MouseHover(object sender, EventArgs e)
        {
            Point point = lstBoxSongs.PointToClient(Cursor.Position);
            int index = lstBoxSongs.IndexFromPoint(point);
            if (index < 0) return;
            ////Do any action with the item
            lstBoxSongs.GetItemRectangle(index).Inflate(10, 20);



        }

        //this is draw the background of listbox items a diffrent colour since listboxs are awkward
        //this one is selection color
        static Color selectedCol = ColorTranslator.FromHtml(selectedTextColor);

        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(selectedCol);
        private SolidBrush reportsForegroundBrush = new SolidBrush(ColorTranslator.FromHtml(textCol));
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.Red);
        private SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.Gray);
        private void lstBoxSongs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                Color selectedCol = ColorTranslator.FromHtml(selectedTextColor);
                reportsForegroundBrushSelected = new SolidBrush(selectedCol);
                reportsForegroundBrush = new SolidBrush(ColorTranslator.FromHtml(textCol));

                int index = e.Index;
                string text = lstBoxSongs.Items[index].ToString();
                bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
                e.DrawBackground();
                Graphics g = e.Graphics;
                Color col = ColorTranslator.FromHtml(lstbackColor);
                lstBoxSongs.BackColor = col;
                g.FillRectangle(new SolidBrush(col), e.Bounds);

                //Color borderColor = Color.Black;
                //g.DrawLine(new Pen(borderColor), new Point(e.Bounds.Left, e.Bounds.Bottom), new Point(e.Bounds.Right, e.Bounds.Bottom));
                string test = textCol;
                // Print text
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, lstBoxSongs.GetItemRectangle(index).Location);
                e.DrawFocusRectangle();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        bool maxSize = false;
        private void btnMax_Click(object sender, EventArgs e)
        {

            if (maxSize == true)
            {
                this.WindowState = FormWindowState.Normal;
                maxSize = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                maxSize = true;
            }


        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddSongs_Click(object sender, EventArgs e)
        {
            bool newQ = false;
            string[] songs = { "" };
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            songs = openFileDialog1.FileNames;
                            newQ = true;

                        }
                    }
                    else
                    {
                        newQ = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


            if (newQ == true)
            {
                lblPlaylistName.Text = "Local songs";
                changeSongs(songs);

            }


        }
        string pathPlaylist = "";
        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            string playlistName = "";
            //frmCreatePlaylist create = new frmCreatePlaylist();
            using (frmCreatePlaylist create = new frmCreatePlaylist())
            {
                create.ShowDialog();
                playlistName = create.playlistName;
            }
            if (playlistName != "" && !string.IsNullOrEmpty(playlistName))
            {
                //pathPlaylist = @"C:\Users\Finn\Documents\Visual Studio 2017\Projects\02_06_2018\02_06_2018\Playlists\" + playlistName;
                //pathPlaylist = usbPath + @"\Playlists\" + playlistName + ".txt";
                pathPlaylist = playlistPath + @"\" + playlistName + ".txt";
                currentPlaylist = pathPlaylist;
            }

            if (!File.Exists(pathPlaylist) && playlistName != "" && playlistName != " " && playlistName != null)
            {
                currentPlaylist = pathPlaylist;
                playlists.Add(playlistName);
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathPlaylist))
                {

                }

            }
            createButton();

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var files = Directory.EnumerateFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".mp3") /*|| s.EndsWith(".jpg")*/);
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);

                    var list = new List<string>(files);

                    //string.Join(",", Encoding.Unicode.GetBytes("10.10.10.11").Select(x => x.ToString("X2")).ToArray());


                    //list.RemoveAll(item => item.Contains("AlbumArt"));
                    //list.Remove("AlbumArt");
                    string[] newFiles;
                    newFiles = list.ToArray();
                    changeSongs(newFiles);


                }
            }


        }
        int songTo;
        private void lstBoxSongs_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right))
            {
                lstBoxSongs.SelectedIndex = lstBoxSongs.IndexFromPoint(e.X, e.Y);
                songTo = lstBoxSongs.IndexFromPoint(e.X, e.Y);
                ContextMenu menu = new ContextMenu();

                //menu.MenuItems.Add("Add To Playlist", new EventHandler(addToPlaylist_Click));

                MenuItem playlistChoice = new MenuItem("Add To Playlist");
                MenuItem removeFromPlaylist = new MenuItem("Delete From Playlist");

                for (int i = 0; i < playlists.Count; i++)
                {
                    MenuItem itemAdd = new MenuItem(playlists[i].Substring(0, playlists[i].Length - 4), (sender2, e2) => addToPlaylist_Click(sender2, e2));
                    MenuItem itemRemove = new MenuItem(playlists[i].Substring(0, playlists[i].Length - 4), (sender2, e2) => removeFromPlaylist_Click(sender2, e2));
                    playlistChoice.MenuItems.Add(itemAdd);
                    removeFromPlaylist.MenuItems.Add(itemRemove);
                    //playlistChoice.MenuItems.Add(itemDelete);

                }

                menu.MenuItems.Add(playlistChoice);

                menu.MenuItems.Add(removeFromPlaylist);
                lstBoxSongs.ContextMenu = menu;
            }
            else if (e.Button == MouseButtons.Left)
            {
                lstBoxSongs.SelectedIndex = lstBoxSongs.IndexFromPoint(e.X, e.Y);
                int songIndex;

                songIndex = lstBoxSongs.IndexFromPoint(e.X, e.Y);
                if (songIndex != -1)
                {
                    playlistClass.currentIndex = songIndex;
                    playlistClass.Play();
                    //btnPlay.BackgroundImage = Image.FromFile(programPath + @"\Icons\pauseIcon.png");
                    btnPlay.BackgroundImage = Resource1.pauseIcon;

                    musicTimer.Enabled = true;
                    songLengthBar.Value = 0;
                    wPlayer.controls.currentPosition = songLengthBar.Value;

                    wPlayer.controls.play();
                    playQ = true;
                    lstBoxSongs.SetSelected(playlistClass.currentIndex, true);
                    getImage();
                    sendData();
                }


            }
        }

        private void removeFromPlaylist_Click(object sender2, EventArgs e2)
        {
            string playlistNameTemp = (sender2 as MenuItem).Text;
            string[] lines = File.ReadAllLines(playlistPath + @"\" + playlistNameTemp + ".txt");
            if (lines.Count() != 0)
            {

                string fileName = playlistPath + @"\" + playlistNameTemp;
                string line = playlistClass.SongsInPlaylist[songTo].ToString();
                //string line = File.ReadLines(fileName).Skip(1).Take(1).First();
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(fileName + ".txt").Where(l => l != line);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(fileName);
                File.Move(tempFile, fileName);
            }

        }

        private void addToPlaylist_Click(object sender, EventArgs e)
        {
            //this gets the text of the object event
            string playlistNameTemp = (sender as MenuItem).Text;
            //later let the user pick playList from all the playlist files.
            string tempPlaylistPath = playlistPath + @"\" + playlistNameTemp + ".txt";
            using (StreamWriter sw = File.AppendText(tempPlaylistPath))
            {
                sw.WriteLine(playlistClass.SongsInPlaylist[songTo].ToString());
            }
            //make a button to choose what playlist to show.

        }


        private void btnSettings_Click(object sender, EventArgs e)
        {

            wPlayer.controls.stop();
            foreach (Control control in this.Controls)
            {
                control.Hide();
            }
            btnClose.Show();
            btnMax.Show();
            btnMin.Show();


            Classes.Settings settings = new Classes.Settings();
            Panel settingpanel = settings.PanelMeth(lstbackColor, ClientSize.Width, ClientSize.Height);
            Controls.Add(settingpanel);

            RadioButton rdoNormal = settings.RadioButtonMeth("Normal mode", textCol, ClientSize.Width, 100);
            settingpanel.Controls.Add(rdoNormal);
            rdoNormal.CheckedChanged += new EventHandler((sender1, e1) => { colorType = rdoNormal.Text; });

            RadioButton rdoLight = settings.RadioButtonMeth("Light mode", textCol, ClientSize.Width, 150);
            settingpanel.Controls.Add(rdoLight);
            rdoLight.CheckedChanged += new EventHandler((sender1, e1) => { colorType = rdoLight.Text; });

            RadioButton rdoDark = settings.RadioButtonMeth("Dark mode", textCol, ClientSize.Width, 200);
            rdoDark.CheckedChanged += new EventHandler((sender1, e1) => { colorType = rdoDark.Text; });
            settingpanel.Controls.Add(rdoDark);

            TextBox txtUrl = settings.TextBoxMeth(ClientSize.Width);
            txtUrl.Width = 250;
            settingpanel.Controls.Add(txtUrl);

            Button btnDownloadMusic = settings.ButtonMeth(textCol, ClientSize.Width, "Download MP3", 350);
            settingpanel.Controls.Add(btnDownloadMusic);
            btnDownloadMusic.Click += new EventHandler((sender2, e2) => btnDownloadMusic_click(sender2, e2));

            Button btnFindYoutubeVideo = settings.ButtonMeth(textCol, ClientSize.Width, "Find Youtube video", ClientSize.Height / 2);
            btnFindYoutubeVideo.Size = new Size(160,80);
            settingpanel.Controls.Add(btnFindYoutubeVideo);
            btnFindYoutubeVideo.Click += new EventHandler((sender2, e2) => btnFindYoutubeVideo_Click(sender2, e2));

            Button btnExitSettings = settings.ButtonMeth(textCol, ClientSize.Width, "Exit Settings", ClientSize.Height - 80);
            settingpanel.Controls.Add(btnExitSettings);

            txtUrl.TextChanged += new EventHandler((sender1, e1) => { btnDownloadMusic.Name = txtUrl.Text; });
            btnExitSettings.Click += new EventHandler((sender2, e2) => btnExitSettings_click(sender2, e2));

            foreach (Control control in settingpanel.Controls)
            {
                RadioButton radio = control as RadioButton;
                if (colorType == control.Text)
                {
                    radio.Checked = true;
                }
            }

        }

        private void btnFindYoutubeVideo_Click(object sender2, EventArgs e2)
        {
            FrmFindYoutubeVideo frmFind = new FrmFindYoutubeVideo();
            frmFind.Show();
            //this.Hide();
            //frmFind.Closed += (s, args) => this.Close();
            //frmFind.Show();
        }

        private void btnDownloadMusic_click(object sender2, EventArgs e2)
        {
            string url = (sender2 as Button).Name;

            if (!string.IsNullOrEmpty(url))
            {
                Classes.Settings settings = new Classes.Settings();
                Label lblDownloading = settings.LabelMeth(textCol, ClientSize.Width, "DOWNLOADING wait a couple of seconds!!!", ClientSize.Height - 200);
                lblDownloading.AutoSize = true;
                foreach (Control control in Controls)
                {
                    if (control is Panel)
                    {
                        control.Controls.Add(lblDownloading);
                    }
                }



                Classes.MusicDownload musicDown = new Classes.MusicDownload();
                string oldUrl = musicDown.youtubeDownload(url);
                //string name = musicDown.GetTitle(url);
                string newUrl = oldUrl;
                var replacements = new[]{
                     new{Find="Official Music",Replace=""},
                     new{Find="official music",Replace=""},
                     new{Find="Video",Replace=""},
                     new{Find="video",Replace=""},
                     new{Find="youtube",Replace=""},
                     new{Find="YouTube",Replace=""},
                     new{Find=" (",Replace=""},
                     new{Find=" )",Replace=""},
                     new{Find=".mp4",Replace=""}};

                foreach (var set in replacements)
                {
                    if (newUrl.Contains(set.Find))
                    {
                        newUrl = newUrl.Replace(set.Find, set.Replace);
                    }

                }
                bool newExists = File.Exists(newUrl);
                bool oldExists = File.Exists(oldUrl);
                if (!newExists && !oldExists)
                {
                    System.IO.File.Move(oldUrl, newUrl);
                }

                lblDownloading.ForeColor = Color.LimeGreen;
                lblDownloading.Text = "";
                
            }
        }

        private void btnExitSettings_click(object sender2, EventArgs e2)
        {
            if (colorType != null && colorType == "Dark mode")
            {
                changeColorMode("#262626", "#ffffff", "#ff0000", "#212121", "#262626", "#232323");
            }
            else if (colorType != null && colorType == "Normal mode")
            {
                changeColorMode("#223747", "#00c41d", "#ffffff", "#203342", "#223747", "#273d4f");
            }
            else if (colorType != null && colorType == "Light mode")
            {
                changeColorMode("#d0d6d8", "#f762ff", "#0296cc", "#c6ced1", "#d0d6d8", "#d6dadb");
            }

            foreach (Control control in this.Controls)
            {
                control.Show();
            }
            
            addLocalSongs();
        }

        private void changeColorMode(string listBackColor, string listSelectedColor, string textColor, string leftPanelColor, string middlePanelColor, string bottomPanelColor)
        {
            lstbackColor = listBackColor;
            selectedTextColor = listSelectedColor;
            textCol = textColor;
            leftPanel.BackColor = ColorTranslator.FromHtml(leftPanelColor);
            middlePanel.BackColor = ColorTranslator.FromHtml(middlePanelColor);
            this.BackColor = ColorTranslator.FromHtml(middlePanelColor);
            bottomPanel.BackColor = ColorTranslator.FromHtml(bottomPanelColor);
            createButton();
            btnSettings.ForeColor = ColorTranslator.FromHtml(textCol);
            foreach (Control control in this.Controls)
            {
                control.ForeColor = ColorTranslator.FromHtml(textCol);
            }
            foreach (Control flowControl in flowLayoutPanel1.Controls)
            {
                flowControl.ForeColor = ColorTranslator.FromHtml(textCol);
            }
            foreach (Control midControl in middlePanel.Controls)
            {
                midControl.ForeColor = ColorTranslator.FromHtml(textCol);

            }
            lstBoxSongs.BackColor = ColorTranslator.FromHtml(lstbackColor);
        }

        #region Form move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }


        }
        #endregion

        #region resize
        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int _ = 10;

        Rectangle tTop { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle lLeft { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void lstBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    int index = flowLayoutPanel1.TabIndex; 


            //    //lstBoxSongs.SelectedIndex = lstBoxSongs.IndexFromPoint(e.X, e.Y);
            //    //songTo = lstBoxSongs.IndexFromPoint(e.X, e.Y);
            //    //ContextMenu menu = new ContextMenu();

            //    ////menu.MenuItems.Add("Add To Playlist", new EventHandler(addToPlaylist_Click));

            //    //MenuItem playlistChoice = new MenuItem("Add To Playlist");
            //    //MenuItem removeFromPlaylist = new MenuItem("Delete From Playlist");

            //    //for (int i = 0; i < playlists.Count; i++)
            //    //{
            //    //    MenuItem itemAdd = new MenuItem(playlists[i].Substring(0, playlists[i].Length - 4), (sender2, e2) => addToPlaylist_Click(sender2, e2));
            //    //    MenuItem itemRemove = new MenuItem(playlists[i].Substring(0, playlists[i].Length - 4), (sender2, e2) => removeFromPlaylist_Click(sender2, e2));
            //    //    playlistChoice.MenuItems.Add(itemAdd);
            //    //    removeFromPlaylist.MenuItems.Add(itemRemove);
            //    //    //playlistChoice.MenuItems.Add(itemDelete);

            //    //}

            //    //menu.MenuItems.Add(playlistChoice);

            //    //menu.MenuItems.Add(removeFromPlaylist);
            //    //lstBoxSongs.ContextMenu = menu;
            //}
        }

        private void btnLocalMusic_Click(object sender, EventArgs e)
        {

            addLocalSongs();
        }

        Rectangle bBottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle rRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOPLEFT;
                }
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (tTop.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOP;
                }
                else if (lLeft.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (rRight.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (bBottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        #endregion

    }
}


