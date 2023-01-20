using System;

namespace PokeAbilities.Types
{
    /// <summary>
    /// 固定されたタイプを持たせるためのバトル ページ効果の基底クラスです。
    /// </summary>
    public abstract class DiceCardSelfAbilityTypeBase : DiceCardSelfAbilityBase
    {
        /// <summary>
        /// バトル ページに固定で付与させるタイプを取得します。
        /// </summary>
        public abstract PokeType Type { get; }

        public override void OnAddToHand(BattleUnitModel owner)
        {
            try
            {
                card.card.TryAddType(Type, true);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }
    }
}
