using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird_windows
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            //Pusher Mario ned!
            flappyBird.Top += gravity;

            //flytter Podoomo til venstre
            pipiBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;

            // for å samle score.
            scoreText.Text = "Score: " + score;

            //For at podoomo skal gjenta seg 
            if (pipiBottom.Left < -150)
            {
                pipiBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipiBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 11;
            }

            if (score > 20)
            {
                pipeSpeed = 16;
            }

            if (score > 40)
            {
                pipeSpeed = 21;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over!";
        }
    }
}
