using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PokeAbilities.Resources
{
    /// <summary>
    /// 読み込まれているリソースを参照します。
    /// </summary>
    public class LoadedResources : Singleton<LoadedResources>
    {
        ///// <summary>CustomEffect フォルダーに格納されたファイルの名前とそれに対応するテクスチャー</summary>
        //private readonly Dictionary<string, Texture2D> _customEffectTextures;

        /// <summary>
        /// <see cref="LoadedResources"/> のインスタンスを生成します。
        /// </summary>
        public LoadedResources()
        {
            //var dict = new Dictionary<string, Texture2D>();
            //foreach (FileInfo file in ResourcePath.CustomEffectFiles)
            //{
            //    dict[Path.GetFileNameWithoutExtension(file.Name)] = LoadTexture(file.FullName);
            //}
            //_customEffectTextures = dict;
        }

        /// <summary>
        /// ArtWork フォルダーから読み込んだスプライトを取得します。
        /// </summary>
        /// <param name="name">取得するスプライトの名前。ベースとなるファイルから拡張子を除いた名前を指定します。</param>
        /// <returns>スプライトが存在する場合は <see cref="Sprite" />、存在しない場合は null。</returns>
        public Sprite GetArtWork(string name)
        {
            BaseMod.Harmony_Patch.ArtWorks.TryGetValue(name, out var atrWork);
            return atrWork;
        }

        ///// <summary>
        ///// CustomEffect フォルダーから読み込んだテクスチャーを取得します。
        ///// </summary>
        ///// <param name="name">取得するテクスチャーの名前。ベースとなるファイルから拡張子を除いた名前を指定します。</param>
        ///// <returns>テクスチャーが存在する場合は <see cref="Texture2D" />、存在しない場合は null。</returns>
        //public Texture2D GetCustomEffect(string name)
        //{
        //    if (!_customEffectTextures.TryGetValue(name, out var customEffect))
        //    {
        //        Log.Instance.Warning($"CustomEffect テクスチャ― '{name}' が見つかりません。");
        //    }
        //    return customEffect;
        //}

        ///// <summary>
        ///// 指定したパスの PNG ファイルを読み込み、 <see cref="Texture2D" /> として返します。
        ///// </summary>
        ///// <param name="path">読み込む PNG ファイルのパス。</param>
        ///// <returns>読み込んだ PNG ファイルのテクスチャー。</returns>
        //private static Texture2D LoadTexture(string path)
        //{
        //    byte[] array = File.ReadAllBytes(path);
        //    var texture2D = new Texture2D(2, 2);
        //    ImageConversion.LoadImage(texture2D, array);
        //    return texture2D;
        //}
    }
}
