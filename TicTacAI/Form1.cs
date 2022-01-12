using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIcTacAIv2
{
    public partial class Form1 : Form
    {
        bool turn = true;
        bool against_computer = false;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
       
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TicTacToe by Syn", "TicTacToe v2.0");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((p1.Text == "Player 1") || (p2.Text == "Player 2"))
            {
                MessageBox.Show("You must specify the player's names before you can start!\nType Computer(for Player 2)");
            }
            else
            {
                Button butt = (Button)sender;
                if (turn)
                    butt.Text = "X";
                else
                    butt.Text = "O";

                turn = !turn;
                count++;
                butt.Enabled = false;
                whoWin();
            }
            if((!turn)&&(against_computer))
            {
                computer_make_move();
            }
        }
        private void computer_make_move()
        {
            Button move = null;

            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
            }
            if (count != 9)
            {
                move.PerformClick();
            }
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }
            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;
            if ((A3.Text == "X") && (B2.Text == "X") &&  (C1.Text == ""))
                return C1;
            if ((B1.Text == "X") && (B2.Text == "X") && (B3.Text == ""))
                return B3;

            return null;
        }
        private void whoWin()
        {
            bool winner = false;

            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text)&&(!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text)&&(!C1.Enabled))
                winner = true;
            
            //vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text)&& (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text)&&(!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text)&&(!A3.Enabled))
                winner = true;

            //diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text)&&(!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text)&&(!A3.Enabled))
                winner = true;
            
          
           if(winner)
            {
                disableButtons();
                string player = "";
                if (turn)
                {
                    player = p2.Text;
                    o_count.Text = (Int32.Parse(o_count.Text) + 1).ToString();
                }
                else
                {
                    player = p1.Text;
                    x_count.Text = (Int32.Parse(x_count.Text) + 1).ToString();
                }
                MessageBox.Show(player + " Win");
           }
            else
            {
                if (count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("DRAW", "TicTacToe");
                }
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }catch { }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            count = 0;
                foreach (Control c in Controls)
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
                }//end foreach
            }

        private void resetCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_count.Text = "0";
            x_count.Text = "0";
            draw_count.Text = "0";
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            setPlayersDefaultToolStripMenuItem.PerformClick();//при загрузке - уже этот раздел меню выбран
        }


        private void p2_txtChange(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "COMPUTER")
                against_computer = true;
            else
                against_computer = false;
        }

        private void setPlayersDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Syn";
            p2.Text = "Computer";
        }
    }


    
} 
