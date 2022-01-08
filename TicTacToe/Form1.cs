using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        
        private Button[,] buttons = new Button[3,3];
        private int player;
        public Form1()
        {
            InitializeComponent();
            this.Text = "TicTacToe";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.Width = 700;
            this.Height = 550;
            player = 1;
            label1.Text = "Ходит Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                }
            }
            setButtons();
        }
        private void setButtons()
        {
            for(int i=0; i<3;i++)
            {
                for(int j=0; j<3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 156 * j, 12 + 156 * i);
                    buttons[i, j].Click += buttons_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 100);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button but = new Button();
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");
                   
                    player = 0;
                    label1.Text = "Ходит Игрок 2";
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");
                    player = 1;
                    label1.Text = "Ходит Игрок 2";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            WhoWin();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //restart
            for(int i=0; i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled= true;
                }
            }
        }

        private void WhoWin()
        {
          if(buttons[0,0].Text==buttons[0,1].Text&&buttons[0,1].Text==buttons[0,2].Text)
            {
                if(buttons[0,0].Text!="")
                {
                    winner();
                    return;
                }
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text != "")
                {
                    winner();
                    return;
                }
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                {
                    winner();
                    return;
                }
            }
            //vertical
            if (buttons[0, 0].Text == buttons[1,0].Text && buttons[1, 0].Text == buttons[2,0].Text)
            {
                if (buttons[0, 0].Text != "")
                {
                    winner();
                    return;
                }
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2,1].Text)
            {
                if (buttons[0, 1].Text != "")
                {
                    winner();
                    return;
                }
            }
            if (buttons[0,2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text != "")
                {
                    winner();
                    return;
                }
            }
            //diagonals
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[1, 1].Text != "")
                {
                    winner();
                    return;
                }
            }
            if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text)
            {
                if (buttons[1, 1].Text != "")
                {
                    winner();
                    return;
                }
            } 
        }
        private void winner()
        {
            if (player == 1)
            {
                MessageBox.Show("Победил Нолик");
            }
                if (player == 0)
                {
                    MessageBox.Show("Победил Крестик");
                }
            }
    }
}
