using System.Collections.Generic;
using System.Linq;

namespace PokeAbilities
{
    /// <summary>
    /// <see cref="RandomUtil"/> を使用した疑似乱数ジェネレーターです。
    /// </summary>
    public class RandomUtilRandomizer : Singleton<RandomUtilRandomizer>, IRandomizer
    {
        public float ValueForProb => RandomUtil.valueForProb;

        public T SelectOne<T>(List<T> list)
            => RandomUtil.SelectOne(list);

        public IEnumerable<T> Sort<T>(IEnumerable<T> list)
        {
            if (list.Count() <= 1) { return list.ToArray(); }

            return list.OrderBy(i => RandomUtil.valueForProb).ToArray();
        }
    }
}
