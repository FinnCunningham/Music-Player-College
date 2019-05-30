using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06_2018
{
    public class PlaylistClass
    {
        public bool SongEnded = true;
        WMPLib.WindowsMediaPlayer wPlayer;
        public int currentIndex { get; set; }
        public ArrayList SongsInPlaylist = new ArrayList();
        private System.Windows.Forms.Timer CheckSong;
        private System.ComponentModel.IContainer play_components;    

        public List<string> names = new List<string>();
        public bool changeLst = false;

        public PlaylistClass(WMPLib.WindowsMediaPlayer Player)
        {
            wPlayer = Player;
            currentIndex = 0;
            this.play_components = new System.ComponentModel.Container();
            this.CheckSong = new System.Windows.Forms.Timer(this.play_components);
            this.CheckSong.Tick += new System.EventHandler(this.CheckSong_Tick);
            wPlayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wPlayer_PlayStateChange);
            wPlayer.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wPlayer_PlayStateChange);
            //Play();
        }

        public void AddSong(string Song)
        {
            SongsInPlaylist.Add(Song);
            wPlayer.URL = Song;
            names.Add(wPlayer.currentMedia.name);
            
        }

        public void AddSongs(string[] Songs)
        {
            for (int i = 0; i < Songs.Length; i++)
                AddSong(Songs[i]);
            wPlayer.URL = "";
        }

        public void DeleteSong(string Song)
        {
            if (Song == SongsInPlaylist[currentIndex].ToString())
            {
                wPlayer.controls.stop();
                currentIndex--;
            }
            SongsInPlaylist.Remove(Song);
            wPlayer.controls.play();
        }

        public void DeletePlaylist()
        {
            wPlayer.controls.stop();
            SongsInPlaylist.Clear();
            currentIndex = 0;
        }

        public void Play()
        {
            if (SongsInPlaylist[currentIndex] != null)
                wPlayer.URL = SongsInPlaylist[currentIndex].ToString();
            
           
        }

        public void Play(int Slot)
        {
            if (SongsInPlaylist[Slot - 1] != null)
                wPlayer.URL = SongsInPlaylist[Slot - 1].ToString();
        }

        public void Play(string name)
        {
            int slot = SongsInPlaylist.BinarySearch(name, null);
            if (slot >= 0 && slot < SongsInPlaylist.Count)
                wPlayer.URL = SongsInPlaylist[slot].ToString();
        }

        public void Pause()
        {
            wPlayer.controls.pause();
        }

        public void Stop()
        {
            wPlayer.controls.stop();
        }

        public void NextSong()
        {
            if (currentIndex != SongsInPlaylist.Count - 1 )
            {
                currentIndex++;
                wPlayer.controls.stop();
                wPlayer.URL = SongsInPlaylist[currentIndex].ToString();
                wPlayer.controls.play();
            }
            else
            {
                currentIndex = 0;
                wPlayer.controls.stop();
                wPlayer.URL = SongsInPlaylist[0].ToString();
                wPlayer.controls.play();
            }
        }

        public void PrevSong()
        {
            if (currentIndex != 0 )
            {
                currentIndex--;
                wPlayer.controls.stop();
                wPlayer.URL = SongsInPlaylist[currentIndex].ToString();
                wPlayer.controls.play();
            }
            else
            {
                currentIndex = SongsInPlaylist.Count - 1;
                wPlayer.controls.stop();
                wPlayer.URL = SongsInPlaylist[currentIndex].ToString();
                wPlayer.controls.play();
            }
        }

        private void CheckSong_Tick(object sender, System.EventArgs e)
        {
            if (SongEnded)
            {
                NextSong();
                SongEnded = false;
                CheckSong.Stop();
            }
        }

        public void wPlayer_PlayStateChange(int NewState)
        {
            switch (wPlayer.playState)
            {
                case WMPLib.WMPPlayState.wmppsMediaEnded:
                    SongEnded = true;
                    changeLst = true;
                    CheckSong.Start();
                    break;
                default:
                    break;
            }
        }
    }
}

