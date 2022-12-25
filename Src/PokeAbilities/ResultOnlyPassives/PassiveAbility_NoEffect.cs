using PokeAbilities.Resources;

namespace PokeAbilities.ResultOnlyPassives
{
    /// <summary>
    /// 表示専用パッシブ「効果がないようだ…」
    /// 与えるダメージ・混乱ダメージ量が40%減少
    /// </summary>
    public class PassiveAbility_NoEffect : PassiveAbilityResultOnlyBase
    {
        /// <summary>
        /// 規定のインスタンスを取得します。
        /// </summary>
        public static PassiveAbilityBase Instance { get; } = new PassiveAbility_NoEffect();

        protected override PassiveDescId DescId => PassiveDescId.NoEffect;
    }
}
