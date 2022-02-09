using System.Text;

namespace WinFormsMatrixRecoder.Model
{
    public static class Сryptographer
    {
        /// <summary>
        /// Кодирование (шифрование) исходного текста при помощи решётки
        /// </summary>
        /// <param name="text">Исходный текст для шифрования</param>
        /// <param name="lattice">Объект решётки</param>
        /// <returns>Зашифрованный текст</returns>
        public static string Encode(string text, Lattice lattice)
        {
            var result = new StringBuilder();
            var frame = new char[lattice.Side, lattice.Side];
            var textOffset = 0;
            // пока не закончится текст
            while (textOffset < text.Length)
            {
                // заполнение исходной матрицы по-фреймно
                for (int i = 0; i < lattice.Side; i++)
                    for (int j = 0; j < lattice.Side; j++)
                    {
                        frame[i, j] = textOffset < text.Length ? text[textOffset] : ' ';
                        textOffset++;
                    }
                // поворачиваем решётку четыре раза
                for (var k = 0; k < 4; k++)
                {
                    // собираем сквозь прорези решётки буквы из текущего фрейма
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

        /// <summary>
        /// Декодирование (дешифрование) зашифрованного текста при помощи решётки
        /// </summary>
        /// <param name="text">Зашифрованный текст</param>
        /// <param name="lattice">Объект решётки</param>
        /// <returns></returns>
        public static string Decode(string text, Lattice lattice)
        {
            var result = new StringBuilder();
            var frame = new char[lattice.Side, lattice.Side];
            var textOffset = 0;
            // пока не закончится текст
            while (textOffset < text.Length)
            {
                // заполнение исходной матрицы по-фреймно
                for (int i = 0; i < lattice.Side; i++)
                    for (int j = 0; j < lattice.Side; j++)
                    {
                        frame[i, j] = textOffset < text.Length ? text[textOffset] : ' ';
                        textOffset++;
                    }
                // поворачиваем решётку четыре раза
                for (var k = 0; k < 4; k++)
                {
                    // собираем сквозь прорези решётки буквы из текущего фрейма
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
