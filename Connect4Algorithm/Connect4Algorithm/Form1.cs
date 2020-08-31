using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] Connect4Board = new int[10, 10];
        int counter = 1;
        bool WinCheck = false;
        bool simulate = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 10; x++) //adding number labels for rows and columns
            {
                Label RowName = new Label();
                RowName.Font = new Font("Aeriel", 18);
                RowName.AutoSize = true;
                RowName.Name = Convert.ToString(x);
                RowName.Text = Convert.ToString(x + 1);
                RowName.Location = new Point(0, (ClientSize.Width / 11) * (x + 1));
                this.Controls.Add(RowName);

                Label ColumnName = new Label();
                ColumnName.Font = new Font("Aeriel", 18);
                ColumnName.AutoSize = true;
                ColumnName.Text = Convert.ToString(x + 1);
                ColumnName.Location = new Point((ClientSize.Width / 11) * (x + 1), 0);
                this.Controls.Add(ColumnName);
            }
            
            timer1.Start(); //starts the timer
        } //Form settup
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int TileWidth = ClientSize.Width / 11;
            int TileHeight = ClientSize.Height / 11; //Setting counter width and height
            Graphics g = e.Graphics;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Connect4Board[i,j] == 1) //checking for player1 or player2
                    {
                        g.FillRectangle(Brushes.Red, TileWidth * (i + 1), TileHeight * (j + 1), TileWidth, TileHeight); //Placing counter on the screen
                    }
                    if (Connect4Board[i,j] == 2)
                    {
                        g.FillRectangle(Brushes.Blue, TileWidth * (i + 1), TileHeight * (j + 1), TileWidth, TileHeight);
                    }
                }
            }
        } //Drawing the graphics
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh(); //Refreshing the graphics every tick
            win();
            if(counter == 2)
            {
                BotMove();
            }
        } //Timer itteration every 500ms
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(WinCheck == false) //Making sure game hasn't ended
            {
                int j = 0;
                switch (e.KeyCode) //Checking which key has been pressed
                {
                    case Keys.D1:
                        j = 0;
                        break;
                    case Keys.D2:
                        j = 1;
                        break;
                    case Keys.D3:
                        j = 2;
                        break;
                    case Keys.D4:
                        j = 3;
                        break;
                    case Keys.D5:
                        j = 4;
                        break;
                    case Keys.D6:
                        j = 5;
                        break;
                    case Keys.D7:
                        j = 6;
                        break;
                    case Keys.D8:
                        j = 7;
                        break;
                    case Keys.D9:
                        j = 8;
                        break;
                    case Keys.D0:
                        j = 9;
                        break;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (Connect4Board[j, i] == 1 || Connect4Board[j, i] == 2) //Checking which Row to place the counter in the column
                    {
                        int y = i - 1;
                        try
                        {
                            if (Connect4Board[j, y] != 1 && Connect4Board[j, y] != 2)
                            {
                                Connect4Board[j, y] = counter; // Placing player's counter in the array
                            }
                        }
                        catch
                        {

                        }
                        

                    }
                    else if (i == 9)
                    {
                        Connect4Board[j, i] = counter;
                    }
                }
                if (counter == 1) //Switching from player1 to player2 or visa-versa
                {
                    counter = 2;
                }
                else if (counter == 2)
                {
                    counter = 1;
                }

            }
            
        } //Taking key input
        public void win()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (Connect4Board[i,j] == 1) //checking if it's player 1 or player2
                    {
                        int counter2 = 0;
                        int check = 0;
                        while(counter2 < 3) //each block of this coppied code is checking the directions for if there is a 4 in a row
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i, j + counter2] == 1)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }
                            
                        }
                        if (check == 3) //Checks if it is a 4 in a row
                        {
                            timer1.Stop(); //stops the timer
                            MessageBox.Show("player1 wins"); //Shows who won
                            
                            i = 9; //Resets the different values and stop itteration
                            j = 9;
                            check = 0;
                        }

                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j + counter2] == 1)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }

                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player1 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }

                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j] == 1)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }

                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player1 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }

                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j - counter2] == 1)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }

                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player1 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }
                    }
                    if (Connect4Board[i,j] == 2)
                    {
                        int counter2 = 0;
                        int check = 0;
                        while(counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i, j + counter2] == 2)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }
                            
                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player2 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }


                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j + counter2] == 2)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }
                            
                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player2 wins");
                            i = 9;
                            j = 9;
                            check = 0;
                        }


                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j] == 2)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }
                            
                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player2 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }


                        counter2 = 0;
                        check = 0;
                        while (counter2 < 3)
                        {
                            counter2 = counter2 + 1;
                            try
                            {
                                if (Connect4Board[i + counter2, j - counter2] == 2)
                                {
                                    check = check + 1;
                                }
                            }
                            catch
                            {

                            }
                            
                        }
                        if (check == 3)
                        {
                            timer1.Stop();
                            MessageBox.Show("player2 wins");
                            
                            i = 9;
                            j = 9;
                            check = 0;
                        }
                    }
                }
            }

        } //Checking if anyone has won
        public void BotMove()
        {
            double[,] BotValues = new double[10, 10];
            int[,] PossibleMoves = new int[10, 10];
            int HoldX = 0;
            int HoldY = 0;
            double Hold = 0;
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (Connect4Board[i, j] == 1 || Connect4Board[i, j] == 2)
                    {
                        int y = j - 1;
                        try
                        {
                            if (Connect4Board[i, y] != 1 && Connect4Board[i, y] != 2)
                            {
                                PossibleMoves[i, y] = 1;
                            }
                        }
                        catch
                        {

                        }
                    }
                    else if (i == 9)
                    {
                        PossibleMoves[i, j] = 1;
                    }
                }
            } //checking for possible counter positions

            for(int i = 0; i < 10; i++) 
            {
                for(int j = 0; j < 10; j++)
                {
                    if(PossibleMoves[i, j] == 1)
                    {
                        double value = 0;
                        double value2 = 0;
                        int counter2 = 0;
                        int multiplier = 2;
                        //check each possition to check how many different possible wins are around it
                        while(counter2 < 3)
                        {
                            counter2 += 1;
                            try
                            {
                                if (Connect4Board[i, j - counter2] == 1)
                                {
                                    value += 1;
                                }
                            }
                            catch
                            {

                            }   //checking player1 positions

                            try
                            {
                                if (Connect4Board[i + counter2, j] == 1)
                                {
                                    value += 1;
                                }
                            }
                            catch
                            {

                            }

                            try
                            {
                                if (Connect4Board[i + counter2, j - counter2] == 1)
                                {
                                    value += 1;
                                }
                            }
                            catch
                            {

                            }

                            try
                            {
                                if (Connect4Board[i - counter2, j - counter2] == 1)
                                {
                                    value += 1;
                                }
                            }
                            catch
                            {

                            }

                            try
                            {
                                if (Connect4Board[i, j - counter2] == 2)
                                {
                                    value2 += 0.5 * counter2;
                                }
                            }
                            catch
                            {

                            } //checking player2 positions

                            try
                            {
                                if (Connect4Board[i + counter2, j] == 2)
                                {
                                    value2 += 0.5 * counter2;
                                }
                            }
                            catch
                            {

                            }

                            try
                            {
                                if (Connect4Board[i + counter2, j - counter2] == 2)
                                {
                                    value2 += 0.5 * counter2;
                                }
                            }
                            catch
                            {

                            }

                            try
                            {
                                if (Connect4Board[i - counter2, j - counter2] == 2)
                                {
                                    value2 += 0.5 * counter2;
                                }
                            }
                            catch
                            {

                            }
                            

                        }
                        if(value2 > value)
                        {
                            BotValues[i, j] = value2;
                        }
                        else
                        {
                            BotValues[i, j] = value;
                        }
                        //check each possition to see if there is an enemy win
                    }
                }
            } //calculating possible move values

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(BotValues[i,j] > Hold)
                    {
                        HoldX = i;
                        HoldY = j;
                        Hold = BotValues[i, j];
                    }
                }
            } //Finding largest value coordinates

            simulate = true;
            //switch (HoldY)
            //{
            //    case 0:
            //        SendKeys.Send("1");
            //        break;
            //    case 1:
            //        SendKeys.Send("2");
            //        break;
            //    case 2:
            //        SendKeys.Send("3");
            //        break;
            //    case 3:
            //        SendKeys.Send("4");
            //        break;
            //    case 4:
            //        SendKeys.Send("5");
            //        break;
            //    case 5:
            //        SendKeys.Send("6");
            //        break;
            //    case 6:
            //        SendKeys.Send("7");
            //        break;
            //    case 7:
            //        SendKeys.Send("8");
            //        break;
            //    case 8:
            //        SendKeys.Send("9");
            //        break;
            //    case 9:
            //        SendKeys.Send("0");
            //        break;
            //} //simulating key press
        } //Bot's move calculations
        void SimulateKeyPress(object sender, KeyEventArgs e)
        {

        }
    }
}
