using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _02_06_2018
{
    class NewButton : Button
    {
        private Color CurrentforeColour;
        private Color CurrentBackColor;
        private Color onHoverBackColor = Color.DarkOrchid;

        public NewButton()
        {

            //this.ForeColor = Color.Red;
            //BackColor = Color.DodgerBlue;            
            TabStop = false;
            ForeColor = Color.DimGray;
            FlatStyle = FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
            FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            //SetStyle(ControlStyles.Selectable, false);
            this.FlatAppearance.BorderSize =  0;
            CurrentBackColor = BackColor;
            CurrentforeColour = ForeColor;
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }

        public Color OnHoverBackColor
        {
            get { return onHoverBackColor; }
            set { onHoverBackColor = value; Invalidate(); }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //CurrentBackColor = onHoverBackColor;
            ForeColor = Color.White;
            CurrentforeColour = ForeColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //CurrentBackColor = BackColor;
            ForeColor = Color.DimGray;
            CurrentforeColour = ForeColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            //CurrentBackColor = Color.RoyalBlue;

            ForeColor = Color.White;
            CurrentforeColour = ForeColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            
            //CurrentBackColor = BackColor;
            Invalidate();
        }

       // private SolidBrush reportsForegroundBrushSelected = new SolidBrush(selectedCol);
        //private SolidBrush reportsForegroundBrush;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;

            SolidBrush foregroundBrush = new SolidBrush(CurrentforeColour);
            g.DrawString(Text, Font, foregroundBrush, this.Location);

        }


    }
}
