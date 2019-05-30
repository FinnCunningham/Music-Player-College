using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06_2018
{
    public class Song
    {
        public string SongName { get; set; }
        public string SongFullDuration { get; set; }

        public Song(string name, string fullDuration)
        {
            //use this class to hold the songs information
            //chnage when song finishes(research)
            SongName = name;
            SongFullDuration = fullDuration;
        }


    }
}