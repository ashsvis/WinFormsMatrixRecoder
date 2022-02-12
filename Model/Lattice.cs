namespace WinFormsMatrixRecoder.Model
{
    public class Lattice
    {
        private readonly int side;
        private readonly int[,] lattice;

        /// <summary>
        /// Конструктор для создания решётки с указанным размером стороны и случайными значениями
        /// </summary>
        /// <param name="side">Размер стороны квадратной решётки</param>
        public Lattice(int side = 10)
        {
            this.side = side;
            lattice = new int[side, side];
            // подготовка нумерованных и повёрнутых на 90° квадрантов решётки
            // первый квадрант
            var offset = 1;
            for (int i = 0; i < side / 2; i++)
                for (int j = 0; j < side / 2; j++)
                    lattice[i, j] = offset++;
            // второй квадрант
            offset = 1;
            for (int j = side - 1; j >= side / 2; j--)
                for (int i = 0; i < side / 2; i++)
                    lattice[i, j] = offset++;
            // третий квадрант
            offset = 1;
            for (int i = side - 1; i >= side / 2; i--)
                for (int j = side - 1; j >= side / 2; j--)
                    lattice[i, j] = offset++;
            // четвертый квадрант
            offset = 1;
            for (int j = 0; j < side / 2; j++)
                for (int i = side - 1; i >= side / 2; i--)
                    lattice[i, j] = offset++;
            // создание списка массивов координат ячеек с одинаковой цифрой
            var list = new List<Point[]>();
            for (var index = 1; index <= (side / 2) * (side / 2); index++)
            {
                list.Add(new Point[4]);
                var k = 0;
                while (k < 4)
                {
                    for (int i = 0; i < side; i++)
                        for (int j = 0; j < side; j++)
                            if (lattice[i, j] == index)
                                list[index - 1][k++] = new Point(i, j);
                }
            }
            // раскрашиваем и делаем прорези
            var rand = new Random();
            foreach (var item in list)
            {
                var n = rand.Next(4);
                var i = item[n].X;
                var j = item[n].Y;
                // делаем "прорезь"
                lattice[i, j] = 0;
            }            
            // всё остальное делаем "непрозрачным"
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    if (lattice[i, j] != 0)
                        lattice[i, j] = 1;
        }

        /// <summary>
        /// Конструктор для создания решётки из массива байтов
        /// </summary>
        /// <param name="bytes"></param>
        public Lattice(byte[] bytes)
        {
            this.side = (int)Math.Sqrt(bytes.Length);
            lattice = new int[side, side];
            var offset = 0;
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    lattice[i, j] = bytes[offset++];
        }

        public int Side { get => side; }

        public int this[int i, int j]
        {
            get => lattice[i, j];
        }

        /// <summary>
        /// Вращение решётки по часовой стрелке на 90°
        /// </summary>
        public void RotateClockwise()
        {
            var rezult = new int[side, side];
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    rezult[i, j] = lattice[side - j - 1, i];
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    lattice[i, j] = rezult[i, j];
        }

    }
}
