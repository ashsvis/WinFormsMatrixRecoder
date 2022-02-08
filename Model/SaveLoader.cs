namespace WinFormsMatrixRecoder.Model
{
    public static class SaveLoader
    {
        public static void LatticeSave(string fileName, Lattice lattice)
        {
            var list = new List<byte>();
            for (int i = 0; i < lattice.Side; i++)
                for (int j = 0; j < lattice.Side; j++)
                    list.Add((byte)lattice[i, j]);

            File.WriteAllBytes(fileName, list.ToArray());
        }

        public static Lattice LatticeLoad(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("Файл решётки не найден", fileName);
            var bytes = File.ReadAllBytes(fileName);
            var lattice = new Lattice(bytes);
            return lattice;
        }
    }
}
