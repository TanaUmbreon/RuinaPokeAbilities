#pragma warning disable IDE0051 // 使用されていないプライベート メンバーを削除する

using System;
using BaseMod;
using HarmonyLib;
using PokeAbilities.Resources;

namespace PokeAbilities.Patches
{
    /// <summary>
    /// 接待終了時のリワードで特殊な本を獲得する為の HarmonyPatch 割り込み処理を実装します。
    /// </summary>
    [Harmony]
    internal static class DropSpecialBookPatch
    {
        [HarmonyPatch(typeof(StageController), "BonusRewardWithPopup")]
        [HarmonyPostfix]
        private static void StageController_BonusRewardWithPopup_Postfix()
        {
            try
            {
                if (IsClear(StageId.TheCarnival) && !HasPokeAbilitiesBook())
                {
                    DropBookInventoryModel.Instance.AddBook(BookId.PokeAbilities, 1);
                    string bookName = DropBookXmlList.Instance.GetData(BookId.PokeAbilities).Name;
                    Tools.SetAlarmText(ExtraTextId.PopupGetStoryBook, args: bookName);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        /// <summary>
        /// 指定した接待をクリアしている事を判定します。
        /// </summary>
        /// <param name="stageId">クリア判定の対象となる接待の LOR ID。</param>
        /// <returns></returns>
        private static bool IsClear(StageId stageId)
            => LibraryModel.Instance.ClearInfo.GetClearCount(stageId) >= 0;

        /// <summary>
        /// 携帯獣の本を所持していることを判定します。
        /// </summary>
        /// <returns></returns>
        private static bool HasPokeAbilitiesBook()
            => DropBookInventoryModel.Instance.GetBookCount(BookId.PokeAbilities) > 0;
    }
}
