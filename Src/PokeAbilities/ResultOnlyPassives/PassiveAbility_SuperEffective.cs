using PokeAbilities.Resources;

namespace PokeAbilities.Passives.ResultOnly
{
    /// <summary>
    /// 表示専用パッシブ「効果はバツグンだ！」
    /// 与えるダメージ・混乱ダメージ量が20%増加
    /// </summary>
    public class PassiveAbility_SuperEffective : PassiveAbilityResultOnlyBase
    {
        /// <summary>
        /// 規定のインスタンスを取得します。
        /// </summary>
        public static PassiveAbilityBase Instance { get; } = new PassiveAbility_SuperEffective();

        protected override PassiveDescId DescId => PassiveDescId.SuperEffective;
    }
}
