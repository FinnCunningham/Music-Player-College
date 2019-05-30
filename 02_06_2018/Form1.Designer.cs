namespace _02_06_2018
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPlay = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.songLengthBar = new System.Windows.Forms.TrackBar();
            this.lblLengthStart = new System.Windows.Forms.Label();
            this.lblLengthEnd = new System.Windows.Forms.Label();
            this.musicTimer = new System.Windows.Forms.Timer(this.components);
            this.lstBoxSongs = new System.Windows.Forms.ListBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLocalMusic = new System.Windows.Forms.Button();
            this.btnAddSongs = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.lblPlaylists = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songLengthBar)).BeginInit();
            this.middlePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(458, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(64, 45);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPlay_Paint);
            // 
            // volumeBar
            // 
            this.volumeBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.volumeBar.Location = new System.Drawing.Point(970, 19);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(126, 45);
            this.volumeBar.TabIndex = 4;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // songLengthBar
            // 
            this.songLengthBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.songLengthBar.LargeChange = 50;
            this.songLengthBar.Location = new System.Drawing.Point(363, 49);
            this.songLengthBar.Name = "songLengthBar";
            this.songLengthBar.Size = new System.Drawing.Size(391, 45);
            this.songLengthBar.TabIndex = 5;
            this.songLengthBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.songLengthBar.Scroll += new System.EventHandler(this.songLengthBar_Scroll);
            // 
            // lblLengthStart
            // 
            this.lblLengthStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLengthStart.AutoSize = true;
            this.lblLengthStart.Location = new System.Drawing.Point(330, 53);
            this.lblLengthStart.Name = "lblLengthStart";
            this.lblLengthStart.Size = new System.Drawing.Size(0, 13);
            this.lblLengthStart.TabIndex = 6;
            // 
            // lblLengthEnd
            // 
            this.lblLengthEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLengthEnd.AutoSize = true;
            this.lblLengthEnd.Location = new System.Drawing.Point(760, 51);
            this.lblLengthEnd.Name = "lblLengthEnd";
            this.lblLengthEnd.Size = new System.Drawing.Size(0, 13);
            this.lblLengthEnd.TabIndex = 7;
            // 
            // musicTimer
            // 
            this.musicTimer.Enabled = true;
            this.musicTimer.Tick += new System.EventHandler(this.musicTimer_Tick);
            // 
            // lstBoxSongs
            // 
            this.lstBoxSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.lstBoxSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxSongs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstBoxSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxSongs.ForeColor = System.Drawing.Color.White;
            this.lstBoxSongs.FormattingEnabled = true;
            this.lstBoxSongs.HorizontalScrollbar = true;
            this.lstBoxSongs.IntegralHeight = false;
            this.lstBoxSongs.ItemHeight = 25;
            this.lstBoxSongs.Location = new System.Drawing.Point(246, 126);
            this.lstBoxSongs.Name = "lstBoxSongs";
            this.lstBoxSongs.Size = new System.Drawing.Size(882, 553);
            this.lstBoxSongs.TabIndex = 8;
            this.lstBoxSongs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBoxSongs_DrawItem);
            this.lstBoxSongs.SelectedIndexChanged += new System.EventHandler(this.lstBoxSongs_SelectedIndexChanged);
            this.lstBoxSongs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstBoxSongs_MouseDown);
            this.lstBoxSongs.MouseHover += new System.EventHandler(this.lstBoxSongs_MouseHover);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(528, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 45);
            this.btnNext.TabIndex = 9;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.BackgroundImage")));
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(388, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(64, 45);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // middlePanel
            // 
            this.middlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.middlePanel.Controls.Add(this.lblPlaylistName);
            this.middlePanel.Controls.Add(this.lstBoxSongs);
            this.middlePanel.Location = new System.Drawing.Point(0, 30);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(1187, 758);
            this.middlePanel.TabIndex = 12;
            // 
            // lblPlaylistName
            // 
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistName.ForeColor = System.Drawing.Color.White;
            this.lblPlaylistName.Location = new System.Drawing.Point(230, 46);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(112, 45);
            this.lblPlaylistName.TabIndex = 9;
            this.lblPlaylistName.Text = "label1";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.bottomPanel.Controls.Add(this.lblNowPlaying);
            this.bottomPanel.Controls.Add(this.songLengthBar);
            this.bottomPanel.Controls.Add(this.btnPrev);
            this.bottomPanel.Controls.Add(this.btnPlay);
            this.bottomPanel.Controls.Add(this.btnNext);
            this.bottomPanel.Controls.Add(this.volumeBar);
            this.bottomPanel.Controls.Add(this.lblLengthStart);
            this.bottomPanel.Controls.Add(this.lblLengthEnd);
            this.bottomPanel.Location = new System.Drawing.Point(0, 709);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1190, 79);
            this.bottomPanel.TabIndex = 0;
            // 
            // lblNowPlaying
            // 
            this.lblNowPlaying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNowPlaying.AutoSize = true;
            this.lblNowPlaying.Location = new System.Drawing.Point(36, 31);
            this.lblNowPlaying.Name = "lblNowPlaying";
            this.lblNowPlaying.Size = new System.Drawing.Size(0, 13);
            this.lblNowPlaying.TabIndex = 11;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.Location = new System.Drawing.Point(0, 510);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(197, 199);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1160, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.Location = new System.Drawing.Point(1124, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(30, 26);
            this.btnMax.TabIndex = 12;
            this.btnMax.Text = "□";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(1088, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 27);
            this.btnMin.TabIndex = 13;
            this.btnMin.Text = "-";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnLocalMusic);
            this.flowLayoutPanel1.Controls.Add(this.btnAddSongs);
            this.flowLayoutPanel1.Controls.Add(this.btnAddFolder);
            this.flowLayoutPanel1.Controls.Add(this.btnCreatePlaylist);
            this.flowLayoutPanel1.Controls.Add(this.lblPlaylists);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 488);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseDown);
            // 
            // btnLocalMusic
            // 
            this.btnLocalMusic.FlatAppearance.BorderSize = 0;
            this.btnLocalMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalMusic.ForeColor = System.Drawing.Color.White;
            this.btnLocalMusic.Location = new System.Drawing.Point(3, 3);
            this.btnLocalMusic.Name = "btnLocalMusic";
            this.btnLocalMusic.Size = new System.Drawing.Size(175, 43);
            this.btnLocalMusic.TabIndex = 5;
            this.btnLocalMusic.Text = "Local Music";
            this.btnLocalMusic.UseVisualStyleBackColor = true;
            this.btnLocalMusic.Click += new System.EventHandler(this.btnLocalMusic_Click);
            // 
            // btnAddSongs
            // 
            this.btnAddSongs.FlatAppearance.BorderSize = 0;
            this.btnAddSongs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSongs.ForeColor = System.Drawing.Color.White;
            this.btnAddSongs.Location = new System.Drawing.Point(3, 52);
            this.btnAddSongs.Name = "btnAddSongs";
            this.btnAddSongs.Size = new System.Drawing.Size(175, 43);
            this.btnAddSongs.TabIndex = 0;
            this.btnAddSongs.Text = "Add songs";
            this.btnAddSongs.UseVisualStyleBackColor = true;
            this.btnAddSongs.Click += new System.EventHandler(this.btnAddSongs_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddFolder.FlatAppearance.BorderSize = 0;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFolder.ForeColor = System.Drawing.Color.White;
            this.btnAddFolder.Location = new System.Drawing.Point(3, 101);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(175, 43);
            this.btnAddFolder.TabIndex = 2;
            this.btnAddFolder.Text = "Add music from folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCreatePlaylist.FlatAppearance.BorderSize = 0;
            this.btnCreatePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnCreatePlaylist.Location = new System.Drawing.Point(3, 150);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(175, 43);
            this.btnCreatePlaylist.TabIndex = 1;
            this.btnCreatePlaylist.Text = "Create Playlist";
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // lblPlaylists
            // 
            this.lblPlaylists.AutoSize = true;
            this.lblPlaylists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylists.ForeColor = System.Drawing.Color.White;
            this.lblPlaylists.Location = new System.Drawing.Point(3, 196);
            this.lblPlaylists.Name = "lblPlaylists";
            this.lblPlaylists.Size = new System.Drawing.Size(65, 20);
            this.lblPlaylists.TabIndex = 4;
            this.lblPlaylists.Text = "Playlists";
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(51)))), ((int)(((byte)(66)))));
            this.leftPanel.Controls.Add(this.btnSettings);
            this.leftPanel.Controls.Add(this.pbImage);
            this.leftPanel.Controls.Add(this.flowLayoutPanel1);
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(199, 709);
            this.leftPanel.TabIndex = 11;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(6, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1190, 788);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.middlePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 726);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songLengthBar)).EndInit();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.TrackBar songLengthBar;
        private System.Windows.Forms.Label lblLengthStart;
        private System.Windows.Forms.Label lblLengthEnd;
        private System.Windows.Forms.Timer musicTimer;
        private System.Windows.Forms.ListBox lstBoxSongs;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddSongs;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.Label lblPlaylists;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLocalMusic;
    }
}

