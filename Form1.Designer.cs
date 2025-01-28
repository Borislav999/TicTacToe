namespace TicTacToe
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelGameMode = new Label();
            labelForWelcome = new Label();
            buttonTwoPlayers = new Button();
            buttonEasy = new Button();
            buttonMedium = new Button();
            buttonHard = new Button();
            buttonSinglePlayer = new Button();
            panelDifficulty = new Panel();
            labelDifficulty = new Label();
            panelDifficulty.SuspendLayout();
            SuspendLayout();
            // 
            // labelGameMode
            // 
            labelGameMode.AutoSize = true;
            labelGameMode.BackColor = SystemColors.Info;
            labelGameMode.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelGameMode.Location = new Point(286, 161);
            labelGameMode.Name = "labelGameMode";
            labelGameMode.Size = new Size(214, 32);
            labelGameMode.TabIndex = 0;
            labelGameMode.Text = "Режим на играта";
            // 
            // labelForWelcome
            // 
            labelForWelcome.AutoSize = true;
            labelForWelcome.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            labelForWelcome.Location = new Point(226, 57);
            labelForWelcome.Name = "labelForWelcome";
            labelForWelcome.Size = new Size(321, 57);
            labelForWelcome.TabIndex = 1;
            labelForWelcome.Text = "МОРСКИ ШАХ";
            labelForWelcome.TextAlign = ContentAlignment.MiddleCenter;
            labelForWelcome.Click += labelForWelcome_Click;
            // 
            // buttonTwoPlayers
            // 
            buttonTwoPlayers.BackColor = SystemColors.Highlight;
            buttonTwoPlayers.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonTwoPlayers.Location = new Point(198, 208);
            buttonTwoPlayers.Name = "buttonTwoPlayers";
            buttonTwoPlayers.Size = new Size(364, 44);
            buttonTwoPlayers.TabIndex = 3;
            buttonTwoPlayers.Text = "ДВАМА ИГРАЧИ";
            buttonTwoPlayers.TextAlign = ContentAlignment.TopCenter;
            buttonTwoPlayers.UseVisualStyleBackColor = false;
            buttonTwoPlayers.Click += buttonTwoPlayers_Click;
            // 
            // buttonEasy
            // 
            buttonEasy.BackColor = Color.YellowGreen;
            buttonEasy.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            buttonEasy.Location = new Point(27, 50);
            buttonEasy.Name = "buttonEasy";
            buttonEasy.Size = new Size(118, 45);
            buttonEasy.TabIndex = 4;
            buttonEasy.Text = "Лесно";
            buttonEasy.UseVisualStyleBackColor = false;
            buttonEasy.Visible = false;
            buttonEasy.Click += buttonEasy_Click;
            // 
            // buttonMedium
            // 
            buttonMedium.BackColor = Color.FromArgb(255, 128, 0);
            buttonMedium.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonMedium.Location = new Point(188, 50);
            buttonMedium.Name = "buttonMedium";
            buttonMedium.Size = new Size(124, 45);
            buttonMedium.TabIndex = 5;
            buttonMedium.Text = "Средно";
            buttonMedium.UseVisualStyleBackColor = false;
            buttonMedium.Visible = false;
            buttonMedium.Click += buttonMedium_Click;
            // 
            // buttonHard
            // 
            buttonHard.BackColor = Color.Red;
            buttonHard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonHard.Location = new Point(348, 50);
            buttonHard.Name = "buttonHard";
            buttonHard.Size = new Size(121, 45);
            buttonHard.TabIndex = 6;
            buttonHard.Text = "Трдуно";
            buttonHard.UseVisualStyleBackColor = false;
            buttonHard.Visible = false;
            buttonHard.Click += buttonHard_Click;
            // 
            // buttonSinglePlayer
            // 
            buttonSinglePlayer.BackColor = SystemColors.Highlight;
            buttonSinglePlayer.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonSinglePlayer.Location = new Point(198, 270);
            buttonSinglePlayer.Name = "buttonSinglePlayer";
            buttonSinglePlayer.Size = new Size(364, 44);
            buttonSinglePlayer.TabIndex = 7;
            buttonSinglePlayer.Text = "ЕДИН ИГРАЧ (AI-опонент)";
            buttonSinglePlayer.TextAlign = ContentAlignment.TopCenter;
            buttonSinglePlayer.UseVisualStyleBackColor = false;
            buttonSinglePlayer.Click += buttonSinglePlayer_Click;
            // 
            // panelDifficulty
            // 
            panelDifficulty.BackgroundImageLayout = ImageLayout.Center;
            panelDifficulty.BorderStyle = BorderStyle.FixedSingle;
            panelDifficulty.Controls.Add(labelDifficulty);
            panelDifficulty.Controls.Add(buttonHard);
            panelDifficulty.Controls.Add(buttonMedium);
            panelDifficulty.Controls.Add(buttonEasy);
            panelDifficulty.Location = new Point(133, 333);
            panelDifficulty.Name = "panelDifficulty";
            panelDifficulty.Size = new Size(495, 105);
            panelDifficulty.TabIndex = 8;
            panelDifficulty.Visible = false;
            // 
            // labelDifficulty
            // 
            labelDifficulty.AutoSize = true;
            labelDifficulty.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            labelDifficulty.Location = new Point(143, 5);
            labelDifficulty.Name = "labelDifficulty";
            labelDifficulty.Size = new Size(205, 29);
            labelDifficulty.TabIndex = 9;
            labelDifficulty.Text = "Ниво на трудност";
            labelDifficulty.TextAlign = ContentAlignment.MiddleCenter;
            labelDifficulty.Visible = false;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelDifficulty);
            Controls.Add(buttonSinglePlayer);
            Controls.Add(buttonTwoPlayers);
            Controls.Add(labelForWelcome);
            Controls.Add(labelGameMode);
            Name = "StartForm";
            Text = "Form1";
            panelDifficulty.ResumeLayout(false);
            panelDifficulty.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelGameMode;
        private Label labelForWelcome;
        private Button buttonTwoPlayers;
        private Button buttonEasy;
        private Button buttonMedium;
        private Button buttonHard;
        private Label labelSinglePlayer;
        private Button button1;
        private Button buttonSinglePlayer;
        private Panel panel1;
        private Panel panelDifficulty;
        private Label labelDifficulty;
    }
}