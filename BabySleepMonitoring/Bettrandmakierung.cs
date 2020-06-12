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

        private Bitmap cloneImage = null; //Klasse Bitmap: um mit Bildern zu arbeiten, die durch Pixeldaten definiert sind
        public List<Point> eckpunkte = new List<Point>(3);
        private Bitmap image = null;
        int Checked = 0;
        private Point m_mouseStart = new Point(0, 0); //Definiton d. Startpunktes der Markierung 
        private Point m_mouseCorrect = new Point(); // neuer Punkt setzen 
        private double xBox = new double(); //Breiten x und Längen y der Box und des Bildes
        private double yBox = new double();
        private double xImage = new double();
        private double yImage = new double();


        private string path;
        public string fillList_path
        {
            set //neuen Pfad bereitstellen für die Arbeit mit Pixelbildern
            {
                path = value;
                image = new Bitmap(path); //Pfad steht zur Verfügung für eingelesenes Bild 
                PictureBoxMakierung.Image = image;
                if (PictureBoxMakierung.Image != null) //bei nicht vorhandener Markierung, ist die Textbox sichtbar
                {
                    textBox1.Visible = true;
                }
            }
        }

        //Beginn der Markierung 

        private void button1_Click(object sender, EventArgs e) //Start Bettrandmakierung
        {
            Checked = 1;
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e) 
        {

        }

        private void PictureBoxMakierung_MouseClick(object sender, MouseEventArgs e)  //Per Mausklick wurde Punkt gewählt; diese Information wird hier übergeben
        {
            if (Checked == 1 && image != null) 
            {
                m_mouseStart = new Point(e.X, e.Y); // Punkt wurde gesetzt an einer Stelle

                //Umberechnung Maus Position
                yImage = image.Height; //festlegen der Höhe und Breite des Bildes
                xImage = image.Width;
                yBox = PictureBoxMakierung.Size.Height;//festlegen der Höhe und Breite der Box
                xBox = PictureBoxMakierung.Size.Width;

                double referenz = xImage / xImage;  //Das Verhältnis der Postitionen von dem eingelesen Bild und dem Punkt wird gespeichert
                double vergleich = xBox / yBox;

                if (referenz < vergleich) //Überprüfen, ob Bild kleiner als Box 
                {
                    BildKoordinatenX(); //wenn ja, gewählte Punkte als Bildkoordinaten übernehmen 
                    BildKoordinatenY();
                }
                else if (referenz > vergleich) //sonst überprüfen, ob Box kleiner ist als Bild 
                {
                    BildKoordinatenOX();
                    BildKoordinatenOY();
                }
                else
                {
                    m_mouseCorrect = new Point((int)xImage, (int)yImage);
                }

                eckpunkte.Add(m_mouseCorrect); //Koordinaten als Eckpunkte hinzufügen 

                cloneImage = (Bitmap)image.Clone();

                if (eckpunkte.Count == 2) //wenn insgesamt zwei Punkte gewählt wurden, wird von punkt zu punkt jeweils eine rote Linie gezogn
                {
                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    g.DrawLine(p, eckpunkte[0], point2);

                    PictureBoxMakierung.Image = cloneImage;

                    PictureBoxMakierung.Refresh();
                }
                if (eckpunkte.Count == 3) //wenn drei Punkte gesetzt wurden 
                                          
                {

                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                    Point punkt4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                    g.DrawLine(p, eckpunkte[0], point2);                        // wird vom ersten zum Zweiten Punkt 
                    g.DrawLine(p, point2, point3);                              //und vom zweiten zum dritten Punkt jeweils eine Linie gezeichnet
                    g.DrawLine(p, point3, punkt4);                              //Linie von Punkt 3 nach Punkt 4 wird ergänzt 
                    g.DrawLine(p, punkt4, eckpunkte[0]);                        //Linie von Punkt 3 nach Punkt 4 wird ergänzt 

                    PictureBoxMakierung.Image = cloneImage;

                    PictureBoxMakierung.Refresh();
                    if(Test != null)
                    {
                        Test();
                    }
                }
            }
        }

        private void ButtonNeuMakierung_Click(object sender, EventArgs e) //wenn neue Markierung mit Punkten stattfinden soll: 
        {
            eckpunkte.Clear(); //vorher gewählte Eckpunkte werden geloescht
            Checked = 0;
            PictureBoxMakierung.Image = null; 
            PictureBoxMakierung.Image = image;

        }

        private void BildKoordinatenY() 
        {
            if (PictureBoxMakierung.Image != null) //wenn Markierung nicht außerhalb der Bildkoordinaten liegt
            {
                double startProzenY = (100 * (double)m_mouseStart.Y) / yBox;
                m_mouseCorrect.Y = (int)((yImage * startProzenY) / 100);
            }

        }
        private void BildKoordinatenX()
        {
            if (PictureBoxMakierung.Image != null)
            {

                double yFaktor = yBox / yImage; //Verhältnis zwischen Box und Bild als Faktor definieren 

                double ih = yFaktor * yImage; // Bild durch Multiplikation mit dem faktor anpassen 
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
