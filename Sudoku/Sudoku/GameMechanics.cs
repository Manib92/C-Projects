using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class GameMechanics
    {
        public static bool findValueForNextCell(int i, int j, GridModel[,] cells)
        {
            //Increment i and j to the next cell.
            if (++j > 8)
            {
                j = 0;

                if (++i > 8)
                {
                    return true;
                }
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Find a valid number for the cell and go to the next cell and 
            //check if it can be allocated a random number
            do
            {
                //If there's no suitable numbers then change the previous cell.
                if (numsLeft.Count < 1)
                {
                    cells[i, j].value = 0;
                    return false;
                }

                //Take a random number taken from the list
                value = numsLeft[GameVariablesModel.random.Next(0, numsLeft.Count)];
                cells[i, j].value = value;

                //Remove allocated value
                numsLeft.Remove(value);
            } while (!GameMechanics.isValidNumber(value, i, j, cells) || !GameMechanics.findValueForNextCell(i, j, cells));

            //Remove line after testing
            //cells[i, j].Text = value.ToString();
            return true;
        }

        public static bool isValidNumber(int value, int x, int y, GridModel[,] cells)
        {
            for (int i = 0; i < 9; i++)
            {
                //Check all vertical cells
                if (i != y && cells[x, i].value == value)
                    return false;

                //Check all horizontal cells
                if (i != x && cells[i, y].value == value)
                    return false;
            }

            //Check each 3x3 square
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].value == value)
                        return false;
                }
            }

            return true;
        }

        public static List<List<GridModel>> findWrongAndEmptyCells(GridModel[,] cells)
        {
            var wrongCells = new List<GridModel>();
            var emptyCells = new List<GridModel>();
            //find all wrong inputs
            foreach (var cell in cells)
            {
                if (!string.Equals(cell.value.ToString(), cell.Text))
                {
                    if (cell.Text == "")
                        emptyCells.Add(cell);
                    else
                        wrongCells.Add(cell);
                }
            }

            List<List<GridModel>> output = new List<List<GridModel>>() { wrongCells, emptyCells };
            return output;
        }
    }
}
