using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AC_Projekt
{
    public partial class Form1 : Form
    {
        Olovka olov = new Olovka(10, true);        
        Color boja = Color.Black;
                
        Point MouseDownLocation;

        public Form1()
        {
            InitializeComponent();            
        }                       
       
        private void lblPlatno_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (olov.Olovka1 == true)
            {
                using (var g = lblPlatno.CreateGraphics())
                {
                    g.FillEllipse(new SolidBrush(boja), e.X, e.Y, olov.Velicina, olov.Velicina);
                }                    
                
            }
            else if (olov.Olovka1 == false)
            {
                using (var g = lblPlatno.CreateGraphics())
                {
                    g.DrawEllipse(new Pen(new SolidBrush(boja)), e.X, e.Y, olov.Velicina, olov.Velicina);
                }
            }
        }        

        private void rdbOlovka_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOlovka.Checked == false)
            {
                olov.Olovka1 = false;             
            }
            else
            {
                olov.Olovka1 = true;                
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var panel = sender as Panel;
            boja = panel.BackColor;            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            olov.Velicina += 5;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            olov.Velicina -= 5;
        }        

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblPlatno.Refresh();
            rdbOlovka.Checked = true;
            olov.Velicina = 10;
            boja = Color.Black;
        }        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p1 = new PictureBox();
            p1.Location = new Point(350, 150);
            p1.Name = "pic1";
            p1.Size = new Size(100, 69);
            p1.ImageLocation = "rectangle2.png";

            p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            p1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                       
            this.Controls.Add(p1);
            p1.BringToFront();
        }        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            var p = sender as PictureBox;                        

            var picRec = new Rectangle(e.X + p.Left - MouseDownLocation.X, e.Y + p.Top - MouseDownLocation.Y, p.Size.Width, p.Size.Height);
            var lblRect = new Rectangle(lblPlatno.Location, lblPlatno.Size);

            if (lblRect.Contains(picRec))
            {
                p.Left = picRec.Left;
                p.Top = picRec.Top;
            }            
                           
        }        

        private void addCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p2 = new PictureBox();
            p2.Location = new Point(295, 95);
            p2.Name = "pic2";
            p2.Size = new Size(70, 70);
            p2.ImageLocation = "circle.png";
            
            p2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            p2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                       
            Controls.Add(p2);
            p2.BringToFront();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                var result = colorDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                boja = colorDialog.Color;
            }
        }
    }
}
