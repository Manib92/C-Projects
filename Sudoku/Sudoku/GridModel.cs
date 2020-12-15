using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public class GridModel : Button
    {
        public int value { get; set; }
        public bool isLocked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<bool> pencilValues { get; set; }
        public void Clear()
        {
            this.Text = string.Empty;
            this.isLocked = false;
        }
    }
}
