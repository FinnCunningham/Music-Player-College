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
    public partial class frmMusicFolders : Form
    {
        List<string> folderLocations;
        public List<string> foldersAccepted { get; set; }
        public frmMusicFolders(List<string> folders)
        {
            InitializeComponent();
            folderLocations = new List<string>(folders);
            foreach (string item in folders)
            {
                CheckBox cb = new CheckBox();
                cb.AutoSize = true;
                cb.Text = item;
                cb.Name = item;
                cb.Checked = true;
                flowLayoutPanel1.Controls.Add(cb);
            }
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foldersAccepted = new List<string>();
            foreach (CheckBox control in flowLayoutPanel1.Controls)
            {
                if (control is CheckBox && control.Checked == true)
                {
                    foldersAccepted.Add(control.Text);
                }
            }
            this.Close();
        }
    }
}
