using PokeAbilities.Resources;
using PokeAbilities.Types;

namespace PokeAbilities.Weathers
{
    /// <summary>
    /// バトル ページ効果「このページはみずタイプ固定<br/>
    /// [使用時] 全てのキャラクターにあめ5を付与」
    /// </summary>
    public class DiceCardSelfAbility_water_rain5all : DiceCardSelfAbilityWeatherBase
    {
        public override PokeType Type => PokeType.Water;

        public override string[] Keywords => new[] { KeywordId.RainSimple };
    }
}
