namespace PokeAbilities.Core
{
    /// <summary>
    /// タイプ相性による効果を表します。
    /// </summary>
    public enum TypeEffectiveness
    {
        /// <summary>効果はバツグンだ！</summary>
        SuperEffective,
        /// <summary>普通</summary>
        Normal,
        /// <summary>効果は今ひとつのようだ……</summary>
        NotVeryEffective,
        /// <summary>効果がないようだ…</summary>
        NoEffect,
    }
}
