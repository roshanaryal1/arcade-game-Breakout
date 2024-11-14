using System.Windows.Forms;

namespace BreakoutGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel gamePanel;
        private Button startButton;
        private Label scoreLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // gamePanel
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Location = new System.Drawing.Point(10, 10);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 600);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);

            // startButton
            this.startButton.Location = new System.Drawing.Point(10, 630);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 30);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);

            // scoreLabel
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(120, 630);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(46, 17);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score: 0";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 670);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gamePanel);
            this.Name = "Form1";
            this.Text = "Breakout Game";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
