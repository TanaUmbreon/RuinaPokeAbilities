using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PokeAbilities.Resources
{
	/// <summary>
	/// 実行中のアプリケーション ドメインで読み込まれているアセンブリを表します。
	/// </summary>
    public static class LoadedAssembly
    {
		/// <summary>
		/// Assembly-CSharp.dll を取得します。
		/// </summary>
		public static Assembly AssemblyCSharp => GetAssembly(name: "Assembly-CSharp");

		/// <summary>アセンブリの簡易名とそれに対応するアセンブリの参照を格納したキャッシュ用のディクショナリ</summary>
		private static readonly Dictionary<string, Assembly> _cache = new Dictionary<string, Assembly>();

		/// <summary>
		/// 実行中のアプリケーション ドメインで読み込まれているアセンブリから、指定した簡易名に一致するアセンブリを取得します。
		/// </summary>
		/// <param name="name">取得するアセンブリの簡易名。通常は、アセンブリ ファイルの名前から拡張子を取り除いたものになります。</param>
		/// <returns>指定した簡易名に一致するアセンブリの参照。</returns>
		private static Assembly GetAssembly(string name)
		{
			if (name == null) { throw new ArgumentNullException(nameof(name)); }

			if (!_cache.ContainsKey(name))
			{
				_cache[name] = AppDomain.CurrentDomain.GetAssemblies()
					.FirstOrDefault(a => a.GetName().Name == name);
			}

			Assembly assembly = _cache[name];
			if (assembly == null) { throw new DllNotFoundException($"指定した名前 '{name}' に一致するアセンブリが見つかりません。"); }
			return assembly;
		}
	}
}
