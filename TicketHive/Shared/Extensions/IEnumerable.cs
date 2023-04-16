using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            var chunk = new List<T>(chunkSize);

            foreach (var item in source)
            {
                chunk.Add(item);

                if (chunk.Count == chunkSize)
                {
                    yield return chunk;
                    chunk = new List<T>(chunkSize);
                }
            }

            if (chunk.Count > 0)
            {
                yield return chunk;
            }
        }
    }
}
