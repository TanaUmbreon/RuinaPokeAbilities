namespace PokeAbilities.Resources
{
    /// <summary>
    /// 本の LOR ID を表します。
    /// </summary>
    public class BookId : LorId
    {
        /// <summary>携帯獣の本</summary>
        public static readonly BookId PokeAbilities = new BookId(AssemblyInfo.Name, 19960227);

        /// <summary>
        /// 指定したパッケージ ID と数値 ID で <see cref="BookId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="packageId">本のパッケージ ID。</param>
        /// <param name="id">本の数値 ID。</param>
        private BookId(string packageId, int id) : base(packageId, id) { }
    }
}
