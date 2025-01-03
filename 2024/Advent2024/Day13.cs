using Vector2 = (long X, long Y);

namespace Advent2024
{
    public class Day13
    {
        public List<Machine> Machines = [];

        public long FewerstTokens(string input)
        {
            ReadInput(input);

            return Machines.Sum(m => m.LowestPrice());
        }

        public long FewestTokensCorrected(string input)
        {
            ReadInput(input, true);

            return Machines.Sum(m => m.LowestPrice());
        }

        public void ReadInput(string input, bool corrected = false)
        {
            string[] rows = input.Replace("\n", "").Split('\r');

            for (int i = 0; i < rows.Length; i += 4)
            {
                Machine m = new Machine();
                string[] a = rows[i].Split(' ');
                string[] b = rows[i + 1].Split(' ');
                string[] prize = rows[i + 2].Split(' ');
                m.A = (int.Parse(a[2][2..(a[2].Length - 1)]), int.Parse(a[3][2..]));
                m.B = (int.Parse(b[2][2..(b[2].Length - 1)]), int.Parse(b[3][2..]));
                m.P = (long.Parse(prize[1][2..(prize[1].Length - 1)]) + (corrected ? 10000000000000 : 0),
                    long.Parse(prize[2][2..]) + (corrected ? 10000000000000 : 0));
                Machines.Add(m);
            }
        }
    }

    public class Machine
    {
        public Vector2 A { get; set; }
        public Vector2 B { get; set; }
        public Vector2 P { get; set; }

        public long LowestPrice()
        {
            // Cramers rule: xi = det(Ai) / det(A) , i = 1..n
            // a * i + b * j = p
            long i = Det(P, B) / Det(A, B);
            long j = Det(A, P) / Det(A, B);

            if (i >= 0 && j >= 0 && A.X * i + B.X * j == P.X && A.Y * i + B.Y * j == P.Y)
                return 3 * i + j;
            return 0;
        }

        private static long Det(Vector2 v1, Vector2 v2) => v1.X * v2.Y - v1.Y * v2.X;
    }
}
