using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace TicTacToe
{
    public partial class AI_TicTacToeForm : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private string playerSymbol = "X"; 
        private string aiSymbol = "O";     
        private int playerWins = 0;
        private int aiWins = 0;
        private int movesCount = 0;
        private DifficultyLevel difficulty;
        private Random random = new Random();
        private WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        private bool isMusicPlaying = false;

        public AI_TicTacToeForm(DifficultyLevel difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            GenerateButtons();
            InitializePlayerIndicator();
            InitializePlaceholders();
            UpdateScoreboard();
            InitializeMusicButtonHandler();
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
                        Font = new Font("Microsoft Sans Serif", 48, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.White
                    };
                    buttons[row, col].Click += OnPlayerMove;
                    panelAIButtons.Controls.Add(buttons[row, col]);
                }
            }
        }

        private void InitializePlayerIndicator()
        {
            UpdatePlayerIndicator(playerSymbol);
        }

        private void UpdatePlayerIndicator(string currentSymbol)
        {
            buttonAIPlayer.Text = currentSymbol;
            buttonAIPlayer.BackColor = currentSymbol == playerSymbol ? Color.LightBlue : Color.LightCoral;
            labelAIPlayer.Text = $"Player: {currentSymbol}";
        }

        private void InitializePlaceholders()
        {
            textAIPlayer1.Text = "Символ за играч X:";
            textAIPlayer1.ForeColor = Color.Gray;

            textAIPlayer2.Text = "Символ за играч O:";
            textAIPlayer2.ForeColor = Color.Gray;

            textAIPlayer1.GotFocus += (sender, e) =>
            {
                if (textAIPlayer1.Text == "Символ за играч X:")
                {
                    textAIPlayer1.Text = "";
                    textAIPlayer1.ForeColor = Color.Black;
                }
            };

            textAIPlayer1.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textAIPlayer1.Text))
                {
                    textAIPlayer1.Text = "Символ за играч X:";
                    textAIPlayer1.ForeColor = Color.Gray;
                }
            };

            textAIPlayer2.GotFocus += (sender, e) =>
            {
                if (textAIPlayer2.Text == "Символ за играч O:")
                {
                    textAIPlayer2.Text = "";
                    textAIPlayer2.ForeColor = Color.Black;
                }
            };

            textAIPlayer2.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textAIPlayer2.Text))
                {
                    textAIPlayer2.Text = "Символ за играч O:";
                    textAIPlayer2.ForeColor = Color.Gray;
                }
            };
        }

        private async void OnPlayerMove(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text != "") return;

            button.Text = playerSymbol;
            movesCount++;

            if (CheckForWin(playerSymbol, out List<Button> winningButtons))
            {
                HighlightWinningLine(winningButtons);
                playerWins++;
                UpdateScoreboard();
                MessageBox.Show("Player Wins!");
                ResetGame();
                return;
            }

            if (movesCount == 9)
            {
                MessageBox.Show("It's a draw!");
                ResetGame();
                return;
            }

            ToggleButtons(false);
            UpdatePlayerIndicator(aiSymbol);
            await Task.Delay(700);
            MakeAIMove();
            UpdatePlayerIndicator(playerSymbol);
            ToggleButtons(true);
        }

        private void MakeAIMove()
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    MakeRandomMove();
                    break;
                case DifficultyLevel.Medium:
                    if (!TryWinOrBlock(aiSymbol) && !TryWinOrBlock(playerSymbol))
                        MakeRandomMove();
                    break;
                case DifficultyLevel.Hard:
                    MakeOptimalMove();
                    break;
            }

            if (CheckForWin(aiSymbol, out List<Button> winningButtons))
            {
                HighlightWinningLine(winningButtons);
                aiWins++;
                UpdateScoreboard();
                MessageBox.Show("AI Wins!");
                ResetGame();
                return;
            }

            movesCount++;
            if (movesCount == 9)
            {
                MessageBox.Show("It's a draw!");
                ResetGame();
            }
        }

        private void MakeRandomMove()
        {
            List<Button> availableButtons = buttons.Cast<Button>().Where(b => b.Text == "").ToList();
            if (availableButtons.Count > 0)
            {
                Button chosenButton = availableButtons[random.Next(availableButtons.Count)];
                chosenButton.Text = aiSymbol;
            }
        }

        private bool TryWinOrBlock(string symbol)
        {
            foreach (Button button in buttons)
            {
                if (button.Text == "")
                {
                    button.Text = symbol;
                    if (CheckForWin(symbol, out _))
                    {
                        if (symbol == aiSymbol)
                        {
                            return true;
                        }
                        else
                        {
                            button.Text = aiSymbol;
                            return true;
                        }
                    }
                    button.Text = "";
                }
            }
            return false;
        }

        private void MakeOptimalMove()
        {
            int bestScore = int.MinValue;
            Button bestMove = null;

            foreach (Button button in buttons)
            {
                if (button.Text == "")
                {
                    button.Text = aiSymbol;
                    int score = Minimax(0, false, int.MinValue, int.MaxValue);
                    button.Text = "";

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = button;
                    }
                }
            }

            if (bestMove != null)
            {
                bestMove.Text = aiSymbol;
            }
        }

        private int Minimax(int depth, bool isMaximizing, int alpha, int beta)
        {
            if (CheckForWin(aiSymbol, out _)) return 10 - depth;
            if (CheckForWin(playerSymbol, out _)) return depth - 10;
            if (movesCount + depth == 9) return 0;

            int bestScore = isMaximizing ? int.MinValue : int.MaxValue;

            foreach (Button button in buttons)
            {
                if (button.Text == "")
                {
                    button.Text = isMaximizing ? aiSymbol : playerSymbol;
                    int score = Minimax(depth + 1, !isMaximizing, alpha, beta);
                    button.Text = "";

                    if (isMaximizing)
                    {
                        bestScore = Math.Max(score, bestScore);
                        alpha = Math.Max(alpha, bestScore);
                    }
                    else
                    {
                        bestScore = Math.Min(score, bestScore);
                        beta = Math.Min(beta, bestScore);
                    }

                    if (beta <= alpha)
                        break;
                }
            }

            return bestScore;
        }

        private bool CheckForWin(string symbol, out List<Button> winningButtons)
        {
            winningButtons = new List<Button>();

            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text == symbol && buttons[i, 1].Text == symbol && buttons[i, 2].Text == symbol)
                {
                    winningButtons.Add(buttons[i, 0]);
                    winningButtons.Add(buttons[i, 1]);
                    winningButtons.Add(buttons[i, 2]);
                    return true;
                }
                if (buttons[0, i].Text == symbol && buttons[1, i].Text == symbol && buttons[2, i].Text == symbol)
                {
                    winningButtons.Add(buttons[0, i]);
                    winningButtons.Add(buttons[1, i]);
                    winningButtons.Add(buttons[2, i]);
                    return true;
                }
            }
            if (buttons[0, 0].Text == symbol && buttons[1, 1].Text == symbol && buttons[2, 2].Text == symbol)
            {
                winningButtons.Add(buttons[0, 0]);
                winningButtons.Add(buttons[1, 1]);
                winningButtons.Add(buttons[2, 2]);
                return true;
            }
            if (buttons[0, 2].Text == symbol && buttons[1, 1].Text == symbol && buttons[2, 0].Text == symbol)
            {
                winningButtons.Add(buttons[0, 2]);
                winningButtons.Add(buttons[1, 1]);
                winningButtons.Add(buttons[2, 0]);
                return true;
            }
            return false;
        }

        private void HighlightWinningLine(List<Button> winningButtons)
        {
            foreach (var button in winningButtons)
            {
                button.BackColor = Color.LightGreen;
            }
            buttonAIPlayer.BackColor = Color.LightGreen;
        }

        private void ResetGame()
        {
            foreach (Button button in buttons)
            {
                button.Text = "";
                button.BackColor = Color.White;
            }
            movesCount = 0;

            UpdatePlayerIndicator(playerSymbol);
            UpdateScoreboard();
        }

        private void UpdateScoreboard()
        {
            labelAIScoreboard.Text = $"Player: {playerWins} Wins\nAI: {aiWins} Wins";
        }

        private void ToggleButtons(bool isEnabled)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = isEnabled;
            }
        }

        private void InitializeMusicButtonHandler()
        {
            musicAIButton.Text = "\u25B6";
            musicAIButton.Font = new Font(DefaultFont.FontFamily, 20, FontStyle.Bold);
            musicAIButton.Click += ToggleMusic1;
        }

        private void ToggleMusic1(object sender, EventArgs e)
        {
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Havana.wav");

            if (isMusicPlaying)
            {
                musicPlayer.controls.stop();
                musicAIButton.Text = "\u25B6"; 
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
                musicAIButton.Text = "\u23F8"; 
                isMusicPlaying = true;
            }
        }


        private void musicAIButton_Click(object sender, EventArgs e)
        {
            ToggleMusic1(sender, e); 
        }


        private void buttonAIChanger_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textAIPlayer1.Text) || textAIPlayer1.Text == "Символ за играч X:")
            {
                if (string.IsNullOrWhiteSpace(textAIPlayer2.Text) || textAIPlayer2.Text == "Символ за играч O:")
                {
                    MessageBox.Show("Please enter new symbols for the players.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textAIPlayer1.Text.Length > 1 && textAIPlayer1.Text != "Символ за играч X:")
            {
                MessageBox.Show("Player 1 symbol must be a single character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAIPlayer1.Text = "";
                return;
            }

            if (textAIPlayer2.Text.Length > 1 && textAIPlayer2.Text != "Символ за играч O:")
            {
                MessageBox.Show("AI symbol must be a single character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAIPlayer2.Text = "";
                return;
            }

            string oldPlayerSymbol = playerSymbol;
            string oldAISymbol = aiSymbol;

            if (!string.IsNullOrWhiteSpace(textAIPlayer1.Text) && textAIPlayer1.Text != "Символ за играч X:")
            {
                playerSymbol = textAIPlayer1.Text;
            }

            if (!string.IsNullOrWhiteSpace(textAIPlayer2.Text) && textAIPlayer2.Text != "Символ за играч O:")
            {
                aiSymbol = textAIPlayer2.Text;
            }

            if (buttonAIPlayer.Text == oldPlayerSymbol)
            {
                buttonAIPlayer.Text = playerSymbol;
            }
            else if (buttonAIPlayer.Text == oldAISymbol)
            {
                buttonAIPlayer.Text = aiSymbol;
            }

            UpdatePlayerIndicator(playerSymbol);
            UpdateScoreboard();
        }

        private void buttonAIReverse_Click(object sender, EventArgs e)
        {
            string temp = playerSymbol;
            playerSymbol = aiSymbol;
            aiSymbol = temp;

            UpdatePlayerIndicator(playerSymbol);
            UpdateScoreboard();
        }

        private void resetAIButton_Click(object sender, EventArgs e)
        {
            ResetGame();

            if (isMusicPlaying)
            {
                musicPlayer.controls.stop();
                isMusicPlaying = false;
                musicAIButton.Text = "\u25B6"; 
            }

          
            this.BackColor = DefaultBackColor;

            
            playerSymbol = "X";
            aiSymbol = "O";
            textAIPlayer1.Text = "Символ за играч X:";
            textAIPlayer1.ForeColor = Color.Gray;
            textAIPlayer2.Text = "Символ за играч O:";
            textAIPlayer2.ForeColor = Color.Gray;
            buttonAIPlayer.Text = playerSymbol;

            UpdatePlayerIndicator(playerSymbol);
            UpdateScoreboard();
        }


        private void colorAIButton_Click(object sender, EventArgs e)
        {
            
            this.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

    }
}
