using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private int playerXWins = 0;
        private int playerOWins = 0;
        private int movesCount = 0;
        private string player1Symbol = "X";
        private string player2Symbol = "O";
        private WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        private bool isMusicPlaying = false;
        private Random random = new Random();

        public TicTacToeForm()
        {
            InitializeComponent();
            SetPlaceholders();
            InitializeMusicButtonHandler();
            InitializeColorButtonHandler();
            InitializeReverseButtonHandler();
        }

        private void SetPlaceholders()
        {
            textPlayer1.Text = "Символ за играч X:";
            textPlayer1.ForeColor = Color.Gray;

            textPlayer2.Text = "Символ за играч O:";
            textPlayer2.ForeColor = Color.Gray;

            textPlayer1.GotFocus += (sender, e) =>
            {
                if (textPlayer1.Text == "Символ за играч X:")
                {
                    textPlayer1.Text = "";
                    textPlayer1.ForeColor = Color.Black;
                }
            };

            textPlayer1.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textPlayer1.Text))
                {
                    textPlayer1.Text = "Символ за играч X:";
                    textPlayer1.ForeColor = Color.Gray;
                }
            };

            textPlayer2.GotFocus += (sender, e) =>
            {
                if (textPlayer2.Text == "Символ за играч O:")
                {
                    textPlayer2.Text = "";
                    textPlayer2.ForeColor = Color.Black;
                }
            };

            textPlayer2.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textPlayer2.Text))
                {
                    textPlayer2.Text = "Символ за играч O:";
                    textPlayer2.ForeColor = Color.Gray;
                }
            };
        }

        private void InitializeMusicButtonHandler()
        {
            musicButton.Text = "\u25B6";
            musicButton.Font = new Font(DefaultFont.FontFamily, 20, FontStyle.Bold);
            musicButton.Click += ToggleMusic;
        }

        private void InitializeColorButtonHandler()
        {
            colorButton.Click += ChangeBackgroundColor;
        }

        private void ToggleMusic(object sender, EventArgs e)
        {
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Havana.wav");

            if (isMusicPlaying)
            {
                musicPlayer.controls.stop();
                musicButton.Text = "\u25B6"; 
                isMusicPlaying = false;
            }
            else
            {
               
                if (!System.IO.File.Exists(tempFilePath))
                {
                    using (var resourceStream = TicTacToe.Resource1.havanata)
                    {
                        using (var fileStream = new System.IO.FileStream(tempFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                }

                musicPlayer.URL = tempFilePath;
                musicPlayer.controls.play();
                musicButton.Text = "\u23F8"; 
                isMusicPlaying = true;
            }
        }



        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            buttonPlayer.Text = player1Symbol;
            UpdateScoreboard();
            GenerateButtons();
        }

        private void GenerateButtons()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col] = new Button
                    {
                        Size = new Size(175, 175),
                        Location = new Point(col * 175, row * 175),
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font(DefaultFont.FontFamily, 80, FontStyle.Bold)
                    };

                    buttons[row, col].Click += new EventHandler(OnButtonClick);
                    panelButtons.Controls.Add(buttons[row, col]);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text != "")
            {
                return;
            }

            button.Text = buttonPlayer.Text;
            movesCount++;

            if (CheckIfGameEnds(out List<Button> winningButtons))
            {
                foreach (var btn in winningButtons)
                {
                    btn.BackColor = Color.LightGreen;
                    buttonPlayer.BackColor = Color.LightGreen;
                }

                MessageBox.Show($"Player {buttonPlayer.Text} wins!");

                if (buttonPlayer.Text == player1Symbol)
                {
                    playerXWins++;
                }
                else
                {
                    playerOWins++;
                }

                UpdateScoreboard();
                ResetGame();
                return;
            }

            if (movesCount == 9)
            {
                MessageBox.Show("Game Draw!");
                ResetGame();
                return;
            }

            TogglePlayer();
        }

        private void TogglePlayer()
        {
            buttonPlayer.Text = buttonPlayer.Text == player1Symbol ? player2Symbol : player1Symbol;
            labelPlayer.Text = $"Player {buttonPlayer.Text}";
        }

        private bool CheckIfGameEnds(out List<Button> winningButtons)
        {
            winningButtons = new List<Button>();

            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text != "" &&
                    buttons[i, 0].Text == buttons[i, 1].Text &&
                    buttons[i, 1].Text == buttons[i, 2].Text)
                {
                    winningButtons.Add(buttons[i, 0]);
                    winningButtons.Add(buttons[i, 1]);
                    winningButtons.Add(buttons[i, 2]);
                    return true;
                }

                if (buttons[0, i].Text != "" &&
                    buttons[0, i].Text == buttons[1, i].Text &&
                    buttons[1, i].Text == buttons[2, i].Text)
                {
                    winningButtons.Add(buttons[0, i]);
                    winningButtons.Add(buttons[1, i]);
                    winningButtons.Add(buttons[2, i]);
                    return true;
                }
            }

            if (buttons[0, 0].Text != "" &&
                buttons[0, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 2].Text)
            {
                winningButtons.Add(buttons[0, 0]);
                winningButtons.Add(buttons[1, 1]);
                winningButtons.Add(buttons[2, 2]);
                return true;
            }

            if (buttons[2, 0].Text != "" &&
                buttons[2, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[0, 2].Text)
            {
                winningButtons.Add(buttons[2, 0]);
                winningButtons.Add(buttons[1, 1]);
                winningButtons.Add(buttons[0, 2]);
                return true;
            }

            return false;
        }

        private void ResetGame()
        {
            foreach (Button button in buttons)
            {
                button.Text = "";
                button.BackColor = DefaultBackColor;
                buttonPlayer.BackColor = DefaultBackColor;
            }
            movesCount = 0;
        }

        private void UpdateScoreboard()
        {
            labelScoreboard.Text = $"Player {player1Symbol}: {playerXWins} Wins\nPlayer {player2Symbol}: {playerOWins} Wins";
            labelScoreboard.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }
        private void buttonChanger_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPlayer1.Text) || textPlayer1.Text == "Символ за играч X:")
            {
                if (string.IsNullOrWhiteSpace(textPlayer2.Text) || textPlayer2.Text == "Символ за играч O:")
                {
                    MessageBox.Show("Please enter new symbols to replace the default ones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textPlayer1.Text.Length > 1 && textPlayer1.Text != "Символ за играч X:")
            {
                MessageBox.Show("Player 1 symbol must be a single character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPlayer1.Text = "";
                return;
            }

            if (textPlayer2.Text.Length > 1 && textPlayer2.Text != "Символ за играч O:")
            {
                MessageBox.Show("Player 2 symbol must be a single character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPlayer2.Text = "";
                return;
            }

            if (textPlayer1.Text == textPlayer2.Text && textPlayer1.Text != "Символ за играч X:" && textPlayer2.Text != "Символ за играч O:")
            {
                MessageBox.Show("Symbols for Player 1 and Player 2 cannot be the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldPlayer1Symbol = player1Symbol;
            string oldPlayer2Symbol = player2Symbol;

            if (!string.IsNullOrWhiteSpace(textPlayer1.Text) && textPlayer1.Text != "Символ за играч X:")
            {
                player1Symbol = textPlayer1.Text;
            }

            if (!string.IsNullOrWhiteSpace(textPlayer2.Text) && textPlayer2.Text != "Символ за играч O:")
            {
                player2Symbol = textPlayer2.Text;
            }

            if (buttonPlayer.Text == oldPlayer1Symbol)
            {
                buttonPlayer.Text = player1Symbol;
            }
            else if (buttonPlayer.Text == oldPlayer2Symbol)
            {
                buttonPlayer.Text = player2Symbol;
            }

            labelPlayer.Text = $"Player {buttonPlayer.Text}";

            UpdateScoreboard();

            foreach (Button button in buttons)
            {
                if (button.Text == oldPlayer1Symbol)
                {
                    button.Text = player1Symbol;
                }
                else if (button.Text == oldPlayer2Symbol)
                {
                    button.Text = player2Symbol;
                }
            }
        }

        private void InitializeReverseButtonHandler()
        {
            buttonReverse.Text = "⇄";
            buttonReverse.Click += ReverseSymbols;
            buttonReverse.Font = new Font(DefaultFont.FontFamily, 20, FontStyle.Bold);
        }

        private void ReverseSymbols(object sender, EventArgs e)
        {
            
            string temp = player1Symbol;
            player1Symbol = player2Symbol;
            player2Symbol = temp;

            
            if (buttonPlayer.Text == temp)
            {
                buttonPlayer.Text = player1Symbol;
            }
            else if (buttonPlayer.Text == player2Symbol)
            {
                buttonPlayer.Text = player2Symbol;
            }

           
            labelPlayer.Text = $"Player {buttonPlayer.Text}";

            
            foreach (Button button in buttons)
            {
                if (button.Text == player1Symbol)
                {
                    button.Text = player2Symbol;
                }
                else if (button.Text == player2Symbol)
                {
                    button.Text = player1Symbol;
                }
                else if (button.Text == "X")
                {
                    button.Text = "O";
                }
                else if (button.Text == "O")
                {
                    button.Text = "X";
                }
            }

            
            UpdateScoreboard();
        }









        private void ResetButton_Click(object? sender, EventArgs e)
        {
            ResetGame();

            if (isMusicPlaying)
            {
                musicPlayer.controls.stop();
                isMusicPlaying = false;
                musicButton.Text = "\u25B6";
            }

            this.BackColor = DefaultBackColor;

            
            player1Symbol = "X";
            player2Symbol = "O";
            textPlayer1.Text = "Символ за играч X:";
            textPlayer1.ForeColor = Color.Gray;
            textPlayer2.Text = "Символ за играч O:";
            textPlayer2.ForeColor = Color.Gray;
            buttonPlayer.Text = player1Symbol;
            labelPlayer.Text = $"Player {player1Symbol}";
        }

        private void textPlayer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void colorButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
