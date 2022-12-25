namespace PokeAbilities.Resources
{
    /// <summary>
    /// 汎用テキストを表します。
    /// </summary>
    public class ExtraText
    {
        /// <summary>特殊な本を入手した時のポップアップ メッセージ (本家)</summary>
        public static readonly ExtraText PopupGetStoryBook = new ExtraText("ui_popup_getstorybook");

        /// <summary>
        /// 汎用テキスト ID を取得します。
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// 指定した汎用テキスト ID で <see cref="ExtraText"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id">汎用テキスト ID。</param>
        private ExtraText(string id)
            => Id = id;
    }
}
