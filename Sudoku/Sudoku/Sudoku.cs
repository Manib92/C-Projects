using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        GridModel[,] cells = new GridModel[9, 9];
        private GridModel hasFocus;
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        public Sudoku()
        {
            InitializeComponent();

            //initialisizes the buttons for sudoku
            createCells();

            //generates and sets the values
            startNewGame();

            //makes the background of the pencil image on the pencil button transparent
            makeButtonImageTransparent(pencilButton);
        }

        private void startNewGame()
        { 
            GameVariablesModel.mistakes = 0;

            //Clears the cells and loads the values
            loadValues();

            //Number of cells shown at the start and number of hints are dependent upon
            //difficulty selected.
            if (beginnerRadio.Checked)
            {
                GameVariablesModel.hints = 10;
                GameVariablesModel.cellsShown = 45;
                initGame(GameVariablesModel.cellsShown, GameVariablesModel.hints);
            }
            else if (intermediateRadio.Checked)
            {
                GameVariablesModel.hints = 5;
                GameVariablesModel.cellsShown = 30;
                initGame(GameVariablesModel.cellsShown, GameVariablesModel.hints);
            }
            else if (advancedRadio.Checked)
            {
                GameVariablesModel.hints = 0;
                GameVariablesModel.cellsShown = 15;
                initGame(GameVariablesModel.cellsShown, GameVariablesModel.hints);
            }
        }
        private void initGame(int cellsShown, int hints)
        {
            //Loads the game and resets/starts the timer.
            showRandomValues(cellsShown);
            mistakesLabel.Text = "# of mistakes: 0";
            hintsButton.Text = $"# of hints: {hints}";
            hintsButton.Enabled = hints > 0;
            timer.Reset();
            timer.Start();
        }
        private void showRandomValues(int cellsShown)
        {
            //Show values for hints dependent on the level the player chooses
            for(int i = 0; i < cellsShown; i++)
            {
                var rX = GameVariablesModel.random.Next(9);
                var rY = GameVariablesModel.random.Next(9);

                //Style the hint cells differently and lock them so users can't change them
                cells[rX, rY].Text = cells[rX, rY].value.ToString();
                cells[rX, rY].ForeColor = Color.Black;
                cells[rX, rY].isLocked = true;
            }
        }

        private void loadValues()
        {
            //Clear values in the cell, if any
            foreach(var cell in cells)
            {
                cell.value = 0;
                cell.Clear();
            }

            //Call recursively until it finds suitable values for each cell.
            GameMechanics.findValueForNextCell(0, -1, cells);
        }

        private void createCells()
        {
            //Creates the cells when the game is first loaded.
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    cells[i, j] = new GridModel();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 22);
                    cells[i, j].Size = new Size(60, 60);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 60, j * 60);
                    cells[i, j].BackColor = SystemColors.Control;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].pencilValues = new List<bool>() { false, false, false, false, false, false, false, false, false };
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    //Assign key parameters for each cell:
                    cells[i, j].KeyPress += cell_keyPressed;
                    cells[i, j].Enter += cell_Enter;
                    cells[i, j].Leave += cell_Leave;

                    gridPanel.Controls.Add(cells[i, j]);
                }
            }
        }
        private void cell_Leave(object sender, EventArgs e)
        {
            //reverts highlighted cells back to a white background.
            foreach(GridModel cell in cells)
            {
                cell.BackColor = SystemColors.Control;
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as GridModel;
            
            //Do nothing if cell is locked
            if (cell.isLocked)
                return;

            if (pencilButton.Text == "Off")
            {
                // write pen value
                penInput(cell, e.KeyChar);
            }
            else
            {

                writePencilValues(cell, e.KeyChar);
            }
        }

        private void writePencilValues(GridModel cell, char keyChar)
        {
            if (int.TryParse(keyChar.ToString(), out int input))
            {
                cell.Text = "";
                cell.pencilValues[input - 1] = !cell.pencilValues[input - 1];
                for (int i = 0; i < cell.pencilValues.Count; i++)
                {
                    if (cell.pencilValues[i])
                    {
                        if ((i + 1) % 3 == 0)
                            cell.Text += $"{i + 1} \n";
                        else
                            cell.Text += $"{i + 1} ";
                    }
                    else
                    {
                        if ((i + 1) % 3 == 0)
                            cell.Text += $" \n";
                        else
                            cell.Text += $"  ";
                    }
                }
                cell.Font = new Font(SystemFonts.DefaultFont.FontFamily, 9);
                cell.ForeColor = Color.Gray;
            }
        }

        private void penInput(GridModel cell, char keyChar)
        {
            if (int.TryParse(keyChar.ToString(), out int input))
            {
                if (input == 0)
                    cell.Clear();
                else if (checkInput(cell, input))
                {
                    cell.Text = input.ToString();
                    cell.ForeColor = SystemColors.ControlDarkDark;
                    for (int i = 0; i < cell.pencilValues.Count; i++)
                        cell.pencilValues[i] = false;
                    cell.Font = new Font(SystemFonts.DefaultFont.FontFamily, 22);
                    cell.ForeColor = SystemColors.ControlDarkDark;
                    isGameOver();
                }
            }
        }

        private bool checkInput(GridModel cell, int input)
        {
            if(input != cell.value)
            {
                GameVariablesModel.mistakes += 1;
                mistakesLabel.Text = $"# of mistakes: {GameVariablesModel.mistakes}";
                MessageBox.Show("Incorrect input");
                return false;
            }
            return true;
        }
        private void isGameOver()
        {
            var wrongCells = GameMechanics.findWrongAndEmptyCells(cells);

            //check if inputs are wrong or the player wins
            if (wrongCells[0].Any())
            {
                //Highlight the wrong inputs
                wrongCells[0].ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show("Wrong inputs");
            }
            else if (!wrongCells[1].Any())
            {
                timer.Stop();
                MessageBox.Show("You win!");
            }
        }

        private void hintsButton_Click(object sender, EventArgs e)
        {
            if (hasFocus != null && hasFocus.Text == "" && GameVariablesModel.hints >= 1)
            {
                hasFocus.Text = hasFocus.value.ToString();
                hasFocus.ForeColor = Color.Black;
                hasFocus.isLocked = true;
                GameVariablesModel.hints -= 1;
                hintsButton.Text = $"# of hints: {GameVariablesModel.hints}";
            }
            if (GameVariablesModel.hints < 1)
            {
                GameVariablesModel.hints = 0;
                hintsButton.Text = $"# of hints: {GameVariablesModel.hints}";
                hintsButton.Enabled = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach(var cell in cells)
            {
                //Clear the cells only if it is not locked
                if (cell.isLocked == false)
                    cell.Clear();
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void cell_Enter(object sender, EventArgs e)
        {
            hasFocus = sender as GridModel;
            
            if (hasFocus.Text != "")
            {
                if (GameVariablesModel.cellsShown == 45)
                {
                    highlightBeginnerCells();
                }
                else if (GameVariablesModel.cellsShown == 30)
                {
                    highlightIntermediateCells();
                }
            }
            else
                hasFocus.BackColor = Color.LightGray;
            }

        private void highlightIntermediateCells()
        {
            foreach (GridModel cell in cells)
            {
                if (cell.Text == hasFocus.Text)
                {
                    cell.BackColor = Color.LightGray;
                }
            }
        }

        private void highlightBeginnerCells()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].Text == hasFocus.Text)
                    {
                        for (int k = 0; k < cells.GetLength(0); k++)
                        {
                            cells[k, j].BackColor = Color.LightGray;
                        }
                        for (int l = 0; l < cells.GetLength(1); l++)
                        {
                            cells[i, l].BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }

        // Give the button a transparent background.
        private void makeButtonImageTransparent(Button btn)
        {
            Bitmap bm = (Bitmap)btn.Image;
            bm.MakeTransparent(bm.GetPixel(0, 0));
        }

        private void pencilButton_Click(object sender, EventArgs e)
        {
            if (pencilButton.Text == "Off")
                pencilButton.Text = "On";
            else
                pencilButton.Text = "Off";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = timer.Elapsed.ToString().Remove(8);
        }

        //IMPROVEMENTS  - Be able to use arrow keys to move around grid.
        //              - Have the penciled numbers organised eg:
        //                1 2 3                        1 2 3
        //                4 5 6    to look like:       4 5 6
        //                 7 8                         7 8
        //              - Make it scalable by using WPF.
        //              - Create a border for every 3x3 square.
        //                Possibly by creating panels but if I was to make the app scalable
        //                then I would need to ensure the panels scale proportionately to
        //                the grid.
    }
}
