namespace PokeAbilities.Resources
{
    /// <summary>
    /// パッシブ説明の LOR ID を表します。
    /// </summary>
    public class PassiveDescId : LorId
    {
        /// <summary>タイプ一致</summary>
        public static readonly PassiveDescId SameType = new PassiveDescId(AssemblyInfo.Name, 20000);
        /// <summary>効果はバツグンだ！</summary>
        public static readonly PassiveDescId SuperEffective = new PassiveDescId(AssemblyInfo.Name, 20001);
        /// <summary>効果は今ひとつのようだ……</summary>
        public static readonly PassiveDescId NotVeryEffective = new PassiveDescId(AssemblyInfo.Name, 20002);
        /// <summary>効果がないようだ…</summary>
        public static readonly PassiveDescId NoEffect = new PassiveDescId(AssemblyInfo.Name, 20003);

        /// <summary>
        /// 指定したパッケージ ID と数値 ID で <see cref="PassiveDescId"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id">パッシブ説明の数値 ID。</param>
        private PassiveDescId(string packageId, int id) : base(packageId, id) { }

        /// <summary>
        /// この LOR ID に一致するパッシブ説明 XML データのパッシブ名を取得します。
        /// </summary>
        /// <returns>この LOR ID に最初に一致するパッシブ説明 XML データのパッシブ名。取得できなかった場合は <see cref="string.Empty"/>。</returns>
        public string GetName()
            => PassiveDescXmlList.Instance.GetName(this);

        /// <summary>
        /// この LOR ID に一致するパッシブ説明 XML データの説明テキストを取得します。
        /// </summary>
        /// <returns>この LOR ID に最初に一致するパッシブ説明 XML データの説明テキスト。取得できなかった場合は <see cref="string.Empty"/>。</returns>
        public string GetDesc()
            => PassiveDescXmlList.Instance.GetDesc(this);
    }
}
