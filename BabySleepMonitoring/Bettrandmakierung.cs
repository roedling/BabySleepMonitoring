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
    public delegate void TestFunction();
    public partial class Bettrandmakierung : UserControl
    {
        public Bettrandmakierung()
        {
            InitializeComponent();
        }

        public event TestFunction Test;

        private Bitmap cloneImage = null;
        public List<Point> eckpunkte = new List<Point>(3);
        private Bitmap image = null;
        int Checked = 0;
        private Point m_mouseStart = new Point(0, 0);
        private Point m_mouseCorrect = new Point();
        private double xBox = new double();
        private double yBox = new double();
        private double xImage = new double();
        private double yImage = new double();


        private string path;
        public string fillList_path
        {
            set
            {
                path = value;
                image = new Bitmap(path);
                PictureBoxMakierung.Image = image;
                if (PictureBoxMakierung.Image != null)
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
            if (Checked == 1 && image != null)
            {
                m_mouseStart = new Point(e.X, e.Y);

                //Umberechnung Maus Position
                yImage = image.Height;
                xImage = image.Width;
                yBox = PictureBoxMakierung.Size.Height;
                xBox = PictureBoxMakierung.Size.Width;

                double referenz = xImage / xImage;
                double vergleich = xBox / yBox;

                if (referenz < vergleich)
                {
                    BildKoordinatenX();
                    BildKoordinatenY();
                }
                else if (referenz > vergleich)
                {
                    BildKoordinatenOX();
                    BildKoordinatenOY();
                }
                else
                {
                    m_mouseCorrect = new Point((int)xImage, (int)yImage);
                }

                eckpunkte.Add(m_mouseCorrect);

                cloneImage = (Bitmap)image.Clone();

                if (eckpunkte.Count == 2)
                {
                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    g.DrawLine(p, eckpunkte[0], point2);

                    PictureBoxMakierung.Image = cloneImage;

                    PictureBoxMakierung.Refresh();
                }
                if (eckpunkte.Count == 3)
                {

                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                    Point punkt4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                    g.DrawLine(p, eckpunkte[0], point2);
                    g.DrawLine(p, point2, point3);
                    g.DrawLine(p, point3, punkt4);
                    g.DrawLine(p, punkt4, eckpunkte[0]);

                    PictureBoxMakierung.Image = cloneImage;

                    PictureBoxMakierung.Refresh();
                    if(Test != null)
                    {
                        Test();
                    }
                }
            }
        }

        private void ButtonNeuMakierung_Click(object sender, EventArgs e)
        {
            eckpunkte.Clear();
            Checked = 0;
            PictureBoxMakierung.Image = null;
            PictureBoxMakierung.Image = image;

        }

        private void BildKoordinatenY()
        {
            if (PictureBoxMakierung.Image != null)
            {
                double startProzenY = (100 * (double)m_mouseStart.Y) / yBox;
                m_mouseCorrect.Y = (int)((yImage * startProzenY) / 100);
            }

        }
        private void BildKoordinatenX()
        {
            if (PictureBoxMakierung.Image != null)
            {

                double yFaktor = yBox / yImage;

                double ih = yFaktor * yImage;
                double iw = yFaktor * xImage;

                double diff = (xBox - iw) / 2;

                    double mausStart = (m_mouseStart.X - diff);
                    double startImageProzent = (100 * mausStart) / iw;
                    m_mouseCorrect.X = (int)((xImage * startImageProzent) / 100);
            }
        }
        private void BildKoordinatenOX()
        {
            if (PictureBoxMakierung.Image != null)
            {
                double startProzenY = (100 * (double)m_mouseStart.Y) / xBox;
                m_mouseCorrect.X = (int)((xImage * startProzenY) / 100);
            }
        }
        private void BildKoordinatenOY()
        {
            if (PictureBoxMakierung.Image != null)
            {
                double yFaktor = yBox / yImage;

                double ih = yFaktor * yImage;
                double iw = yFaktor * xImage;

                double diff = (yBox - iw) / 2;

                    double mausStart = (m_mouseStart.Y - diff);
                    double startImageProzent = (100 * mausStart) / ih;
                    m_mouseCorrect.Y = (int)((yImage * startImageProzent) / 100);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
