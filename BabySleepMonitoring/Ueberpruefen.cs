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

namespace BabySleepMonitoring
{
    public partial class Ueberpruefen : UserControl
    {
        public Ueberpruefen()
        {
            InitializeComponent();
        }

        private string folder;
        private Bitmap currentPic = null;
        private int i = 0;
        private Timer timer;
        private string[] files;
        private string path;
        public string ueberpruefen_path
        {
            set
            {
                path = value;
                currentPic = new Bitmap(path);
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(path != null)
            {
                folder = Path.GetDirectoryName(path);
                files = Directory.GetFiles(folder);

                timer = new Timer();
                timer.Tick += new EventHandler(check);
                timer.Interval = 2000; // in miliseconds
                timer.Start();
            }
        }
        private void check(object sender, EventArgs e)
        {
            if (i < files.Count())
            {
                if (pictureBox1.Image != null)
                {

                }
                TextBox.Text = files[i];
                if (currentPic != null)
                {
                    currentPic.Dispose();
                }
                currentPic = new Bitmap(files[i]);
                pictureBox1.Image = currentPic;
                i++;
            }
            else
                timer.Stop();

        }

        private void Bauchlage()
        {

        }

        private void Rand()
        {

        }
    }
}
