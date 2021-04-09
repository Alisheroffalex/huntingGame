using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunting_Game
{
    public partial class Form2 : Form
    {

        public int level = 1;
        public int timerTime = 0;
        public int reward = 0;
        public int score = 0;
        public int formWidth = 0;
        public int formHeight = 0;
        public int pictureWidth = 0;
        public int pictureHeight = 0;
        public PictureBox picture;
        public Form2()
        {
            InitializeComponent();
            this.pictureWidth = this.pictureBox1.Width;
            this.pictureHeight= this.pictureBox1.Height;
        }

        

        

        public void initUserToGame(string username)
        {
            this.Show();
            this.username.Text = (username.Length == 0) ? "No name" : username;
        }

        private void exitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void startClick(object sender, EventArgs e)
        {
            picture = this.getRandomPictureBox();
            this.resetAll();

            if(radioButton1.Checked)
            {
                this.timerTime = 14;
            } else if (radioButton2.Checked)
            {
                this.timerTime = 10;
            } else if (radioButton3.Checked)
            {
                this.timerTime = 7;
            } else
            {
                MessageBox.Show("Choose Difficulty");
                return;
            }
            

            this.reward = this.timerTime;
            


            initPictureRandomly(this.picture);

            this.switchControllersEnable(false);

            this.timer1.Start();
            this.timeLeft.Text = this.timerTime.ToString();

            this.formWidth = this.Width;
            this.formHeight = this.Height;
            
        }


        public void initPictureRandomly(PictureBox picture)
        {

            Random random = new Random();

            int y = random.Next(this.picturesContainer.Height - picture.Height);
            int x = random.Next(this.picturesContainer.Width - picture.Width);
            picture.Location = new Point(x,y);
            picture.Visible = true;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timerTime--;

            this.timeLeft.Text = timerTime.ToString();


            if (this.timerTime == 0)
            {
                this.timer1.Stop();
                this.gameOverLabel.Text = "Game Over \n Your score: "+this.score.ToString();
                this.switchControllersEnable(true);
                this.gameOverLabel.Visible = true;
                this.picture.Visible = false;   
            }

            
        }

        private void pictureClick(object sender, EventArgs e)
        {
            initPictureRandomly(this.picture);
            this.score++;

            this.label3.Text = this.score.ToString();

            if (this.score % 10 == 0)
            {
                this.LevelUp();
            }
        }

        public void LevelUp()
        {
            this.level++;
            this.timerTime = this.reward;
            this.picture.Visible = false;

            int lastPictureWidth = this.picture.Width;
            int lastPictureHeight = this.picture.Height;

            this.picture = this.getRandomPictureBox();
            this.picture.Width = lastPictureWidth;
            this.picture.Height= lastPictureHeight;
            if (this.level == 2 || this.level == 3 || this.level == 4 || this.level == 5 || this.level == 6)
            {
                this.Width += 30;
                this.Height += 30;

                this.picture.Width -= 7;
                this.picture.Height -= 7;
            }

            
        }

        public void resetAll()
        {
            this.gameOverLabel.Visible = false;
            if (this.score > 0)
            {
                this.Width = formWidth;
                this.Height = formHeight;
                this.picture.Width = this.pictureWidth;
                this.picture.Height = this.pictureHeight;
            }

            level = 1;
            timerTime = 0;
            reward = 0;
            score = 0;
            this.picture.Visible = false;
        }


        public void switchControllersEnable(Boolean makeDisabled = true)
        {
            this.difficultyGroup.Enabled = makeDisabled;
            this.startButton.Enabled = makeDisabled;
        }

        public PictureBox getRandomPictureBox()
        {
            PictureBox[] pictures = { this.pictureBox1, this.pictureBox2, this.pictureBox3, this.pictureBox4, this.pictureBox5, this.pictureBox6, this.pictureBox7 };
            int randomIndex = new Random().Next(0,pictures.Length);

            pictures[randomIndex].Visible = true;
            return pictures[randomIndex];        
        }

        
    }
}
