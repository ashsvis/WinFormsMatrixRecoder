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
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    lattice[i, j] = 1;
            // добавление "прорезей"
            var list = new List<Point>();
            // создадим список индексов решётки из первой четверти
            for (int i = 0; i < side / 2; i++)
                for (int j = 0; j < side / 2; j++)
                    list.Add(new Point(i, j));
            var rand = new Random();
            while (list.Count > 0)
            {
                // получаем случайную позицию в массиве индексов решетки
                var indexInList = rand.Next(list.Count);
                // получаем значение идекса из массива возможных идексов
                var index = list[indexInList];
                var i = index.X;
                var j = index.Y;
                // делаем "прорезь"
                switch (rand.Next(4))
                {
                    case 0:
                        lattice[i, j] = 0;
                        break;
                    case 1:
                        lattice[side - i - 1, j] = 0;
                        break;
                    case 2:
                        lattice[i, side - j - 1] = 0;
                        break;
                    case 3:
                        lattice[side - i - 1, side - j - 1] = 0;
                        break;
                }
                // удаление использованного индекса решетки
                list.RemoveAt(indexInList);
            }
        }

        public int Side { get => side; }

        public int this [int i, int j]
        {
            get => lattice [i, j];
        }

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
