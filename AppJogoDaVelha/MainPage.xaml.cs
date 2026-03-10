namespace AppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string turn = "X";
        bool win = false;
        int countPlays = 0;
        int countXWins = 0;
        int countOWins = 0;

        List<Button> buttons;
        int[,] winConditions =
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},

            {0,3,6},
            {1,4,7},
            {2,5,8},

            {0,4,8},
            {2,4,6}
        };

        public MainPage()
        {
            InitializeComponent();
            buttons = new List<Button>()
            {
                btn10, btn11, btn12,
                btn20, btn21, btn22,
                btn30, btn31, btn32
            };


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            clicked.IsEnabled = false;
            clicked.Text = turn;

            countPlays++;

            CheckWin();
            CheckVelha();

            turn = (turn == "X") ? "O" : "X";
            lblWins.Text = $"X: {countXWins} | O: {countOWins}";
        }

        private void CheckWin()
        {
            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                int a = winConditions[i, 0];
                int b = winConditions[i, 1];
                int c = winConditions[i, 2];

                if (buttons[a].Text != null && buttons[a].Text == buttons[b].Text &&
                    buttons[a].Text == buttons[c].Text)
                {
                    win = true;
                    break;
                }
            }

            if (win)
            {
                if (turn == "X")
                    countXWins++;
                else
                    countOWins++;

                DisplayAlertAsync("Fim de Jogo", $"Jogador {turn} venceu!", "OK");
                Reset();
            }
        }

        private void CheckVelha()
        {
            if (countPlays == 9)
            {
                DisplayAlertAsync("Fim de Jogo", "Deu velha!", "OK");
                Reset();
            }
        }

        private void Reset()
        {
            foreach (var btn in buttons)
            {
                btn.Text = null;
                btn.IsEnabled = true;
            }

            win = false;
            countPlays = 0;
        }
    }
}