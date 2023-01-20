using System;
using PokeAbilities.Types;

namespace PokeAbilities.Weathers
{
    /// <summary>
    /// 天候の付与と固定されたタイプを持たせるためのバトル ページ効果の基底クラスです。
    /// </summary>
    public abstract class DiceCardSelfAbilityWeatherBase : DiceCardSelfAbilityTypeBase
    {
        public override void OnUseCard()
        {
            try
            {
                foreach (BattleUnitModel target in BattleObjectManager.instance.GetAliveList())
                {
                    target.bufListDetail.GetActivatedBufList().RemoveAll(b => b is BattleUnitBufWeatherBase);
                    target.bufListDetail.AddBufByCard<BattleUnitBuf_Rain>(5);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }
    }
}
