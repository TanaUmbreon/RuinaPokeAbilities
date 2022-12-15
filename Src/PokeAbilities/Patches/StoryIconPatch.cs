#pragma warning disable IDE0051 // 使用されていないプライベート メンバーを削除する

using System;
using HarmonyLib;
using PokeAbilities.Resources;
using UI;
using UnityEngine;

namespace PokeAbilities.Patches
{
    /// <summary>
    /// カスタム ストーリー アイコンを表示させる為の HarmonyPatch 割り込み処理を実装します。
    /// </summary>
    [Harmony]
    internal static class StoryIconPatch
    {
        /// <summary>
        /// カスタム ストーリー アイコンを設定します。
        /// </summary>
        /// <param name="__result"></param>
        /// <param name="story">アイコンの設定対象のステージ名。</param>
        /// <returns>本来のメソッドを続けて呼び出す場合は true、本来のメソッドを呼び出さず呼び出し元に処理を返す場合は false。</returns>
        [HarmonyPatch(typeof(UISpriteDataManager), "GetStoryIcon")]
        [HarmonyPrefix]
        private static bool UISpriteDataManager_GetStoryIcon_Prefix(ref UIIconManager.IconSet __result, string story)
        {
            try
            {
                if (story != StageName.PokeAbilities) { return true; }

                Sprite sprite = LoadedResources.Instance.GetArtWork(ArtWorkName.PokemonBook);
                if (sprite == null) { return true; }

                __result = new UIIconManager.IconSet
                {
                    icon = sprite,
                    iconGlow = sprite
                };
                return false;
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
                return true;
            }
        }
    }
}
