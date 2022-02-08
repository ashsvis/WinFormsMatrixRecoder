using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMatrixRecoder.Model
{
    public class Lattice
    {
        private readonly int side;
        private readonly int[,] lattice;

        public Lattice(int side = 10)
        {
            this.side = side;
            lattice = new int[side, side];
            // создание решетки без "прорезей"
            for (int i=0; i < side; i++)
            {
                for (int j=0; j < side; j++)
                {
                    lattice[j, i] = 1;
                }
            }
            // добавление "прорезей"
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (lattice[i, j] != 0 &&
                        lattice[side - i - 1, j] != 0 &&
                        lattice[i, side - j - 1] != 0 &&
                        lattice[side - i - 1, side - j - 1] != 0)
                        lattice[j, i] = 0;
                }
            }
        }

        public int Side { get => side; }

        public int this [int x, int y]
        {
            get => lattice [x, y];
        }
    }
}
