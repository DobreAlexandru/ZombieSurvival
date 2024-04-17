using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieSurvival
{
    internal class Ammo
    {
        PictureBox bullet = new PictureBox();
        System.Windows.Forms.Timer shootTimer = new System.Windows.Forms.Timer();
        public int direction;
        private int bulletSpeed = 30;
        public int bulletLeft, bulletTop;
        public void createBullet(Form form)
        {
            bullet.Size = new Size(5, 5);
            bullet.BackColor = Color.White;
            bullet.Tag = "bullet";
            bullet.BringToFront();
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            form.Controls.Add(bullet);
            shootTimer.Interval = 30;
            shootTimer.Tick += new EventHandler(shootTimerTick);
            shootTimer.Start();
        }

        public void shootTimerTick(object sender, EventArgs e)
        {
            if (direction == 1)
            {
                bullet.Top -= bulletSpeed;
               
            }
            if (direction == 2)
            {
                bullet.Left -= bulletSpeed;
                
            }
            if (direction == 3)
            {
                bullet.Top += bulletSpeed;
                
            }
            if (direction == 4)
            {
                bullet.Left += bulletSpeed;
               
            }

            if(bullet.Left < 10 || bullet.Left > 1150 || bullet.Top < 10 || bullet.Top > 620)
            {
                shootTimer.Stop();
                shootTimer.Dispose();
                bullet.Dispose();
                shootTimer = null;
                bullet = null;
               
            }
        }


    }
}
