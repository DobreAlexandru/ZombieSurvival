namespace zombieSurvival
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            player = new PictureBox();
            zombie = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            spawn = new System.Windows.Forms.Timer(components);
            hpBar = new ProgressBar();
            label1 = new Label();
            lvl = new Label();
            scr = new Label();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zombie).BeginInit();
            SuspendLayout();
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.playerRight;
            player.Location = new Point(142, 155);
            player.Name = "player";
            player.Size = new Size(114, 69);
            player.SizeMode = PictureBoxSizeMode.Zoom;
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // zombie
            // 
            zombie.BackColor = Color.Transparent;
            zombie.Image = Properties.Resources.zombieLeft;
            zombie.Location = new Point(763, 216);
            zombie.Name = "zombie";
            zombie.Size = new Size(85, 84);
            zombie.SizeMode = PictureBoxSizeMode.Zoom;
            zombie.TabIndex = 1;
            zombie.TabStop = false;
            zombie.Tag = "zombie";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer;
            // 
            // spawn
            // 
            spawn.Enabled = true;
            spawn.Interval = 3000;
            spawn.Tick += spawner;
            // 
            // hpBar
            // 
            hpBar.Location = new Point(36, 12);
            hpBar.Name = "hpBar";
            hpBar.Size = new Size(114, 23);
            hpBar.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(1, 12);
            label1.Name = "label1";
            label1.Size = new Size(29, 23);
            label1.TabIndex = 3;
            label1.Text = "HP";
            // 
            // lvl
            // 
            lvl.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lvl.Location = new Point(156, 12);
            lvl.Name = "lvl";
            lvl.Size = new Size(81, 23);
            lvl.TabIndex = 4;
            lvl.Text = "label2";
            // 
            // scr
            // 
            scr.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            scr.Location = new Point(257, 12);
            scr.Name = "scr";
            scr.Size = new Size(115, 23);
            scr.TabIndex = 5;
            scr.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(1166, 636);
            Controls.Add(scr);
            Controls.Add(lvl);
            Controls.Add(label1);
            Controls.Add(hpBar);
            Controls.Add(zombie);
            Controls.Add(player);
            MaximumSize = new Size(1182, 675);
            Name = "Form1";
            Text = "Form1";
            Load += load;
            KeyDown += keyDown;
            KeyUp += keyUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)zombie).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox player;
        private PictureBox zombie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer spawn;
        private ProgressBar hpBar;
        private Label label1;
        private Label lvl;
        private Label scr;
    }
}