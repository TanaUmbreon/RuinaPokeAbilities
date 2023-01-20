using System;
using PokeAbilities.Types;

namespace PokeAbilities.Weathers
{
    /// <summary>
    /// 状態「あめ」<br/>
    /// 幕の開始時、タイプ付与されていない手元のページ2枚にみずタイプをランダムに付与。<br/>
    /// みずタイプが付与されたページで受けるダメージ・混乱ダメージ量+20%<br/>
    /// ほのおタイプが付与されたページで受けるダメージ・混乱ダメージ量-20%<br/>
    /// 幕の終了時、数値が1減少する(最大5)
    /// </summary>
    public class BattleUnitBuf_Rain : BattleUnitBufWeatherBase
    {
        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            try
            {
                attackerCard.owner.bufListDetail.AddBufByEtc<BattleUnitBuf_AttackToRain>(0, _owner);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            try
            {
                card.target?.bufListDetail.AddBufByEtc<BattleUnitBuf_AttackToRain>(0, _owner);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        /// <summary>
        /// 非表示状態「」
        /// あめが付与されたキャラクターに対して攻撃を行う。
        /// </summary>
        private class BattleUnitBuf_AttackToRain : BattleUnitBuf
        {
            public override void BeforeGiveDamage(BattleDiceBehavior behavior)
            {

            }

            public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
            {
                Destroy();
            }
        }
    }
}
