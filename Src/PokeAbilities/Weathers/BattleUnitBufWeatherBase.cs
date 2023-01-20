using System;
using System.Collections.Generic;
using System.Linq;
using PokeAbilities.Types;

namespace PokeAbilities.Weathers
{
    /// <summary>
    /// 天気を表す状態の基底クラスです。
    /// </summary>
    public abstract class BattleUnitBufWeatherBase : BattleUnitBuf
    {
        /// <summary>付与数の上限値</summary>
        private const int MaxStack = 5;
        /// <summary>タイプ付与するバトル ページの上限数</summary>
        private const int MaxGivenTypeCount = 2;
        /// <summary>バトル ページに付与するタイプ</summary>
        private const PokeType GivingType = PokeType.Water;

        /// <summary>
        /// 使用する疑似乱数ジェネレーターを取得または設定します。
        /// </summary>
        public IRandomizer Randomizer { get; set; } = RandomUtilRandomizer.Instance;

        public override void OnAddBuf(int addedStack)
            => stack = Math.Max(stack, MaxStack);

        public override void OnRoundStartAfter()
        {
            try
            {
                AddTypeBufToHand();
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        /// <summary>
        /// 所有キャラクターの手元の、タイプ付与されていないバトル ページをランダムにタイプ付与します。
        /// また、タイプ付与できたバトル ページの使用優先度を 1 上げます。
        /// </summary>
        private void AddTypeBufToHand()
        {
            int givenCount = 0;
            var handList = new List<BattleDiceCardModel>(_owner.allyCardDetail.GetHand().Where(c => !c.IsTyped()));
            while (givenCount < MaxGivenTypeCount && handList.Count > 0)
            {
                BattleDiceCardModel givenCard = Randomizer.SelectOne(handList);
                handList.Remove(givenCard);
                if (givenCard.TryAddType(GivingType))
                {
                    givenCard.SetPriorityAdder(1);
                }
            }
        }
    }
}
