using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Bytescout.BarCodeReader;
using System.Media;

namespace BabySleepMonitoring
{
    public partial class Ueberpruefen : UserControl
    {
        public Ueberpruefen()
        {
            InitializeComponent();
        }

        //Variablen
        //public event TestFunction Test;

        private Bitmap cloneImage = null; //Klasse Bitmap: um mit Bildern zu arbeiten, die durch Pixeldaten definiert sind
        public List<Point> eckpunkte = new List<Point>(3);
        public List<Point> eckpunkteFinal = new List<Point>(4);
        public List<Point> barcodeEckpunkte = new List<Point>(4);
        private Point m_mouseStart = new Point(0, 0); //Definiton d. Startpunktes der Markierung 
        private Point m_mouseCorrect = new Point(); // neuer Punkt setzen 
        private double xBox = new double(); //Breiten x und Längen y der Box und des Bildes
        private double yBox = new double();
        private double xImage = new double();
        private double yImage = new double();

        private string folder;
        private Bitmap currentPic = null;
        private Bitmap resizeImage = null;
        private int i = 0;
        private Timer timer;
        private string[] files;
        private string path;
        private string barcodeValue;
        private string[] barcode;
        private string bauchlage = "Bauchlage";
        public string ueberpruefen_path //Funktion, die Pfad von Form1 bekommt und daraus erste Bildinstanz initialisiert
        {
            set
            {
                path = value;
                currentPic = new Bitmap(path);
                if(pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                pictureBox1.Image = currentPic;
                if (pictureBox1.Image != null) //bei nicht vorhandener Markierung, ist die Textbox sichtbar
                {
                    textBox1.Visible = true;                   
                    ButtonNeuMakierung.Visible = true;
                                      
                }
            }
        }
        private void Start()
        {
            if (path != null) //wenn Pfad vorhandne ist/Pfad übergeben wurde:
            {
                folder = Path.GetDirectoryName(path); // werden Ornerinformationen und dazugehörende
                files = Directory.GetFiles(folder, "*.jpg"); // Fileinformationen übergeben

                timer = new Timer(); // Erstellung timer
                timer.Tick += new EventHandler(check); //Initialisierung der Funktion check
                timer.Interval = 2000; // Intervall auf 2000 miliseconds festgelegt
                timer.Start(); //start
            }
        }
        private void ButtonStart_Click(object sender, EventArgs e) // Funktion, die bei clicken des Startbuttons ausgeführt wird:
        {
            textBox1.Visible = false;
            ButtonPause.Visible = true;
            ButtonStart.Enabled = false;
            ButtonBeenden.Visible = true;
            ButtonNeuMakierung.Visible = false;
            ButtonNeustart.Visible = true;
            Start();
        }
        private void check(object sender, EventArgs e) // Funktion, die neues picture in Box einliest, solang im Ordner neue vorhanden sind und gibt alte frei
        {
            if (i < files.Count()) //hochzählen bis maximale Anzahl Files
            {
                if (pictureBox1.Image != null)  //wenn Image geladen ist
                {
                    pictureBox1.Image.Dispose();
                }
                //TextBox.Text = files[i];  // file in entsprechender TextBox
                if (currentPic != null)  // wenn picture vorhanden 
                {
                    currentPic.Dispose();  // picture/aktuelle Bitmapinstanz freigeben
                }
                
                currentPic = new Bitmap(files[i]); //aktuelles file als neue Bitmapinstnaz/aktuelles picture
                pictureBox1.Image = currentPic; //neue Instanz/aktuelles picture in Box laden
                //if (eckpunkte.Count == 3) //wenn drei Punkte gesetzt wurden 
                //{
                //    cloneImage = (Bitmap)currentPic.Clone();
                //    Graphics g = CreateGraphics();
                //    g = Graphics.FromImage(cloneImage);
                //    Pen p = new Pen(Color.Red, 10);
                //    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                //    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                //    Point punkt4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                //    g.DrawLine(p, eckpunkte[0], point2);                        // wird vom ersten zum Zweiten Punkt 
                //    g.DrawLine(p, point2, point3);                              //und vom zweiten zum dritten Punkt jeweils eine Linie gezeichnet
                //    g.DrawLine(p, point3, punkt4);                              //Linie von Punkt 3 nach Punkt 4 wird ergänzt 
                //    g.DrawLine(p, punkt4, eckpunkte[0]);                        //Linie von Punkt 3 nach Punkt 4 wird ergänzt 

                //    pictureBox1.Image = cloneImage;

                //    pictureBox1.Refresh();
                //    ButtonStart.Visible = true;
                //}
                QR(files[i]);
                i++; //hochzählen der Instanzen/files und somit pictures/Images
            }
            else
                timer.Stop(); //Ende timer wenn letzte erreicht

        }

        private void QR(string file)
        {
            resizeImage = new Bitmap(currentPic);

            Reader reader = new Reader("demo", "demo");
            reader.BarcodeTypesToFind.QRCode = true;
            FoundBarcode[] barcodes = reader.ReadFrom(file);

            if (barcodes.Count() == 0)
            {
                Alarm("Achtung QRCode wurde nicht gefunden"+ files[i]);
            }
            else
            {
                if (Rand(barcodes[0]) == true)
                {
                    barcodeValue = barcodes[0].Value;
                    barcode = barcodeValue.Split('6');
                    Bauchlage(barcode[1]);
                }
            }          
        }
        private bool Rand(FoundBarcode barcode)
        {
            if (eckpunkteFinal.Count() == 4)
            {
                barcodeEckpunkte.Clear();
                barcodeEckpunkte.Add(new Point(barcode.Rect.X, barcode.Rect.Y));
                barcodeEckpunkte.Add(new Point(barcode.Rect.X + barcode.Rect.Width, barcode.Rect.Y));
                barcodeEckpunkte.Add(new Point(barcode.Rect.X + barcode.Rect.Width, barcode.Rect.Y + barcode.Rect.Height));
                barcodeEckpunkte.Add(new Point(barcode.Rect.X, barcode.Rect.Y + barcode.Rect.Height));
                int outside = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (outside < 2)
                    {
                        if (barcodeEckpunkte[i].X < eckpunkteFinal[0].X || barcodeEckpunkte[i].X > eckpunkteFinal[1].X || barcodeEckpunkte[i].Y < eckpunkteFinal[0].Y || barcodeEckpunkte[i].Y > eckpunkteFinal[3].Y)
                            outside++;
                        if (outside == 2)
                            Alarm("Achtung ausserhalb des Bereichs");
                    }
                }
            }
            
            return true;
        }

