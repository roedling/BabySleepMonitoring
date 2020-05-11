using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabySleepMonitoring
{
    public partial class Form1 : Form
    {

        private Bettrandmakierung m_Bettrandmakierung = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_Bettrandmakierung = new Bettrandmakierung();
            SplitContainer2.Panel1.Controls.Add(m_Bettrandmakierung);
            m_Bettrandmakierung.Dock = DockStyle.Fill;
        }

        private void ButtonOrdnerWählen_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.FileName;

                filePath = openFileDialog1.FileName;

                m_Bettrandmakierung.fillList_path = filePath;
            }
        }
    }
}
