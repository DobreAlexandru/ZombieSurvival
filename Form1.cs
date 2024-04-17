using System.Windows.Forms.VisualStyles;
using WMPLib;

namespace zombieSurvival
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        bool up, down, left, right;
        int direction = 4;
        int playerSpeed = 10;
        int zombieSpeed = 3;
        Random rnd = new Random();
        int level = 1, score = 0;
        int bossHp = 5, playerHp = 100;
        bool gameOver = true;

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (!gameOver)
            {
                return;
            }
            if (e.KeyCode == Keys.W)
            {
                up = true;
                direction = 1;
                player.Image = Properties.Resources.playerUp;
                player.Size = new System.Drawing.Size(70, 114);
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
                direction = 2;
                player.Image = Properties.Resources.playerLeft;
                player.Size = new System.Drawing.Size(114, 70);
            }
            if (e.KeyCode == Keys.S)
            {
                down = true;
                direction = 3;
                player.Image = Properties.Resources.playerDown;
                player.Size = new System.Drawing.Size(70, 114);
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
                direction = 4;
                player.Image = Properties.Resources.playerRight;
                player.Size = new System.Drawing.Size(114, 70);
            }

        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            WindowsMediaPlayer gunShot = new WindowsMediaPlayer();
            gunShot.URL = "D:\\vsproject\\zombieSurvival\\Images\\gunShot.mp3";
            gunShot.controls.stop();
            gunShot.settings.volume = 20;

            if (!gameOver)
            {
                return;
            }
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot(direction);
                gunShot.controls.play();
            }
        }

        private void timer(object sender, EventArgs e)
        {
            if (playerHp > 1)
            {
                hpBar.Value = Convert.ToInt32(playerHp);
            }
            else
            {
                timer1.Stop();
                spawn.Stop();
                gameOver = false;
                this.Controls.Remove(player);
                player.Dispose();
                Label over = new Label();
                over.AutoSize = false;
                over.Size = new System.Drawing.Size(300, 20);
                over.Left = 450;
                over.Top = 50;
                over.Text = "YOU LOST";
                over.BackColor = Color.Black;
                over.ForeColor = Color.White;
                over.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                over.BringToFront();

                this.Controls.Add(over);
            }
            lvl.Text = "Level: " + level;
            scr.Text = "Score: " + score;
            if (bossHp == 0)
            {
                bossHp = 5;
            }
            if (right && player.Left + player.Width < 1150)
            {
                player.Left += playerSpeed;
            }
            if (left && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (down && player.Top + player.Height < 620)
            {
                player.Top += playerSpeed;
            }
            if (up && player.Top > 10)
            {
                player.Top -= playerSpeed;
            }
            foreach (Control i in this.Controls)
            {
                if (i is PictureBox)
                {
                    if (i.Tag == "zombie" || i.Tag == "boss")
                    {
                        if (((PictureBox)i).Left > player.Left)
                        {
                            ((PictureBox)i).Left -= zombieSpeed;
                        }
                        if (((PictureBox)i).Left < player.Left)
                        {
                            ((PictureBox)i).Left += zombieSpeed;
                        }
                        if (((PictureBox)i).Top > player.Top)
                        {
                            ((PictureBox)i).Top -= zombieSpeed;
                        }
                        if (((PictureBox)i).Top < player.Top)
                        {
                            ((PictureBox)i).Top += zombieSpeed;
                        }
                    }
                }
                if (i is PictureBox && i.Tag == "zombie")
                {
                    if (i.Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHp -= 1;
                    }
                }
                if (i is PictureBox && i.Tag == "boss")
                {
                    if (i.Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHp -= 5;
                    }
                }
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag == "bullet") && (i is PictureBox && i.Tag == "zombie"))
                    {
                        if (j.Bounds.IntersectsWith(i.Bounds))
                        {

                            score++;
                            this.Controls.Remove(i);
                            i.Dispose();
                            this.Controls.Remove(j);
                            j.Dispose();
                            if (score % 10 == 0)
                            {
                                if (level < 6)
                                {
                                    level++;
                                }
                                spawnBoss();
                            }
                        }
                    }

                    if ((j is PictureBox && j.Tag == "bullet") && (i is PictureBox && i.Tag == "boss"))
                    {
                        if (j.Bounds.IntersectsWith(i.Bounds))
                        {
                            bossHp--;
                            this.Controls.Remove(j);
                            j.Dispose();
                            if (bossHp == 0)
                            {
                                score += 2;
                                this.Controls.Remove(i);
                                i.Dispose();
                                if (playerHp < 50)
                                {
                                    playerHp += 50;
                                }
                                else
                                {
                                    if (playerHp >= 50)
                                    {
                                        playerHp = 100;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void spawnZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zombieLeft;
            zombie.Left = rnd.Next(600, 1200);
            zombie.Top = rnd.Next(0, 675);
            zombie.SizeMode = PictureBoxSizeMode.Zoom;
            zombie.Size = new Size(85, 85);
            this.Controls.Add(zombie);
        }
        private void spawnBoss()
        {
            PictureBox boss = new PictureBox();
            boss.Tag = "boss";
            boss.Image = Properties.Resources.boss;
            boss.Left = 1200;
            boss.Top = rnd.Next(0, 675);
            boss.SizeMode = PictureBoxSizeMode.Zoom;
            boss.Size = new Size(150, 150);
            this.Controls.Add(boss);
        }


        private void shoot(int direction)
        {
            Ammo bullet = new Ammo();
            bullet.direction = direction;
            if (direction == 4)
            {
                bullet.bulletLeft = player.Left + (player.Width / 2);
                bullet.bulletTop = player.Top + (player.Height / 2 + 14);
            }
            if (direction == 2)
            {
                bullet.bulletLeft = player.Left + (player.Width / 2);
                bullet.bulletTop = player.Top + (player.Height / 2 - 19);
            }
            if (direction == 1)
            {
                bullet.bulletLeft = player.Left + (player.Width / 2 + 15);
                bullet.bulletTop = player.Top + (player.Height / 2);
            }
            if (direction == 3)
            {
                bullet.bulletLeft = player.Left + (player.Width / 2 - 18);
                bullet.bulletTop = player.Top + (player.Height / 2);
            }
            bullet.createBullet(this);
        }

        private void spawner(object sender, EventArgs e)
        {
            for (int i = 0; i < level; i++)
            {
                spawnZombies();
            }
        }

        private void load(object sender, EventArgs e)
        {

            WindowsMediaPlayer bgMusic = new WindowsMediaPlayer();
            bgMusic.URL = "D:\\vsproject\\zombieSurvival\\Images\\bgMusic.mp3";

            bgMusic.settings.volume = 20;
            bgMusic.controls.play();
        }
    }


}