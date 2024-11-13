namespace BreakoutGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer gameTimer;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);

            this.SuspendLayout();

            // gamePanel
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Location = new System.Drawing.Point(10, 10);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 500);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gamePanel_MouseMove);

            // scoreLabel
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(20, 520);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(200, 40);
            this.scoreLabel.Text = "Score: 0";

            // startButton
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startButton.Location = new System.Drawing.Point(350, 520);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(120, 40);
            this.startButton.Text = "Start Game";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            // gameTimer
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);

            // Form1
            this.ClientSize = new System.Drawing.Size(820, 580);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gamePanel);
            this.Text = "Breakout Game";
            this.ResumeLayout(false);
        }
    }
}