        private void Bauchlage(string lage)
        {
            if(lage == bauchlage)
            {
                Alarm("Achtung Bauchlage"+ files[i]);
            }
        }

        private void Alarm(string alarm)
        {
            if (eckpunkte.Count == 3) //wenn drei Punkte gesetzt wurden 
            {
                cloneImage = (Bitmap)currentPic.Clone();
                Graphics g = CreateGraphics();
                g = Graphics.FromImage(cloneImage);
                Pen p = new Pen(Color.Red, 10);
                Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                Point point4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                g.DrawLine(p, eckpunkte[0], point2);                        // wird vom ersten zum Zweiten Punkt 
                g.DrawLine(p, point2, point3);                              //und vom zweiten zum dritten Punkt jeweils eine Linie gezeichnet
                g.DrawLine(p, point3, point4);                              //Linie von Punkt 3 nach Punkt 4 wird ergänzt 
                g.DrawLine(p, point4, eckpunkte[0]);                        //Linie von Punkt 3 nach Punkt 4 wird ergänzt 

                pictureBox1.Image = cloneImage;

                pictureBox1.Refresh();
                timer.Stop();
            }
            SoundPlayer splayer = new SoundPlayer(@"C:\Users\Carlotta\Documents\Desktop\Testbild\Alarm.wav");
            splayer.Play();
            DialogResult result = MessageBox.Show(alarm, "Alarm", MessageBoxButtons.OK);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();                             
            }           
        }

        //private void ButtonStartMakierung_Click(object sender, EventArgs e)
        //{
        //    Checked = 1;
        //}

