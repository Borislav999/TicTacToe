using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonTwoPlayers_Click(object sender, EventArgs e)
        {
            TicTacToeForm gameForm = new TicTacToeForm();
            gameForm.Show();
            this.Hide(); 
        }

        private void buttonSinglePlayer_Click(object sender, EventArgs e)
        {
            buttonEasy.Visible = true;
            buttonMedium.Visible = true;
            buttonHard.Visible = true;
            panelDifficulty.Visible = true;
            labelDifficulty.Visible = true;
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            OpenAIForm(DifficultyLevel.Easy);
        }

        private void buttonMedium_Click(object sender, EventArgs e)
        {
            OpenAIForm(DifficultyLevel.Medium);
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            OpenAIForm(DifficultyLevel.Hard);
        }

        private void OpenAIForm(DifficultyLevel difficulty)
        {
            AI_TicTacToeForm aiGameForm = new AI_TicTacToeForm(difficulty);
            aiGameForm.Show();
            this.Hide();
        }

        private void labelSinglePlayer_Click(object sender, EventArgs e)
        {
        }

        private void labelForWelcome_Click(object sender, EventArgs e)
        {
        }
    }
}
