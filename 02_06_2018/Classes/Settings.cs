using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_06_2018.Classes
{
    public class Settings
    {
        public RadioButton RadioBtn { get; set; }
        public Button Btn { get; set; }
        public TextBox Txtbox { get; set; }
        public Panel Panel1 { get; set; }

        public Panel PanelMeth(string lstbackColor, int width, int height)
        {
            Panel1 = new Panel();
            Panel1.BackColor = ColorTranslator.FromHtml(lstbackColor);
            Panel1.Size = new Size(width - 20, height - 40);
            Panel1.Location = new Point(10, 30);
            return Panel1;
        }
        public RadioButton RadioButtonMeth(string text, string textCol, int width, int y)
        {
            RadioButton rdoDark = new RadioButton();
            rdoDark.Text = text;
            rdoDark.ForeColor = ColorTranslator.FromHtml(textCol);
            rdoDark.Location = new Point(width / 2 - 50, y);
            //panelSettings.Controls.Add(rdoDark);
            //rdoDark.CheckedChanged += new EventHandler((sender1, e1) => { color = rdoDark.Text; });
            return rdoDark;
        }

        public TextBox TextBoxMeth(int width)
        {
            TextBox textbox = new TextBox();
            textbox.ForeColor = Color.Black;
            textbox.Location = new Point(width / 2 - 50, 300);
            return textbox;
        }

        public RichTextBox RichTextBoxMeth(int width)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.ForeColor = Color.Black;
            richTextBox.Location = new Point(width / 2 - 50, 300);
            return richTextBox;
        }

        public Button ButtonMeth(string textCol, int width, string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.ForeColor = ColorTranslator.FromHtml(textCol);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Location = new Point(width / 2 - 50, y);
            return button;
        }
        public Label LabelMeth(string textCol, int width, string text, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.ForeColor = ColorTranslator.FromHtml(textCol);
            label.Location = new Point(width / 2 - 50, y);
            return label;
        }

        //Panel panelSettings = new Panel();
        //panelSettings.BackColor = ColorTranslator.FromHtml(lstbackColor);
        //panelSettings.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 40);
        //panelSettings.Location = new Point(10, 30);
        //Controls.Add(panelSettings);


        //RadioButton rdoDark = new RadioButton();
        //rdoDark.Text = "Dark mode";
        //rdoDark.ForeColor = ColorTranslator.FromHtml(textCol);
        //rdoDark.Location = new Point(ClientSize.Width / 2 - 50, 100);
        //panelSettings.Controls.Add(rdoDark);
        //rdoDark.CheckedChanged += new EventHandler((sender1, e1) => { color = rdoDark.Text; });

        //RadioButton rdoLight = new RadioButton();
        //rdoLight.Text = "Light mode";
        //rdoLight.ForeColor = ColorTranslator.FromHtml(textCol);
        //rdoLight.Location = new Point(ClientSize.Width / 2 - 50, 150);
        //panelSettings.Controls.Add(rdoLight);
        //rdoLight.CheckedChanged += new EventHandler((sender1, e1) => { color = rdoLight.Text; });

        //RadioButton rdoNormal = new RadioButton();
        //rdoNormal.Text = "Normal mode";
        //rdoNormal.ForeColor = ColorTranslator.FromHtml(textCol);
        //rdoNormal.Location = new Point(ClientSize.Width / 2 - 50, 200);
        //panelSettings.Controls.Add(rdoNormal);
        //rdoNormal.CheckedChanged += new EventHandler((sender1, e1) => { color = rdoNormal.Text; });

        //TextBox txtDownloadUrl = new TextBox();
        //txtDownloadUrl.ForeColor = Color.Black;
        //txtDownloadUrl.Location = new Point(ClientSize.Width / 2 - 50, 300);
        //panelSettings.Controls.Add(txtDownloadUrl);


        //Button btnDownloadMusic = new Button();
        //btnDownloadMusic.Text = "Download Mp3";
        //btnDownloadMusic.ForeColor = ColorTranslator.FromHtml(textCol);
        //btnDownloadMusic.FlatStyle = FlatStyle.Flat;
        //btnDownloadMusic.FlatAppearance.BorderSize = 0;
        //btnDownloadMusic.Location = new Point(ClientSize.Width / 2 - 50, 350);
        //btnDownloadMusic.Name = txtDownloadUrl.Text;
        //panelSettings.Controls.Add(btnDownloadMusic);
        //txtDownloadUrl.TextChanged += new EventHandler((sender1, e1) => { btnDownloadMusic.Name = txtDownloadUrl.Text; });
        //btnDownloadMusic.Click += new EventHandler((sender2, e2) => btnDownloadMusic_click(sender2, e2));

        //Button btnExitSettings = new Button();
        //btnExitSettings.Text = "Exit settings";
        //btnExitSettings.ForeColor = ColorTranslator.FromHtml(textCol);
        //btnExitSettings.FlatStyle = FlatStyle.Flat;
        //btnExitSettings.FlatAppearance.BorderSize = 0;
        //btnExitSettings.Location = new Point(ClientSize.Width / 2 - 50, ClientSize.Height - 80);
        //panelSettings.Controls.Add(btnExitSettings);
        ////foreach (RadioButton rdo in this.Controls.OfType<RadioButton>())
        ////{
        ////    if (rdo.Checked)
        ////    {
        ////        btnExitSettings.Name = rdo.Text;
        ////    }
        ////}
        //btnExitSettings.Click += new EventHandler((sender2, e2) => btnExitSettings_click(sender2, e2));

        //foreach (Control control in panelSettings.Controls)
        //{
        //    RadioButton radio = control as RadioButton;
        //    if (color == control.Text)
        //    {
        //        radio.Checked = true;


        //    }
        //}

    }
}
