using UnityEngine;

namespace PokeAbilities.Resources
{
    /// <summary>
    /// アート ワークを表します。
    /// </summary>
    public class ArtWork
    {
        /// <summary>Poke Abilities で使用する本のアイコン</summary>
        public readonly static ArtWork PokemonBook = new ArtWork("Pokemon");

        /// <summary>
        /// アート ワーク名を取得します。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 指定したアート ワーク名で <see cref="ArtWork"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">アート ワーク名。この名前は MOD の ArtWork フォルダー (子孫フォルダーも含む) に配置した画像ファイルの名前 (拡張子を除く) と一致させる必要があります。</param>
        private ArtWork(string name)
            => Name = name;

        /// <summary>
        /// このアート ワークのスプライトを取得します。
        /// </summary>
        /// <returns><see cref="Name">Name</see> に一致するロード済みのスプライト。取得できなかった場合は null。</returns>
        /// <returns></returns>
        public Sprite GetSprite()
        {
            BaseMod.Harmony_Patch.ArtWorks.TryGetValue(Name, out var atrWork);
            return atrWork;
        }
    }
}