        //Makierung auf dem Image
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentPic != null)
            {
                m_mouseStart = new Point(e.X, e.Y); // Punkt wurde gesetzt an einer Stelle

                //Umberechnung Maus Position
                yImage = currentPic.Height; //festlegen der Höhe und Breite des Bildes
                xImage = currentPic.Width;
                yBox = pictureBox1.Size.Height;//festlegen der Höhe und Breite der Box
                xBox = pictureBox1.Size.Width;

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

                cloneImage = (Bitmap)currentPic.Clone();

                if (eckpunkte.Count == 2) //wenn insgesamt zwei Punkte gewählt wurden, wird von punkt zu punkt jeweils eine rote Linie gezogn
                {
                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    g.DrawLine(p, eckpunkte[0], point2);

                    pictureBox1.Image = cloneImage;

                    pictureBox1.Refresh();
                }
                if (eckpunkte.Count == 3) //wenn drei Punkte gesetzt wurden 
                {
                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                    Point point4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                    g.DrawLine(p, eckpunkte[0], point2);                        // wird vom ersten zum Zweiten Punkt 
                    g.DrawLine(p, point2, point3);                              //und vom zweiten zum dritten Punkt jeweils eine Linie gezeichnet
                    g.DrawLine(p, point3, point4);                              //Linie von Punkt 3 nach Punkt 4 wird ergänzt 
                    g.DrawLine(p, point4, eckpunkte[0]);                        //Linie von Punkt 3 nach Punkt 4 wird ergänzt 

                    pictureBox1.Image = cloneImage;

                    pictureBox1.Refresh();

                    eckpunkteFinal.Add(eckpunkte[0]);
                    eckpunkteFinal.Add(point2);
                    eckpunkteFinal.Add(point3);
                    eckpunkteFinal.Add(point4);

                    textBox1.Visible = false;
                    ButtonStart.Visible = true;

           
                }
            }
        }

        private void ButtonNeuMakierung_Click(object sender, EventArgs e)
        {
            ButtonStart.Visible = false;
            eckpunkte.Clear(); //vorher gewählte Eckpunkte werden geloescht
            eckpunkteFinal.Clear();
            pictureBox1.Image = null;
            pictureBox1.Image = currentPic;
            textBox1.Visible = true;
        }
        private void BildKoordinatenY()
        {
            if (pictureBox1.Image != null) //wenn Markierung nicht außerhalb der Bildkoordinaten liegt
            {
                double startProzenY = (100 * (double)m_mouseStart.Y) / yBox;
                m_mouseCorrect.Y = (int)((yImage * startProzenY) / 100);
            }

        }
        private void BildKoordinatenX()
        {
            if (pictureBox1.Image != null)
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
            if (pictureBox1.Image != null)
            {
                double startProzenY = (100 * (double)m_mouseStart.Y) / xBox;
                m_mouseCorrect.X = (int)((xImage * startProzenY) / 100);
            }
        }
        private void BildKoordinatenOY()
        {
            if (pictureBox1.Image != null)
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

        //Pause Button
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            if (ButtonPause.Text == "Pause")
            {
                ButtonPause.Text = "weiter";
                timer.Stop();
                if (eckpunkte.Count == 3) //wenn drei Punkte gesetzt wurden 
                {
                    cloneImage = (Bitmap)currentPic.Clone();
                    Graphics g = CreateGraphics();
                    g = Graphics.FromImage(cloneImage);
                    Pen p = new Pen(Color.Red, 10);
                    Point point2 = new Point(eckpunkte[1].X, eckpunkte[0].Y);
                    Point point3 = new Point(eckpunkte[1].X, eckpunkte[2].Y);
                    Point point4 = new Point((eckpunkte[0].X), (eckpunkte[2].Y));
                    g.DrawLine(p, eckpunkte[0], point2);                        // wird vom ersten zum Zweiten Punkt 
                    g.DrawLine(p, point2, point3);                              //und vom zweiten zum dritten Punkt jeweils eine Linie gezeichnet
                    g.DrawLine(p, point3, point4);                              //Linie von Punkt 3 nach Punkt 4 wird ergänzt 
                    g.DrawLine(p, point4, eckpunkte[0]);                        //Linie von Punkt 3 nach Punkt 4 wird ergänzt 

                    pictureBox1.Image = cloneImage;

                    pictureBox1.Refresh();
                    ButtonStart.Visible = true;
                    ButtonPause.Visible = true;
                }
            }
            else
            {
                ButtonPause.Text = "Pause";
                timer.Start();
            }
        }

        private void ButtonBeenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonNeustart_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            eckpunkteFinal.Clear();
            eckpunkte.Clear();
            barcodeEckpunkte.Clear();
            ButtonNeustart.Visible = false;
            ButtonPause.Visible = false;
            ButtonStart.Visible = false;
            ButtonNeuMakierung.Visible = true;
            ButtonBeenden.Visible = false;
            textBox1.Visible = true;
            ButtonStart.Enabled = true;
        }
    }
}
