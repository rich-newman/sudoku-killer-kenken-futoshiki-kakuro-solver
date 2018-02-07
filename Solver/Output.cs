namespace Solver
{
    static class Output
    {
        static public void Show(int[,] values)
        {
            for (int y = 0; y < values.GetLength(1); y++)
            {
                for (int x = 0; x < values.GetLength(0); x++)
                {

                    System.Diagnostics.Debug.Write(values[x, y]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }

    public static class Console
    {
        public static void Show(int[,] values)
        {
            for (int y = 0; y < values.GetLength(1); y++)
            {
                for (int x = 0; x < values.GetLength(0); x++)
                {
                    System.Console.Write(values[x, y]);
                }
                System.Console.WriteLine("");
            }
            System.Console.WriteLine("");
        }
    }
}
