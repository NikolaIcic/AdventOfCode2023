namespace Advent2024
{
    public class Day4
    {
        public int GetAllXMASInstances(string text)
        {
            int count = 0;

            text = text.Replace("\n", "");
            string[] rows = text.Split('\r');

            // horizontal
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (j + 3 >= rows[i].Length) break;
                    if (rows[i][j] == 'X' && rows[i][j + 1] == 'M' && rows[i][j + 2] == 'A' && rows[i][j + 3] == 'S'
                        || rows[i][j] == 'S' && rows[i][j + 1] == 'A' && rows[i][j + 2] == 'M' && rows[i][j + 3] == 'X')
                        count++;
                }
            // vertical
            for (int i = 0; i < rows[0].Length; i++)
                for (int j = 0; j < rows.Length; j++)
                {
                    if (j + 3 >= rows.Length) break;
                    if (rows[j][i] == 'X' && rows[j + 1][i] == 'M' && rows[j + 2][i] == 'A' && rows[j + 3][i] == 'S'
                        || rows[j][i] == 'S' && rows[j + 1][i] == 'A' && rows[j + 2][i] == 'M' && rows[j + 3][i] == 'X')
                        count++;
                }
            // diagonal left right
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (i + 3 >= rows.Length || j + 3 >= rows[i].Length) break;
                    if (rows[i][j] == 'X' && rows[i + 1][j + 1] == 'M' && rows[i + 2][j + 2] == 'A' && rows[i + 3][j + 3] == 'S'
                        || rows[i][j] == 'S' && rows[i + 1][j + 1] == 'A' && rows[i + 2][j + 2] == 'M' && rows[i + 3][j + 3] == 'X')
                        count++;
                }
            }
            // diagonal right left
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = rows[i].Length - 1; j > 0; j--)
                {
                    if (i + 3 >= rows.Length || j - 3 < 0) break;
                    if (rows[i][j] == 'X' && rows[i + 1][j - 1] == 'M' && rows[i + 2][j - 2] == 'A' && rows[i + 3][j - 3] == 'S'
                        || rows[i][j] == 'S' && rows[i + 1][j - 1] == 'A' && rows[i + 2][j - 2] == 'M' && rows[i + 3][j - 3] == 'X')
                        count++;
                }
            }

            return count;
        }

        public int GetAll_X_MAsInstances(string text)
        {
            int count = 0;
            text = text.Replace("\n", "");
            string[] rows = text.Split('\r');

            for(int i = 1; i < rows.Length - 1; i++)
                for(int j = 1; j < rows[i].Length - 1; j++)
                    if (rows[i][j] == 'A' && 
                        ((rows[i+1][j+1] == 'M' && rows[i-1][j-1] == 'S') || (rows[i+1][j+1] == 'S' && rows[i-1][j-1] == 'M'))
                        &&
                        ((rows[i+1][j-1] == 'M' && rows[i-1][j+1] == 'S') || (rows[i+1][j-1] == 'S' && rows[i-1][j+1] == 'M'))
                        )
                        count++;

            return count;
        }
    }
}
