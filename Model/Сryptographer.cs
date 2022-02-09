using System.Text;

namespace WinFormsMatrixRecoder.Model
{
    public static class Сryptographer
    {
        public static string Encode(string text, Lattice lattice)
        {
            var result = new StringBuilder();
            var frame = new char[lattice.Side, lattice.Side];
            var textOffset = 0;

            while (textOffset < text.Length)
            {
                // заполнение исходной матрицы
                for (int i = 0; i < lattice.Side; i++)
                    for (int j = 0; j < lattice.Side; j++)
                    {
                        frame[i, j] = textOffset < text.Length ? text[textOffset] : ' ';
                        textOffset++;
                    }
                for (var k = 0; k < 4; k++)
                {
                    for (int i = 0; i < lattice.Side; i++)
                        for (int j = 0; j < lattice.Side; j++)
                        {
                            if (lattice[i, j] == 0)
                                result.Append(frame[i, j]);
                        }
                    lattice.RotateClockwise();
                }
            }
            return result.ToString();
        }
    }
}
