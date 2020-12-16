using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeFE
{
    public partial class TicTacToe : Form
    {
        public static string turn = "X";
        public TicTacToe()
        {
            InitializeComponent();
        }



        private static bool IsFree(object sender, EventArgs e)
        {
            //Check if button slot is free
            var button = (Button)sender;
            if(button.Text == "" || button.ForeColor == Color.Gray)
            {
                return true;
            }
            return false;
        }

        private void SetMove(object sender, EventArgs e)
        {
            //Set button to either X or O when clicked
            var button = (Button)sender;
            if (turn == "X")
            {
                button.ForeColor = Color.Blue;
                button.Text = turn;
                turn = "O";
            }
            else
            {
                button.ForeColor = Color.Red;
                button.Text = turn;
                turn = "X";
            }
        }

        private void IsGameOver()
        {
            //Check for game over conditions for the buttons.
            List<Button> buttons = new List<Button> 
            { TopLeft, TopCenter, TopRight, CenterLeft, CenterCenter,
            CenterRight, BottomLeft, BottomCenter, BottomRight };
            DialogResult result = new DialogResult();
            // TODO - Improvement - get rid of checking all win cases when all files are filled. Just check for draw
            //when all tiles are filled. and always check for possible winners later regardless of tiles being all 
            //filled.

            //Check for all buttons regardless if tiles are not filled.
            if (buttons[0].Text == buttons[1].Text && buttons[0].Text == buttons[2].Text && buttons[0].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[0].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[3].Text == buttons[4].Text && buttons[3].Text == buttons[5].Text && buttons[3].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[3].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[6].Text == buttons[7].Text && buttons[6].Text == buttons[8].Text && buttons[6].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[6].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[0].Text == buttons[3].Text && buttons[0].Text == buttons[6].Text && buttons[0].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[0].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[1].Text == buttons[4].Text && buttons[1].Text == buttons[7].Text && buttons[1].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[1].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[2].Text == buttons[5].Text && buttons[2].Text == buttons[8].Text && buttons[2].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[2].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[0].Text == buttons[4].Text && buttons[0].Text == buttons[8].Text && buttons[0].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[0].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            else if (buttons[2].Text == buttons[4].Text && buttons[2].Text == buttons[6].Text && buttons[2].Text != "")
            {
                result = MessageBox.Show($"The winner is {buttons[2].Text}! Would you like to reset?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
            //Check when no more available moves are possible
            else if (buttons.All(x => x.Text != ""))
            {
                result = MessageBox.Show("It was a tie game. Would you like to reset? ", "Game Over", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Reset()
        {
            // Clears the input in the buttons
            List<Button> buttons = new List<Button>
            { TopRight, TopCenter, TopLeft, CenterLeft, CenterCenter,
            CenterRight, BottomLeft, BottomCenter, BottomRight };

            foreach(Button button in buttons)
            {
                button.Text = "";
                turn = "X";
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            //Checks if button is free. If so, then it sets the move and checks for win condition.
            Button button = (Button)sender;
            if(IsFree(sender, e))
            {
                SetMove(sender, e);
                IsGameOver();
            }

        }

        private void ButtonHover(object sender, EventArgs e)
        {
            //If the button is free then it places an X or O there just to help the user visualize their move
            if(IsFree(sender, e))
            {
                Button button = (Button)sender;
                button.ForeColor = Color.Gray;
                if (turn == "X")
                {
                    button.Text = "X";
                }
                else
                {
                    button.Text = "O";
                }
            }
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            //Clears the button of the "pencil" input made by ButtonHover when the mouse leaves that button.
            if (IsFree(sender, e))
            {
                Button button = (Button)sender;
                button.Text = "";
            }
        }
    }
}
