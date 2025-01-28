namespace TicTacToe
{
    partial class AI_TicTacToeForm
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
            panelAIButtons = new Panel();
            buttonAIPlayer = new Button();
            labelAIPlayer = new Label();
            buttonAIReverse = new Button();
            resetAIButton = new Button();
            colorAIButton = new Button();
            musicAIButton = new Button();
            buttonAIChanger = new Button();
            textAIPlayer2 = new TextBox();
            textAIPlayer1 = new TextBox();
            labelAIScoreboard = new Label();
            SuspendLayout();
            // 
            // panelAIButtons
            // 
            panelAIButtons.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            panelAIButtons.Location = new Point(41, 68);
            panelAIButtons.Margin = new Padding(4);
            panelAIButtons.Name = "panelAIButtons";
            panelAIButtons.Size = new Size(615, 707);
            panelAIButtons.TabIndex = 1;
            // 
            // buttonAIPlayer
            // 
            buttonAIPlayer.BackColor = SystemColors.ButtonHighlight;
            buttonAIPlayer.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold);
            buttonAIPlayer.Location = new Point(716, 99);
            buttonAIPlayer.Margin = new Padding(4);
            buttonAIPlayer.Name = "buttonAIPlayer";
            buttonAIPlayer.Size = new Size(133, 123);
            buttonAIPlayer.TabIndex = 1;
            buttonAIPlayer.Text = "X";
            buttonAIPlayer.UseVisualStyleBackColor = false;
            buttonAIPlayer.Click += OnPlayerMove;
            // 
            // labelAIPlayer
            // 
            labelAIPlayer.AutoSize = true;
            labelAIPlayer.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAIPlayer.Location = new Point(716, 64);
            labelAIPlayer.Margin = new Padding(4, 0, 4, 0);
            labelAIPlayer.Name = "labelAIPlayer";
            labelAIPlayer.Size = new Size(97, 31);
            labelAIPlayer.TabIndex = 2;
            labelAIPlayer.Text = "Player";
            // 
            // buttonAIReverse
            // 
            buttonAIReverse.Location = new Point(740, 447);
            buttonAIReverse.Name = "buttonAIReverse";
            buttonAIReverse.Size = new Size(59, 71);
            buttonAIReverse.TabIndex = 16;
            buttonAIReverse.UseVisualStyleBackColor = true;
            buttonAIReverse.Click += buttonAIReverse_Click;
            // 
            // resetAIButton
            // 
            resetAIButton.BackColor = SystemColors.ActiveBorder;
            resetAIButton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Underline);
            resetAIButton.ImageAlign = ContentAlignment.MiddleRight;
            resetAIButton.Location = new Point(121, 860);
            resetAIButton.Name = "resetAIButton";
            resetAIButton.Size = new Size(458, 45);
            resetAIButton.TabIndex = 15;
            resetAIButton.Text = "RESET!";
            resetAIButton.UseVisualStyleBackColor = false;
            resetAIButton.Click += resetAIButton_Click;
            // 
            // colorAIButton
            // 
            colorAIButton.BackColor = Color.Yellow;
            colorAIButton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            colorAIButton.Location = new Point(716, 672);
            colorAIButton.Name = "colorAIButton";
            colorAIButton.Size = new Size(119, 103);
            colorAIButton.TabIndex = 14;
            colorAIButton.Text = "НОВ ЦВЯТ";
            colorAIButton.UseVisualStyleBackColor = false;
            colorAIButton.Click += colorAIButton_Click;
            // 
            // musicAIButton
            // 
            musicAIButton.BackColor = Color.LightGreen;
            musicAIButton.Location = new Point(41, 801);
            musicAIButton.Name = "musicAIButton";
            musicAIButton.Size = new Size(615, 53);
            musicAIButton.TabIndex = 13;
            musicAIButton.UseVisualStyleBackColor = false;
            musicAIButton.Click += musicAIButton_Click;
            // 
            // buttonAIChanger
            // 
            buttonAIChanger.BackColor = SystemColors.Info;
            buttonAIChanger.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            buttonAIChanger.Location = new Point(716, 571);
            buttonAIChanger.Name = "buttonAIChanger";
            buttonAIChanger.Size = new Size(119, 47);
            buttonAIChanger.TabIndex = 12;
            buttonAIChanger.Text = "СМЯНА";
            buttonAIChanger.UseVisualStyleBackColor = false;
            buttonAIChanger.Click += buttonAIChanger_Click;
            // 
            // textAIPlayer2
            // 
            textAIPlayer2.Location = new Point(702, 524);
            textAIPlayer2.Name = "textAIPlayer2";
            textAIPlayer2.RightToLeft = RightToLeft.Yes;
            textAIPlayer2.Size = new Size(144, 27);
            textAIPlayer2.TabIndex = 11;
            // 
            // textAIPlayer1
            // 
            textAIPlayer1.Location = new Point(702, 403);
            textAIPlayer1.Name = "textAIPlayer1";
            textAIPlayer1.Size = new Size(144, 27);
            textAIPlayer1.TabIndex = 10;
            // 
            // labelAIScoreboard
            // 
            labelAIScoreboard.BackColor = SystemColors.Highlight;
            labelAIScoreboard.Font = new Font("Microsoft Sans Serif", 4F, FontStyle.Bold);
            labelAIScoreboard.Location = new Point(677, 261);
            labelAIScoreboard.Name = "labelAIScoreboard";
            labelAIScoreboard.Padding = new Padding(4);
            labelAIScoreboard.Size = new Size(205, 101);
            labelAIScoreboard.TabIndex = 9;
            labelAIScoreboard.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AI_TicTacToeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 919);
            Controls.Add(buttonAIReverse);
            Controls.Add(resetAIButton);
            Controls.Add(colorAIButton);
            Controls.Add(musicAIButton);
            Controls.Add(buttonAIChanger);
            Controls.Add(textAIPlayer2);
            Controls.Add(textAIPlayer1);
            Controls.Add(labelAIScoreboard);
            Controls.Add(labelAIPlayer);
            Controls.Add(buttonAIPlayer);
            Controls.Add(panelAIButtons);
            Name = "AI_TicTacToeForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelAIButtons;
        private Button buttonAIPlayer;
        private Label labelAIPlayer;
        private Button buttonReverse;
        private Button resetButton;
        private Button colorButton;
        private Button musicButton;
        private Button buttonChanger;
        private TextBox textPlayer2;
        private TextBox textPlayer1;
        private Label labelScoreboard;
        private Button buttonAIReverse;
        private Button resetAIButton;
        private Button colorAIButton;
        private Button musicAIButton;
        private Button buttonAIChanger;
        private TextBox textAIPlayer2;
        private TextBox textAIPlayer1;
        private Label labelAIScoreboard;
    }
}
