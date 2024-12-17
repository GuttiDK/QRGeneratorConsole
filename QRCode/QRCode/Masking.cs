namespace QRGeneratorProject.QRCode
{
    public class Masking
    {
        public void Apply(bool[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    if ((x + y) % 2 == 0)
                        matrix[y, x] = !matrix[y, x];
        }
    }
}
