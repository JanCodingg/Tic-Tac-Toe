using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tic_tac_to
{
    public partial class Form1 : Form
    {
        public int spieler = 2;
        public int zug = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;
        Color BlackColor = Color.Black;
        Color WhiteColor = Color.White;
        bool IsDraw()
        {
            if (zug == 9 && IsWinner() == false)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }
        bool IsWinner()
        {
            //Horizontal
            if (A0.Text == A111.Text && A111.Text == A2.Text && A0.Text != "")
            {
                Balken(1);
                return true;
                
            }
                
            if (B0.Text == B1.Text && B1.Text == B2.Text && B0.Text != "")
            {
                Balken(2);
                return true;
            }

            if (C0.Text == C1.Text && C1.Text == C2.Text && C0.Text != "")
            {

                Balken(3);
                return true;
            }

            //Vertical
            if (A0.Text == B0.Text && B0.Text == C0.Text && A0.Text != "")
            {

                Balken(4);
                return true;
            }
            if (A111.Text == B1.Text && B1.Text == C1.Text && A111.Text != "")
            {

                Balken(5);
                return true;
            }
            if (A2.Text == B2.Text && B2.Text == C2.Text && A2.Text != "")
            {

                Balken(6);
                return true;
            }

            //diagonal
            if (A0.Text == B1.Text && B1.Text == C2.Text && A0.Text != "")
            {

                Balken(7);
                return true;
            }
            if (A2.Text == B1.Text && B1.Text == C0.Text && A2.Text != "")
            {

                Balken(8);
                return true;
            }
            else
                return false;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_Spieler1.Text = "Spieler 1: " + s1;
            lbl_spieler2.Text = "Spieler 2: " + s2;
            lbl_Gleichstand.Text = "Unentschieden" + sd;

        }
        private void buttonClickt(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Text == "")
            {
                if(spieler % 2 == 0)
                {
                    button.Text = "X";
                    spieler++;
                    zug++;
                }
                else
                {
                    button.Text = "O";
                    spieler++;
                    zug++;
                }

                if(IsDraw() == true)
                {
                    MessageBox.Show("Unentschieden");
                    sd++;
                    NewGame();
                }

                if(IsWinner() == true)
                {
                    if(button.Text == "X")
                    {
                        MessageBox.Show("Spieler 1 hat gewonnen");
                        s1++;
                        NewGame();
                    }
                    if (button.Text == "O")
                    {
                        MessageBox.Show("Spieler 2 hat gewonnen");
                        s2++;
                        NewGame();
                    }

                }
            }

        }

        private void neuesSpiel_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        public void NewGame()
        {
            spieler = 2;
            zug = 0;
            A0.Text = A111.Text = A2.Text = B0.Text = B1.Text = B2.Text = C0.Text = C1.Text = C2.Text = "";
            lbl_Spieler1.Text = "spieler 1:" + s1;
            lbl_spieler2.Text = "spieler 2:" + s2;
            lbl_Gleichstand.Text = "Unentschieden:" + sd;

            //balken
            pictureBox1.Visible = false;

            //Die Käseten bei einem Diagonalem Sieg werden wieder auf die Ausgangsituation zurückgesetzt
            // also Weiß.
            A0.BackColor = WhiteColor;
            B1.BackColor = WhiteColor;
            C2.BackColor = WhiteColor;
            
            A2.BackColor = WhiteColor;
            B1.BackColor = WhiteColor;
            C0.BackColor = WhiteColor;
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            NewGame();
        }

        private void Beenden_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
        
        //Nach dem Sieg wird der Pfad in dem die drei zeichen in einer Reihe platziert wurden
        //der Balken eingebleden auf dem der positions Wert zutrifft.
        //Wichtig kein Balken bei Diagonamel sie da man diesen nicht drehen kann.
        private void Balken(int position)
        {
            switch(position)
            {
                //horizontal
                case 1:
                    pictureBox1.Location = new Point(75, 100);
                    pictureBox1.Size = new Size(600, 25);
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    pictureBox1.Location = new Point(75, 300);
                    pictureBox1.Size = new Size(600, 25);
                    pictureBox1.Visible = true;
                    break;
                case 3:
                    pictureBox1.Location = new Point(75, 500);
                    pictureBox1.Size = new Size(600, 25);
                    pictureBox1.Visible = true;
                    break;

                //vertikal
                case 4:
                    pictureBox1.Size = new Size(25, 500);
                    pictureBox1.Location = new Point(120, 45);
                    pictureBox1.Visible = true;
                    break;
                case 5:
                    pictureBox1.Size = new Size(25, 500);
                    pictureBox1.Location = new Point(350, 45);
                    pictureBox1.Visible = true;
                    break;
                case 6:
                    pictureBox1.Size = new Size(25, 500);
                    pictureBox1.Location = new Point(580, 45);
                    pictureBox1.Visible = true;
                    break;

                //diagonal
                case 7:
                    A0.BackColor = BlackColor;
                    B1.BackColor = BlackColor;
                    C2.BackColor = BlackColor;
                    break;
                case 8:
                    A2.BackColor = BlackColor;
                    B1.BackColor = BlackColor;
                    C0.BackColor = BlackColor;
                    break;
            }
        }
    }
}
