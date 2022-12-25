using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeAbilities.TypeSystem
{
    /// <summary>
    /// 所有キャラクターと手元のバトル ページにタイプ付与するパッシブの基底クラスです。
    /// </summary>
    public abstract class PassiveAbilityTypeBase : PassiveAbilityBase
    {
        // Memo:
        //   このパッシブクラス(PassiveAbilityTypeBase)と状態クラス(BattleUnitBufTypeBase)では
        //   タイプ一致とタイプ相性の効果を実装していない。
        //   これは、タイプを持たないキャラクターでもタイプ付与されたバトルページを使って攻撃する状況があるため。
        //   このような状況に対応するため、バトルページ状態(BattleDiceCardBufTypeBaseクラス)で実装している。

        /// <summary>タイプ付与するバトル ページの上限数</summary>
        private const int MaxGivenTypeCount = 2;
        
        /// <summary>
        /// 使用する疑似乱数ジェネレーターを取得または設定します。
        /// </summary>
        public IRandomizer Randomizer { get; set; } = RandomUtilRandomizer.Instance;

        /// <summary>
        /// 所有キャラクターと手元のバトル ページに付与させるタイプのコレクションを取得します。
        /// </summary>
        public abstract UnitTypes Types { get; }

        public override void OnWaveStart()
        {
            try
            {
                AddTypeBufToOwner();
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        public override void OnRoundStart()
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
        /// 所有キャラクターにタイプ系状態を付与します。
        /// </summary>
        private void AddTypeBufToOwner()
        {
            foreach (PokeType type in Types)
            {
                BattleUnitBuf buf = type.ToUnitBuf();
                owner.bufListDetail.AddBufByEtc(buf, 0);
            }
        }

        /// <summary>
        /// 所有キャラクターの手元の、タイプ付与されていないバトル ページをランダムにタイプ付与します。
        /// このタイプ系パッシブが単体タイプの場合はそのタイプを、
        /// 複合タイプの場合はそれぞれのタイプをバトル ページに付与します。
        /// また、タイプ付与できたバトル ページの使用優先度を 1 上げます。
        /// </summary>
        private void AddTypeBufToHand()
        {
            // 付与するタイプを決定する
            var givingTypes = new Queue<PokeType>();
            while (givingTypes.Count < MaxGivenTypeCount)
            {
                foreach (PokeType type in Randomizer.Sort(Types))
                {
                    givingTypes.Enqueue(type);
                    if (givingTypes.Count >= MaxGivenTypeCount) { break; }
                }
            }

            // 手札にランダムにタイプ付与する
            var handList = new List<BattleDiceCardModel>(owner.allyCardDetail.GetHand().Where(c => !c.IsTyped()));
            while (givingTypes.Count > 0 && handList.Count > 0)
            {
                BattleDiceCardModel givenCard = Randomizer.SelectOne(handList);
                PokeType givingType = givingTypes.Dequeue();
                handList.Remove(givenCard);
                if (givenCard.TryAddType(givingType))
                {
                    givenCard.SetPriorityAdder(1);
                }
            }
        }
    }
}
