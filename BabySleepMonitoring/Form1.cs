using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BabySleepMonitoring
{
    public partial class Form1 : Form
    {

        private Bettrandmakierung m_Bettrandmakierung = null;
        private Ueberpruefen m_Ueberpruefen = null;
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

            m_Bettrandmakierung = new Bettrandmakierung();
            SplitContainer2.Panel1.Controls.Add(m_Bettrandmakierung);
            m_Bettrandmakierung.Dock = DockStyle.Fill;

            m_Ueberpruefen = new Ueberpruefen();
            SplitContainer2.Panel2.Controls.Add(m_Ueberpruefen);
            m_Ueberpruefen.Dock = DockStyle.Fill;
        }

        private void ButtonOrdnerWählen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                     
                m_Bettrandmakierung.fillList_path = openFileDialog1.FileName;
                m_Ueberpruefen.ueberpruefen_path = openFileDialog1.FileName;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
