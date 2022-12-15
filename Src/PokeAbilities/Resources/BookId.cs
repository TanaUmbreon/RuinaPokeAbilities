namespace PokeAbilities.Resources
{
    /// <summary>
    /// 本の LOR ID を表します。
    /// </summary>
    public class BookId : LorId
    {
        /// <summary>携帯獣の本</summary>
        public static readonly BookId PokeAbilities = new BookId(19960227);

        /// <summary>
        /// 指定した数値 ID とこの MOD のパッケージ ID で <see cref="BookId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id">本の数値 ID。</param>
        private BookId(int id) : base(AssemblyInfo.Name, id) { }
    }
}
