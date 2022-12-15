using PokeAbilities.Core;

namespace PokeAbilities.TypedPassives
{
    /// <summary>
    /// パッシブ「みずタイプ」<br/>
    /// このキャラクターにみずタイプを付与。<br/>
    /// 幕の開始時、タイプ付与されていない手元のページ2枚にみずタイプをランダムに付与<br/>
    /// (他のタイプと重複不可)
    /// </summary>
    public class PassiveAbility_WaterType : PassiveAbilityTypeBase
    {
        public override UnitTypes Types { get; } = new UnitTypes(PokeType.Water);
    }
}
