using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class GameVariablesModel
    {
        public static int mistakes { get; set; }

        public static int hints { get; set; }

        public static int cellsShown { get; set; }


        public static Random random = new Random();
    }
}
