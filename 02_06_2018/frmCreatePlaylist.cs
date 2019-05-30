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
    public partial class frmCreatePlaylist : Form
    {
        public frmCreatePlaylist()
        {
            InitializeComponent();
        }
        public string playlistName { get; set; }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            playlistName = txtName.Text;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
