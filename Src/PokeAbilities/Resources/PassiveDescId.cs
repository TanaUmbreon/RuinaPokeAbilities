namespace PokeAbilities.Resources
{
    /// <summary>
    /// パッシブ説明の LOR ID を表します。
    /// </summary>
    public class PassiveDescId : LorId
    {
        /// <summary>タイプ一致</summary>
        public static readonly PassiveDescId SameType = new PassiveDescId(20000);
        /// <summary>効果はバツグンだ！</summary>
        public static readonly PassiveDescId SuperEffective = new PassiveDescId(20001);
        /// <summary>効果は今ひとつのようだ……</summary>
        public static readonly PassiveDescId NotVeryEffective = new PassiveDescId(20002);
        /// <summary>効果がないようだ…</summary>
        public static readonly PassiveDescId NoEffect = new PassiveDescId(20003);

        /// <summary>
        /// 指定した数値 ID とこの MOD のパッケージ ID で <see cref="PassiveDescId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id">パッシブ説明の数値 ID。</param>
        private PassiveDescId(int id) : base(AssemblyInfo.Name, id) { }
    }
}
