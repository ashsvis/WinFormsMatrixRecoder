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



            /*

            // создание решетки без "прорезей"
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    lattice[i, j] = 1;

            // добавление "прорезей"
            var list = new List<Point>();

            // создадим список индексов решётки
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    list.Add(new Point(i, j));

            var rand = new Random();
            while (list.Count > 0)
            {
                // получаем случайную позицию в массиве индексов решетки
                var indexInList = rand.Next(list.Count);
                
                // получаем значение индекса из массива возможных индексов
                var index = list[indexInList];
                var i = index.X;
                var j = index.Y;
                
                // делаем "прорезь"
                lattice[i, j] = 0;

                // удаление использованных индексов решетки
                list.RemoveAll(item => item.X == i && item.Y == j);
                list.RemoveAll(item => item.X == i && item.Y == side - j - 1);
                list.RemoveAll(item => item.X == side - i - 1 && item.Y == side - j - 1);
                list.RemoveAll(item => item.X == side - i - 1 && item.Y == j);
            }

            */
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
