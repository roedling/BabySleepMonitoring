using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabySleepMonitoring
{
    public partial class Bettrandmakierung : UserControl
    {
        public Bettrandmakierung()
        {
            InitializeComponent();
        }


        List<Point> eckpunkte = new List<Point>(3);
        private Bitmap image = null;
        int Checked = 0;


        private string path;
        public string fillList_path
        {
            set
            {
                path = value;
                image = new Bitmap(path);
                PictureBoxMakierung.Image = image;
                if(PictureBoxMakierung.Image != null)
                {
                    textBox1.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //Start Bettrandmakierung
        {
            Checked = 1;
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void PictureBoxMakierung_MouseClick(object sender, MouseEventArgs e)
        {
            if (Checked == 1)
            {
                int x = e.X;
                int y = e.Y;

                //Umberechnung Maus Position
                int imageY = image.Height;
                int imageX = image.Width;
                int BoxY = PictureBoxMakierung.Height;
                int BoxX = PictureBoxMakierung.Width;
                double BoxVer = (double)BoxX / (double)BoxY;
                double imageVer = (double)imageX / (double)imageY;

                if (BoxVer < imageVer)  //oben unten 
                {
                    int yWert = 0;
                    int xWert = 0;
                    var Punkt = new Point(xWert, yWert);
                    eckpunkte.Add(Punkt);
                }
                else if (BoxVer > imageVer) //rechts links
                {

                    int yWert = 0;
                    int xWert = 0;
                    var Punkt = new Point(xWert, yWert);
                    eckpunkte.Add(Punkt);
                }
                else
                {
                    var Punkt = new Point(x, y);
                    eckpunkte.Add(Punkt);
                }


                

                Bitmap ImageClone = new Bitmap(image);

                if (eckpunkte.Count == 2)
                {
                    Graphics g = this.CreateGraphics();
                    g = Graphics.FromImage(ImageClone);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    g.DrawLine(p, eckpunkte[0], point2);
              
                    PictureBoxMakierung.Image = ImageClone;

                    PictureBoxMakierung.Refresh();
                }
                if (eckpunkte.Count == 3)
                {
                    
                    Graphics g = this.CreateGraphics();
                    g = Graphics.FromImage(ImageClone);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                    Point punkt4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                    g.DrawLine(p, eckpunkte[0], point2);
                    g.DrawLine(p, point2, point3);
                    g.DrawLine(p, point3, punkt4);
                    g.DrawLine(p, punkt4, eckpunkte[0]);

                    PictureBoxMakierung.Image = ImageClone;

                    PictureBoxMakierung.Refresh();
                }
            }
        }

        private void ButtonNeuMakierung_Click(object sender, EventArgs e)
        {
            eckpunkte.Clear();
            PictureBoxMakierung.Image = null;
            PictureBoxMakierung.Image = image;

        }
    }
}
