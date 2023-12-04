namespace Advent2023
{
    public class Day1
    {
        string[] numberWords = {"one", "two","three","four","five","six","seven","eight","nine" };

        public int GetDigits(string value)
        {
            if (value == null)
                return 0;

            bool isFirstSet = false;
            int firstDigit = 0;
            int lastDigit = 0;
            int firstPos = 0;
            int lastPos = 0;

            for (int i = 0; i < value.Length; i++)
            {
                char character = value[i];
                if (char.IsDigit(character))
                {
                    int digit = int.Parse(character.ToString());
                    if (!isFirstSet)
                    {
                        firstDigit = digit;
                        isFirstSet = true;
                        firstPos = i;
                    }
                    lastDigit = digit;
                    lastPos = i;
                }
            }


            for(int i=0;i< numberWords.Length;i++)
            {
                int firstOc = value.IndexOf(numberWords[i]);
                int lastOc = value.LastIndexOf(numberWords[i]);
                if( firstOc != -1 && firstOc <= firstPos)
                {
                    firstPos = firstOc;
                    firstDigit = i + 1;
                }
                if( lastOc != -1 && lastOc >= lastPos)
                {
                    lastPos = lastOc;
                    lastDigit = i + 1;
                }
            }

            return firstDigit * 10 + lastDigit;
        }

        public int GetSum(string value)
        {
            int result = 0;

            string[] rows = value.Split('\n');

            for (int i = 0; i < rows.Length; i++)
                result += GetDigits(rows[i]);

            return result;
        }
    }
}