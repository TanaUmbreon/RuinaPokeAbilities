namespace PokeAbilities.TypeSystem.TypeUnitBufs
{
    /// <summary>
    /// 状態「でんきタイプ」<br/>
    /// タイプ付与されたページに対して以下の相性を持つ<br/>
    /// [効果はバツグンだ！]<br/>
    /// じめん<br/>
    /// [効果は今ひとつのようだ……]<br/>
    /// でんき、ひこう、はがね
    /// </summary>
    public class BattleUnitBuf_ElectricType : BattleUnitBufTypeBase
    {
        public override PokeType Type => PokeType.Electric;
        public override string keywordId => "ElectricType";
    }
}
