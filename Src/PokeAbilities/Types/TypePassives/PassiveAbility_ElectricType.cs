namespace PokeAbilities.Types.TypePassives
{
    /// <summary>
    /// パッシブ「でんきタイプ」<br/>
    /// このキャラクターにでんきタイプを付与。<br/>
    /// 幕の開始時、タイプ付与されていない手元のページ2枚にでんきタイプをランダムに付与<br/>
    /// (他のタイプと重複不可)
    /// </summary>
    public class PassiveAbility_ElectricType : PassiveAbilityTypeBase
    {
        public override UnitTypes Types { get; } = new UnitTypes(PokeType.Electric);
    }
}
