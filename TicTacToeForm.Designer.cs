namespace TicTacToe
{
    partial class TicTacToeForm
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
            panelButtons = new Panel();
            musicButton = new Button();
            buttonPlayer = new Button();
            labelPlayer = new Label();
            labelScoreboard = new Label();
            textPlayer1 = new TextBox();
            textPlayer2 = new TextBox();
            buttonChanger = new Button();
            colorButton = new Button();
            resetButton = new Button();
            buttonReverse = new Button();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.Location = new Point(35, 31);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(600, 736);
            panelButtons.TabIndex = 0;
            // 
            // musicButton
            // 
            musicButton.BackColor = Color.LightGreen;
            musicButton.Location = new Point(35, 774);
            musicButton.Name = "musicButton";
            musicButton.Size = new Size(600, 53);
            musicButton.TabIndex = 5;
            musicButton.UseVisualStyleBackColor = false;
            // 
            // buttonPlayer
            // 
            buttonPlayer.BackColor = SystemColors.ButtonHighlight;
            buttonPlayer.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold);
            buttonPlayer.Location = new Point(692, 65);
            buttonPlayer.Margin = new Padding(4);
            buttonPlayer.Name = "buttonPlayer";
            buttonPlayer.Size = new Size(133, 123);
            buttonPlayer.TabIndex = 0;
            buttonPlayer.Text = "X";
            buttonPlayer.UseVisualStyleBackColor = false;
            // 
            // labelPlayer
            // 
            labelPlayer.AutoSize = true;
            labelPlayer.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPlayer.Location = new Point(692, 30);
            labelPlayer.Margin = new Padding(4, 0, 4, 0);
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Size = new Size(97, 31);
            labelPlayer.TabIndex = 0;
            labelPlayer.Text = "Player";
            // 
            // labelScoreboard
            // 
            labelScoreboard.BackColor = SystemColors.Highlight;
            labelScoreboard.Font = new Font("Microsoft Sans Serif", 4F, FontStyle.Bold);
            labelScoreboard.Location = new Point(652, 222);
            labelScoreboard.Name = "labelScoreboard";
            labelScoreboard.Padding = new Padding(4);
            labelScoreboard.Size = new Size(205, 101);
            labelScoreboard.TabIndex = 1;
            labelScoreboard.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textPlayer1
            // 
            textPlayer1.Location = new Point(692, 358);
            textPlayer1.Name = "textPlayer1";
            textPlayer1.Size = new Size(144, 27);
            textPlayer1.TabIndex = 2;
            // 
            // textPlayer2
            // 
            textPlayer2.Location = new Point(692, 479);
            textPlayer2.Name = "textPlayer2";
            textPlayer2.Size = new Size(144, 27);
            textPlayer2.TabIndex = 3;
            textPlayer2.TextChanged += textPlayer2_TextChanged;
            // 
            // buttonChanger
            // 
            buttonChanger.BackColor = SystemColors.Info;
            buttonChanger.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            buttonChanger.Location = new Point(706, 526);
            buttonChanger.Name = "buttonChanger";
            buttonChanger.Size = new Size(119, 47);
            buttonChanger.TabIndex = 4;
            buttonChanger.Text = "СМЯНА";
            buttonChanger.UseVisualStyleBackColor = false;
            buttonChanger.Click += buttonChanger_Click;
            // 
            // colorButton
            // 
            colorButton.BackColor = Color.Yellow;
            colorButton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            colorButton.Location = new Point(706, 627);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(119, 103);
            colorButton.TabIndex = 6;
            colorButton.Text = "НОВ ЦВЯТ";
            colorButton.UseVisualStyleBackColor = false;
            colorButton.Click += colorButton_Click_1;
            // 
            // resetButton
            // 
            resetButton.BackColor = SystemColors.ActiveBorder;
            resetButton.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Underline);
            resetButton.ImageAlign = ContentAlignment.MiddleRight;
            resetButton.Location = new Point(115, 833);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(443, 45);
            resetButton.TabIndex = 7;
            resetButton.Text = "RESET!";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += ResetButton_Click;
            // 
            // buttonReverse
            // 
            buttonReverse.Location = new Point(730, 402);
            buttonReverse.Name = "buttonReverse";
            buttonReverse.Size = new Size(59, 59);
            buttonReverse.TabIndex = 8;
            buttonReverse.UseVisualStyleBackColor = true;
            // 
            // TicTacToeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 889);
            Controls.Add(buttonReverse);
            Controls.Add(resetButton);
            Controls.Add(colorButton);
            Controls.Add(musicButton);
            Controls.Add(buttonChanger);
            Controls.Add(textPlayer2);
            Controls.Add(textPlayer1);
            Controls.Add(labelScoreboard);
            Controls.Add(labelPlayer);
            Controls.Add(buttonPlayer);
            Controls.Add(panelButtons);
            Name = "TicTacToeForm";
            Text = "Tic Tac Toe";
            Load += TicTacToeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelButtons;
        private Button buttonPlayer;
        private Label labelPlayer;
        private Label labelScoreboard;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textPlayer1;
        private TextBox textPlayer2;
        private Button buttonChanger;
        private Button musicButton;
        private Button colorButton;
        private Button button1;
        private Button resetButton;
        private Button buttonReverse;
    }
}
