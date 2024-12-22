using Cache = System.Collections.Concurrent.ConcurrentDictionary<(string, int), long>;

namespace Advent2024
{
    public class Day11
    {
        public long CountStones(string input, int blinks)
        {
            var cache = new Cache();
            return input.Split(" ").Sum(n => CountStonesHelped(long.Parse(n), blinks, cache));
        }

        private static long CountStonesHelped(long n, int blinks, Cache cache)
        {
            return cache.GetOrAdd((n.ToString(), blinks), key =>
                key switch {
                    (_, 0) => 1,
                    ("0", _) =>
                        CountStonesHelped(1, blinks - 1, cache),
                    (var st, _) when st.Length % 2 == 0 =>
                        CountStonesHelped(long.Parse(st[0..(st.Length / 2)]), blinks - 1, cache) +
                        CountStonesHelped(long.Parse(st[(st.Length / 2)..]), blinks - 1, cache),
                    _ =>
                        CountStonesHelped(2024 * n, blinks - 1, cache)
                }
            );
        }
    }
}
