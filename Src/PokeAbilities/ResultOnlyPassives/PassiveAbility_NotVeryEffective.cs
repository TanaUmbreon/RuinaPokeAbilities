using PokeAbilities.Resources;

namespace PokeAbilities.Passives.ResultOnly
{
    /// <summary>
    /// 表示専用パッシブ「効果は今ひとつのようだ……」
    /// 与えるダメージ・混乱ダメージ量が20%減少
    /// </summary>
    public class PassiveAbility_NotVeryEffective : PassiveAbilityResultOnlyBase
    {
        /// <summary>
        /// 規定のインスタンスを取得します。
        /// </summary>
        public static PassiveAbilityBase Instance { get; } = new PassiveAbility_NotVeryEffective();

        protected override PassiveDescId DescId => PassiveDescId.NotVeryEffective;
    }
}
