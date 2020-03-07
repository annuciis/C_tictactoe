using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    public partial class Game : Form
    {
        Boolean player1 = true; //// player1's turn or not 
        Boolean player2 = false;

        Image x = Properties.Resources.x; /// Image for Player 1, in this case X 
        Image o = Properties.Resources.o; /// Image for Player 2, in this case O

        int moveCounter = 1; /// counts how many field got clicked 
        Boolean win = false;

      
        



        public Game()
        {
            InitializeComponent();
            this.BackColor = Color.Violet;
        }

        

        private void Tile_Click(object sender, EventArgs e)
        {
            var tile = (PictureBox)sender;
            if (tile.Image != null)
            {
                return; //iziet no programmas
            }

            if (player1 == true)

                {
                tile.Image = x;
                tile.Tag = "X";
                    
                }
                else if (player2 == true)
                {
                tile.Image = o;
                tile.Tag = "O";
                }
            CheckForWin();
            SwitchTurn();


        }


        private void CompareThreeTiles(PictureBox t1, PictureBox t2, PictureBox t3)
        {
            if(t1.Tag == t2.Tag && t2.Tag == t3.Tag && t1.Tag.ToString() != "box")
            {
                win = true;
                GameWin();
                
            }
            
        }
        private void CheckForWin()
        {
            CompareThreeTiles(pictureBox1, pictureBox2, pictureBox3);
            CompareThreeTiles(pictureBox4, pictureBox5, pictureBox6);
            CompareThreeTiles(pictureBox7, pictureBox8, pictureBox9);
            CompareThreeTiles(pictureBox1, pictureBox4, pictureBox7);
            CompareThreeTiles(pictureBox2, pictureBox5, pictureBox8);
            CompareThreeTiles(pictureBox3, pictureBox6, pictureBox9);
            CompareThreeTiles(pictureBox1, pictureBox5, pictureBox9);
            CompareThreeTiles(pictureBox3, pictureBox5, pictureBox7);

            if(moveCounter == 9 && win == false )
            {
                GameDraw();
            }


        }
        private void SwitchTurn()
        {
            if (player1)
            {
                player1  = false;
                player2 = true;

            }
            else if (player2)
            {
                player2 = false;
                player1 = true;
            }
            moveCounter += 1;
        }

        private void GameWin()
        {
            if (player1)
            {
                MessageBox.Show("Player 1 wins!");
            }
            else if(player2)
            {
                MessageBox.Show("Player 2 wins!");
                    }
            
        }
        private void GameDraw()
        {
            MessageBox.Show("Draw!");
        }

       
    }
    

   
}
