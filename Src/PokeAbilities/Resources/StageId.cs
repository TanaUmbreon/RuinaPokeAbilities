namespace PokeAbilities.Resources
{
    /// <summary>
    /// 接待の LOR ID を表します。
    /// </summary>
    public class StageId : LorId
    {
        /// <summary>本家のパッケージ ID</summary>
        private const string OriginPackageId = "";

        /// <summary>謝肉祭 (本家)</summary>
        public static readonly StageId TheCarnival = new StageId(OriginPackageId, 30001);
        /// <summary>謝肉祭+P</summary>
        public static readonly StageId TheCarnivalP = new StageId(30001);

        /// <summary>
        /// 指定したパッケージ ID と数値 ID で <see cref="StageId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="packageId">接待のパッケージ ID。</param>
        /// <param name="id">接待の数値 ID。</param>
        private StageId(string packageId, int id) : base(packageId, id) { }

        /// <summary>
        /// 指定した数値 ID とこの MOD のパッケージ ID で <see cref="StageId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id">接待の数値 ID。</param>
        private StageId(int id) : base(AssemblyInfo.Name, id) { }
    }
}
