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


        private string[] files;
        private string path;
        public string fillList_path
        {
            set
            {
                path = value;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(path != null)
            {
                files = Directory.GetFiles(path);
                
                for(int i = 0; i< files.Count(); i++)
                {

                }




            }
        }
    }
}
