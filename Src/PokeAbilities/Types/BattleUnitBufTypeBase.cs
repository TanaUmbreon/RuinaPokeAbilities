namespace PokeAbilities.Types
{
    /// <summary>
    /// タイプを持つキャラクターを表す状態の基底クラスです。
    /// </summary>
    public abstract class BattleUnitBufTypeBase : BattleUnitBuf
    {
        /// <summary>
        /// キャラクターが持つタイプを取得します。
        /// </summary>
        public abstract PokeType Type { get; }
    }
}
