using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokeAbilities.Resources
{
    /// <summary>
    /// 外部リソースのパスを参照します。
    /// </summary>
    public static class ResourcePath
    {
        /// <summary>CustomEffect フォルダーに格納されたファイルのコレクション</summary>
        public static readonly IEnumerable<FileInfo> CustomEffectFiles =
            GetFiles(CustomEffectDirectory, @"\.png$");

        /// <summary>CustomEffect フォルダーのパス</summary>
        private static readonly string CustomEffectDirectory =
            Path.Combine(AssemblyInfo.DirectoryPath, "CustomEffect");

        /// <summary>
        /// 指定したフォルダーとそのサブフォルダーから、指定した検索パターンに一致するファイルのコレクションで返します。
        /// </summary>
        /// <param name="directoryPath">ファイルのコレクションを取得する対象のフォルダー パス。</param>
        /// <param name="regexSearchPattern">ファイル名と照合する正規表現の検索パターン。照合する時に大文字小文字は区別しません。</param>
        /// <returns>条件に一致したファイルのコレクション。</returns>
        private static IEnumerable<FileInfo> GetFiles(string directoryPath, string regexSearchPattern)
            => new DirectoryInfo(directoryPath)
                .GetFiles("*", SearchOption.AllDirectories)
                .Where(f => Regex.IsMatch(f.Name, regexSearchPattern, RegexOptions.IgnoreCase));
    }
}
