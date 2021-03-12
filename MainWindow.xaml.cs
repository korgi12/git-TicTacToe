using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        readonly string[] Transporter = new string[9];
        const string X = "X";
        const string O = "O";
        private int _player;
        private int _scoreFirstPlayer;
        private int _scoreSecondPlayer;
        private int _moveCount;
        Button[] _buttons = new Button[9];
        public void ButtonClick(int value)
        {
            if (Transporter[value] == null)
            {
                Print(value);
                _buttons[value].Content = Transporter[value];
                if (_moveCount >= 5)
                {
                    if (CheckWin())
                    {
                        AddPoint();
                        ResetGame();
                        return;
                    }
                }
                if (_moveCount == 9)
                    ResetGame();
            }

        }
        public void Print(int button)
        {
            if (_player == 1)
            {
                _player = 2;
                Transporter[button] = X;
                WhoMove.Text = O;
            }
            else if (_player == 2)
            {
                _player = 1;
                Transporter[button] = O;
                WhoMove.Text = X;
            }
            _moveCount++;
        }

        public bool CheckWin()
        {
            /////////OBLIQUELY LEFT ON RIGHT - НА ИСКОСОК CЛЕВО НА ПРАВО///////////////////
            if ((Transporter[0] == X || O == Transporter[0]) && Transporter[0] == Transporter[4] && Transporter[0] == Transporter[8])
            {
                return true;
            }
            /////////OBLIQUELY RIGHT ON LEFT - НА ИСКОСОК СПРАВА НА ЛЕВО///////////////////
            else if ((X == Transporter[2] || O == Transporter[2]) && Transporter[2] == Transporter[4] && Transporter[6] == Transporter[4])
            {
                return true;
            }
            /////////VERTICAL///////////////////
            for (int i = 0; i <= 6; i += 3)
            {
                if ((X == Transporter[i] || O == Transporter[i]) && Transporter[i] == Transporter[i + 1] && Transporter[i + 2] == Transporter[i])
                {
                    return true;
                }
            }
            /////////HORIZONTAL///////////////////
            for (int i = 0; i < 3; i++)
            {
                if ((X == Transporter[i] || O == Transporter[i]) && Transporter[i] == Transporter[i + 3] && Transporter[i + 6] == Transporter[i + 3])
                {
                    return true;
                }
            }
            return false;
        }

        public void AddPoint()
        {
            if (_player == 2)
            {
                _scoreFirstPlayer++;
                FirstPlayer.Text = Convert.ToString(_scoreFirstPlayer);
            }
            else
            {
                _scoreSecondPlayer++;
                SecondPlayer.Text = Convert.ToString(_scoreSecondPlayer);
            }
        }

        public void ResetGame()
        {
            for (int i = 0; i < Transporter.Length; i++)
            {
                Transporter[i] = null;
            }
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Content = String.Empty;
            }
            _moveCount = 0;
        }

        public void ResetGameScore()
        {
            FirstPlayer.Text = "0";
            SecondPlayer.Text = "0";
            _scoreFirstPlayer = 0;
            _scoreSecondPlayer = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
            _player = 1;
            _scoreFirstPlayer = 0;
            _scoreSecondPlayer = 0;
            FirstPlayer.Text = "0";
            SecondPlayer.Text = "0";
            WhoMove.Text = X;
            _moveCount = 0;
            _buttons[0] = LeftUp;
            _buttons[1] = MiddleUp;
            _buttons[2] = RightUp;
            _buttons[3] = Left;
            _buttons[4] = Middle;
            _buttons[5] = Right;
            _buttons[6] = LeftDown;
            _buttons[7] = MiddleDown;
            _buttons[8] = RightDown;
        }

        private void LeftUp_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(0);

        }

        private void MiddleUp_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(1);

        }

        private void RightUp_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(2);

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(3);

        }

        private void Middle_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(4);

        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(5);

        }

        private void LeftDown_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(6);

        }

        private void MiddleDown_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(7);

        }

        private void RightDown_Click(object sender, RoutedEventArgs e)
        {

            ButtonClick(8);

        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
            ResetGameScore();
        }

        private void FirstPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SecondPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WhoMove_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
