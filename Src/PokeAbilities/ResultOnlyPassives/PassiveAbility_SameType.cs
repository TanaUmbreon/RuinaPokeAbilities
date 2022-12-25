using PokeAbilities.Resources;

namespace PokeAbilities.ResultOnlyPassives
{
    /// <summary>
    /// 表示専用パッシブ「タイプ一致」
    /// 与えるダメージ・混乱ダメージ量が20%増加
    /// </summary>
    public class PassiveAbility_SameType : PassiveAbilityResultOnlyBase
    {
        /// <summary>
        /// 規定のインスタンスを取得します。
        /// </summary>
        public static PassiveAbilityBase Instance { get; } = new PassiveAbility_SameType();

        protected override PassiveDescId DescId => PassiveDescId.SameType;
    }
}
