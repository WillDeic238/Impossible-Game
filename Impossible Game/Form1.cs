using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impossible_Game
{
    public partial class Form1 : Form
    {
        int ballCount = 0;
        int playerSpeed = 5;
        int ballSpeed = 4;
        int ballSpeed2 = 10;

        // sector 1
        SolidBrush playerBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush goodballBrush = new SolidBrush(Color.Yellow);
        SolidBrush dangerBrush = new SolidBrush(Color.Red);
        SolidBrush safeBrush = new SolidBrush(Color.Green);
        SolidBrush borderBrush = new SolidBrush(Color.Black);

        Rectangle player = new Rectangle(25, 130, 20, 20);

        Rectangle border0 = new Rectangle(0, 50, 10, 650);
        Rectangle border1 = new Rectangle(0, 50, 900, 25);
        Rectangle border2 = new Rectangle(0, 200, 750, 25);

        Rectangle safezone1 = new Rectangle(0, 75, 60, 150);

        Rectangle dangerBall1 = new Rectangle(75, 75, 17, 17);
        Rectangle dangerBall2 = new Rectangle(120, 183, 17, 17);
        Rectangle dangerBall3 = new Rectangle(165, 75, 17, 17);
        Rectangle dangerBall4 = new Rectangle(210, 183, 17, 17);
        Rectangle dangerBall5 = new Rectangle(255, 75, 17, 17);

        //Sector 2
        Rectangle border3 = new Rectangle(310, 120, 20, 80);



        Rectangle dangerBalls1 = new Rectangle(844, 138, 31, 31);
        Rectangle dangerBalls2 = new Rectangle(844, 169, 31, 31);
        Rectangle dangerBalls3 = new Rectangle(330, 75, 31, 31);
        Rectangle dangerBalls4 = new Rectangle(330, 106, 31, 31);

        //Sector 3
        Rectangle border4 = new Rectangle(875, 50, 25, 625);

        bool wpressed = false;
        bool apressed = false;
        bool spressed = false;
        bool dpressed = false;

        List<Rectangle> walls = new List<Rectangle>();


        public Form1()
        {
            InitializeComponent();
        }
        public void InitializeGame()
        {
            gameTimer.Enabled = true;
            titleLabel.Text = "";
            startLabel.Text = "";
            titleLabel.BackColor = Color.Transparent;
            startLabel.BackColor = Color.Transparent;
            scoreLabel.Text = $"{ballCount}/4";

            walls.Add(border0);
            walls.Add(border1);
            walls.Add(border2);
            walls.Add(border3);
            walls.Add(border4);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch(e.KeyCode)
            {
                case Keys.W:
                    {
                        wpressed = false;
                    }
                    break;
                case Keys.A:
                    {
                        apressed = false;
                    }
                    break;
                case Keys.S:
                    {
                        spressed = false;
                    }
                    break;
                case Keys.D:
                    {
                        dpressed = false;
                    }
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {              
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled == false)
                    {
                        InitializeGame();
                    }
                    break;
                case Keys.W:
                    {
                        wpressed = true;
                    }
                    break;
                case Keys.A:
                    {
                        apressed = true;
                    }
                    break;
                case Keys.S:
                    {
                        spressed = true;
                    }
                    break;
                case Keys.D:                    
                    {
                        dpressed = true;
                    }
                    break;
            }
        }        
        private void gameTimer_Tick(object sender, EventArgs e)
        {    
            int x = player.X;
            int y = player.Y;

            #region move player
            if (wpressed == true)
            {
                 player.Y = player.Y - playerSpeed;
            }
            if (spressed == true)
            {
                 player.Y = player.Y + playerSpeed;
            }
            if (apressed == true)
            {
                 player.X = player.X - playerSpeed;
            }
            if (dpressed == true)
            {
                player.X = player.X + playerSpeed;
            }
            #endregion

            #region move balls
            // Section 1
            dangerBall1.Y = dangerBall1.Y + ballSpeed; 

            if(dangerBall1.IntersectsWith(border1))
            {
                ballSpeed *= -1;
                //dangerBall1.Y = dangerBall1.Y + ballSpeed;
            }
            else if (dangerBall1.IntersectsWith(border2))
            {
                ballSpeed *= -1;

                //dangerBall1.Y = dangerBall1.Y - ballSpeed;
            }
            dangerBall2.Y = dangerBall2.Y - ballSpeed;
            dangerBall3.Y = dangerBall3.Y + ballSpeed;
            dangerBall4.Y = dangerBall4.Y - ballSpeed;
            dangerBall5.Y = dangerBall5.Y + ballSpeed;


            //Section 2
            dangerBalls1.X = dangerBalls1.X - ballSpeed2;

            if (dangerBalls1.IntersectsWith(border3))
            {
                ballSpeed2 *= -1;
                //dangerBall1.Y = dangerBall1.Y + ballSpeed;
            }
            if (dangerBalls1.IntersectsWith(border4))
            {
                ballSpeed2 *= -1;

                //dangerBall1.Y = dangerBall1.Y - ballSpeed;
            }
            dangerBalls2.X = dangerBalls2.X - ballSpeed2;
            dangerBalls3.X = dangerBalls3.X + ballSpeed2;
            dangerBalls4.X = dangerBalls4.X + ballSpeed2;
            

            #endregion

            #region player danger collision
            if (player.IntersectsWith(dangerBall1))
              {
                  player.X = 25;
                  player.Y = 130;
              }
              else if (player.IntersectsWith(dangerBall2))
              {
                  player.X = 25;
                  player.Y = 130;
              }
              else if(player.IntersectsWith(dangerBall3))
              {
                  player.X = 25;
                  player.Y = 130;
              }
              else if (player.IntersectsWith(dangerBall4))
              {
                  player.X = 25;
                  player.Y = 130;
              }
              else if (player.IntersectsWith(dangerBall5))
              {
                  player.X = 25;
                  player.Y = 130;
              }

            //Sector 2
            if (player.IntersectsWith(dangerBalls1))
            {
                player.X = 25;
                player.Y = 130;
            }
            else if (player.IntersectsWith(dangerBalls2))
            {
                player.X = 25;
                player.Y = 130;
            }
            else if (player.IntersectsWith(dangerBalls3))
            {
                player.X = 25;
                player.Y = 130;
            }
            else if (player.IntersectsWith(dangerBalls4))
            {
                player.X = 25;
                player.Y = 130;
            }

                #endregion

                #region wall collisions


                for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].IntersectsWith(player))
                {
                    player.X = x;
                    player.Y = y;   
                }
            }
           
            #endregion


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(gameTimer.Enabled == true)
            { 
                //Sector 1
                e.Graphics.FillRectangle(safeBrush, safezone1);

                e.Graphics.FillRectangle(playerBrush, player);

                e.Graphics.FillEllipse(dangerBrush, dangerBall1);
                e.Graphics.FillEllipse(dangerBrush, dangerBall2);
                e.Graphics.FillEllipse(dangerBrush, dangerBall3);
                e.Graphics.FillEllipse(dangerBrush, dangerBall4);
                e.Graphics.FillEllipse(dangerBrush, dangerBall5);

                //draw walls
                for (int i = 0; i < walls.Count; i++)
                {
                    e.Graphics.FillRectangle(borderBrush, walls[i]);
                }

                //Sector
                e.Graphics.FillEllipse(dangerBrush, dangerBalls1);
                e.Graphics.FillEllipse(dangerBrush, dangerBalls2);
                e.Graphics.FillEllipse(dangerBrush, dangerBalls3);
                e.Graphics.FillEllipse(dangerBrush, dangerBalls4);



            }
        }


    }
}