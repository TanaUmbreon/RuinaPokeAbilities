using System;
using PokeAbilities.Resources;

namespace PokeAbilities.ResultOnlyPassives
{
    /// <summary>
    /// 適用された効果の結果ログ (<see cref="BattleCardTotalResult"/>) に表示する為だけのパッシブの基底クラスです。
    /// </summary>
    public abstract class PassiveAbilityResultOnlyBase : PassiveAbilityBase
    {
        /// <summary>
        /// 使用するローカライズのパッシブ説明 LOR ID を取得します。
        /// </summary>
        protected abstract PassiveDescId DescId { get; }

        /// <summary>
        /// <see cref="PassiveAbilityResultOnlyBase"/> の新しいインスタンスを生成します。
        /// </summary>
        public PassiveAbilityResultOnlyBase()
        {
            try
            {
                name = DescId.GetName();
                desc = DescId.GetDesc();
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }
    }

}
