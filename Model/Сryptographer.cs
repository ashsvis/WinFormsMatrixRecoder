using System.Text;

namespace WinFormsMatrixRecoder.Model
{
    public static class Сryptographer
    {
        public static string EncodeDecode(string text, Lattice lattice)
        {
            var rezult = new StringBuilder();
            for (var k = 0; k < 4; k++)
            {
                var offset = 0;
                for (int i = 0; i < lattice.Side; i++)
                    for (int j = 0; j < lattice.Side; j++)
                    {
                        if (lattice[i, j] == 0)
                            rezult.Append(offset < text.Length ? text[offset] : ' ');
                        offset++;
                    }
                lattice.RotateClockwise();
            }
            return rezult.ToString();
        }
    }
}
