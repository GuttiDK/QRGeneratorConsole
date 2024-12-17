namespace QRGeneratorProject.QRCode
{
    public class QRMatrixBuilder
    {
        public bool[,] Build(string data)
        {
            int size = 33; // Version 1 QR-kode matrix størrelse
            bool[,] matrix = new bool[size, size];
            int dataIndex = 0;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (dataIndex < data.Length)
                        matrix[y, x] = data[dataIndex++] == '1';
                }
            }

            AddFinderPatterns(matrix, size);
            return matrix;
        }

        private void AddFinderPatterns(bool[,] matrix, int size)
        {
            DrawFinder(matrix, 0, 0);
            DrawFinder(matrix, 0, size - 7);
            DrawFinder(matrix, size - 7, 0);
        }

        private void DrawFinder(bool[,] matrix, int startY, int startX)
        {
            for (int y = 0; y < 7; y++)
                for (int x = 0; x < 7; x++)
                    matrix[startY + y, startX + x] = x == 0 || x == 6 || y == 0 || y == 6 || (x >= 2 && x <= 4 && y >= 2 && y <= 4);
        }
    }
}
