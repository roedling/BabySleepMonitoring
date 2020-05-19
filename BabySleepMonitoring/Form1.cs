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
        // Variablen
        private Bettrandmakierung m_Bettrandmakierung = null;
        private Ueberpruefen m_Ueberpruefen = null;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initalisierung des UserControl "Bettrandmakierung"
            m_Bettrandmakierung = new Bettrandmakierung(); //Erstellung
            SplitContainer2.Panel1.Controls.Add(m_Bettrandmakierung); //Einfügen des UserControls an der richtigen Stelle
            m_Bettrandmakierung.Dock = DockStyle.Fill; //UserControl soll (in dem Fall SplitContainer2.Panel1) komplett ausfüllen
            m_Bettrandmakierung.Visible = false; //Anfangssichtbarkeit auf "undurchsichtig"

            //Initalisierung des UserControl "Ueberpruefen"
            m_Ueberpruefen = new Ueberpruefen();
            SplitContainer2.Panel2.Controls.Add(m_Ueberpruefen);
            m_Ueberpruefen.Dock = DockStyle.Fill;
            m_Ueberpruefen.Visible = false;

            //Initalisierung der Funktion nav_Text, welche aus dem UserControl "Ueberpruefen" aufgerufen wird
            m_Bettrandmakierung.Test += new TestFunction(nav_Text);
        }

        private void nav_Text() //Funktion welche aus dem UserControl "Ueberpruefen" aufgerufen wird
        {
            m_Ueberpruefen.Visible = true; //Sichtbarkeit des UserControls Ueberpruefen auf "sichtbar"
        }

        private void ButtonOrdnerWählen_Click(object sender, EventArgs e) //Funktion welche beim Drücken des Buttons ausgeführt wird
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Wenn die Wahl der Datei erfolgt und korrekt ist dann ->
            {
                m_Bettrandmakierung.Visible = true; //Sichtbarkeit des UserControls Bettrandmakierung auf "sichtbar"
                m_Bettrandmakierung.fillList_path = openFileDialog1.FileName; //Übergabe des Pfads an Bettrandmakierung
                m_Ueberpruefen.ueberpruefen_path = openFileDialog1.FileName; //Übergabe des Pfads an Ueberpruefen

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
