namespace PokeAbilities.TypeSystem.TypeUnitBufs
{
    /// <summary>
    /// 状態「みずタイプ」<br/>
    /// タイプ付与されたページに対して以下の相性を持つ<br/>
    /// [効果はバツグンだ！]<br/>
    /// でんき、くさ<br/>
    /// [効果は今ひとつのようだ……]<br/>
    /// ほのお、みず、こおり、はがね
    /// </summary>
    public class BattleUnitBuf_WaterType : BattleUnitBufTypeBase
    {
        public override PokeType Type => PokeType.Water;

        public override string keywordId => "WaterType";
    }
}
