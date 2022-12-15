using System;
using BaseMod;
using PokeAbilities.Core;
using PokeAbilities.Extensions;
using PokeAbilities.Passives.ResultOnly;
using UnityEngine;

namespace PokeAbilities.TypedCardBufs
{
    /// <summary>
    /// タイプ付与されたバトル ページを表すバトル ページ状態の基底クラスです。
    /// </summary>
    public abstract class BattleDiceCardBufTypeBase : BattleDiceCardBuf
    {
        /// <summary>幕をまたいでも永続的にタイプ付与する事を示すフラグ</summary>
        private readonly bool _isPermanent;

        /// <summary>
        /// バトル ページに付与されたタイプを取得します。
        /// </summary>
        public abstract PokeType Type { get; }

        /// <summary>
        /// <see cref="BattleDiceCardBufTypeBase"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。</param>
        public BattleDiceCardBufTypeBase(bool isPermanent)
        {
            _isPermanent = isPermanent;
        }

        public override void OnUseCard(BattleUnitModel owner)
        {
            try
            {
                // タイプ一致とタイプ相性によるダメージ量の増減率の設定は
                // BeforeGiveDamageメソッドで行うのがベストだが、
                // バトルページ状態クラスではそれが用意されていないので状態クラスに委譲させている
                owner.bufListDetail.AddBufByEtc<BattleUnitBuf_TypeAttacker>(0);
                Log.Instance.DebugOnBattleDiceCardBufWithCaller(this, "バトルページを使用してタイプ攻撃キャラクター状態を付与しました。");
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        public override void OnRoundEnd()
        {
            if (_isPermanent) { return; }

            Destroy();
            Log.Instance.DebugOnBattleDiceCardBufWithCaller(this, "バトルページ状態を取り除きました。");
        }

        /// <summary>
        /// 非表示状態「タイプ攻撃キャラクター」
        /// タイプ一致とタイプ相性の効果 (ダメージ量の増減) を発揮する
        /// </summary>
        private class BattleUnitBuf_TypeAttacker : BattleUnitBuf
        {
            // Memo:
            //   この状態のライフサイクルは以下の通り。
            //   OnUseCard(バトルページ使用時)でこの状態が付与される→
            //   BeforeGiveDamage(一方攻撃またはマッチ勝利によってダメージを与えようとする時)でタイプ一致とタイプ相性の効果を適用→
            //   OnEndBattle(バトルページを使用した戦闘の終わり)で状態を取り除く

            /// <summary>付与数の最大値</summary>
            private const int MaxStack = 0;

            public override bool Hide => true;

            public override void OnAddBuf(int addedStack)
                => stack = Mathf.Min(stack, MaxStack);

            public override void BeforeGiveDamage(BattleDiceBehavior behavior)
            {
                try
                {
                    Log.Instance.DebugOnBattleUnitBufWithCaller(this, "バトルダイスでダメージを与えようとしています。");
                    Log.Instance.DebugOnBattleDiceBehavior(behavior, "使用しているバトルダイス。");

                    BattleUnitModel target = behavior.card.target;
                    if (target == null) { return; }
                    if (!behavior.card.card.TryGetType(out PokeType attacker)) { return; }

                    Log.Instance.Debug($"バトルページのタイプ={attacker}");

                    if (_owner.bufListDetail.HasType(attacker))
                    {
                        Log.Instance.Debug("タイプ一致の効果が発揮しました。");
                        _owner.battleCardResultLog?.SetPassiveAbility(PassiveAbility_SameType.Instance);
                        behavior.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = 20, breakRate = 20 });
                    }

                    foreach (PokeType defender in target.bufListDetail.GetTypes())
                    {
                        TypeEffectiveness effectiveness = TypeChart.GetEffectiveness(attacker, defender);
                        switch (effectiveness)
                        {
                            case TypeEffectiveness.SuperEffective:
                                Log.Instance.Debug($"効果はバツグンだ！の効果が発揮しました。({attacker}→{defender})");
                                _owner.battleCardResultLog?.SetPassiveAbility(PassiveAbility_SuperEffective.Instance);
                                behavior.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = 20, breakRate = 20 });
                                break;
 
                            case TypeEffectiveness.NotVeryEffective:
                                Log.Instance.Debug($"効果は今ひとつのようだ……の効果が発揮しました。({attacker}→{defender})");
                                _owner.battleCardResultLog?.SetPassiveAbility(PassiveAbility_NotVeryEffective.Instance);
                                behavior.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = -20, breakRate = -20 });
                                break;

                            case TypeEffectiveness.NoEffect:
                                Log.Instance.Debug($"効果がないようだ…の効果が発揮しました。({attacker}→{defender})");
                                _owner.battleCardResultLog?.SetPassiveAbility(PassiveAbility_NoEffect.Instance);
                                behavior.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = -40, breakRate = -40 });
                                break;

                            default:
                                Log.Instance.Debug($"タイプ相性の効果は発揮しませんでした。({attacker}→{defender})");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorOnExceptionThrown(ex);
                }
            }

            public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
            {
                Destroy();
                Log.Instance.DebugOnBattleUnitBufWithCaller(this, "タイプ攻撃キャラクター状態を取り除きました。");
            }
        }
    }
}
