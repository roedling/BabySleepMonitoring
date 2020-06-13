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
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e) // Funktion, die bei clicken des Startbuttons ausgeführt wird:
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
        private void check(object sender, EventArgs e) // Funktion, die neues picture in Box einliest, solang im Ordner neue vorhanden sind und gibt alte frei
        {
            if (i < files.Count()) //hochzählen bis maximale Anzahl Files
            {
                if (pictureBox1.Image != null)  //wenn Image geladen ist
                {
                    //    pictureBox1.Dispose();
                }
                TextBox.Text = files[i];  // file in entsprechender TextBox
                if (currentPic != null)  // wenn picture vorhanden 
                {
                    currentPic.Dispose();  // picture/aktuelle Bitmapinstanz freigeben
                }
                currentPic = new Bitmap(files[i]); //aktuelles file als neue Bitmapinstnaz/aktuelles picture
                pictureBox1.Image = currentPic; //neue Instanz/aktuelles picture in Box laden
                Bauchlage(files[i]);
                i++; //hochzählen der Instanzen/files und somit pictures/Images
            }
            else
                timer.Stop(); //Ende timer wenn letzte erreicht

        }

        private void Bauchlage(string file)
        {
            resizeImage = new Bitmap(currentPic);

            Reader reader = new Reader("demo", "demo");
            reader.BarcodeTypesToFind.QRCode = true;
            FoundBarcode[] barcodes = reader.ReadFrom(file);

            if (barcodes.Count() == 0)
            {
                Alarm("Achtung ausserhalb des definierten Bereichs");
            }
            else
            {
                barcodeValue = barcodes[0].Value;
                barcode = barcodeValue.Split('6');
                Rand(barcode[1]);
            }          
        }

        private void Rand(string lage)
        {
            if(lage == bauchlage)
            {
                Alarm("Achtung Bauchlage");
            }
        }

        private void Alarm(string alarm)
        {
            timer.Stop();
            SoundPlayer splayer = new SoundPlayer(@"C:\Users\Carlotta\Documents\Desktop\Testbild\Alarm.wav");
            splayer.Play();
            DialogResult result = MessageBox.Show(alarm, "Alarm", MessageBoxButtons.OK);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();                             
            }           
        }
    }
}
