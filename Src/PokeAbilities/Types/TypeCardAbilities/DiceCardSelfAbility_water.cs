namespace PokeAbilities.Types.TypeCardAbilities
{
    /// <summary>
    /// バトル ページ効果「このページはみずタイプ固定」
    /// </summary>
    public class DiceCardSelfAbility_water : DiceCardSelfAbilityTypeBase
    {
        public override PokeType Type => PokeType.Water;
    }
}
