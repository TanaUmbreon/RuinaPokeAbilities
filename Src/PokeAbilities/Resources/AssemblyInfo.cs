using System.IO;
using System.Reflection;

namespace PokeAbilities.Resources
{
    /// <summary>
    /// このアセンブリに関する情報を参照するユーティリティ クラスです。
    /// </summary>
    internal static class AssemblyInfo
    {
        /// <summary>
        /// アセンブリのパスを取得します。
        /// </summary>
        public static string ApplicationPath { get; private set; }

        /// <summary>
        /// アセンブリが格納されているフォルダーを取得します。
        /// </summary>
        public static string DirectoryPath { get; private set; }

        /// <summary>
        /// アセンブリの簡易名を取得します。通常これは、ファイル名から拡張子を除いた名前となります。
        /// </summary>
        public static string Name { get; private set; }

        /// <summary>
        /// <see cref="AssemblyInfo"/> の静的コンストラクタ。
        /// </summary>
        static AssemblyInfo()
        {
            Assembly a = Assembly.GetExecutingAssembly();

            ApplicationPath = a.Location;
            DirectoryPath = Path.GetDirectoryName(a.Location) ?? "";
            Name = a.GetName().Name;
        }
    }
}
