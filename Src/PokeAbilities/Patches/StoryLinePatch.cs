#pragma warning disable IDE0051 // 使用されていないプライベート メンバーを削除する

using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using PokeAbilities.Resources;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace PokeAbilities.Patches
{
    /// <summary>
    /// シナリオ選択画面に新規ステージを追加する為の HarmonyPatch 割り込み処理を実装します。
    /// </summary>
    [Harmony]
    internal static class StoryLinePatch
    {
        /// <summary>取得した新規ステージ情報のリストとそれに対応するステージ アイコン スロット</summary>
        private static readonly Dictionary<List<StageClassInfo>, UIStoryProgressIconSlot> _storySlots = new Dictionary<List<StageClassInfo>, UIStoryProgressIconSlot>();
        /// <summary>シナリオ選択画面上の新規ステージを初期化した事を示すフラグ</summary>
        private static bool _initializedStoryLine = false;

        /// <summary>
        /// シナリオ選択画面上に新規ステージを追加します。
        /// </summary>
        [HarmonyPatch(typeof(UIStoryProgressPanel), "SetStoryLine")]
        [HarmonyPostfix]
        private static void UIStoryProgressPanel_SetStoryLine_Postfix(UIStoryProgressPanel __instance)
        {
            try
            {
                if (!_initializedStoryLine)
                {
                    // 新規ステージ情報の取得に失敗して正しく初期化できなくても、初期化は一度きりの処理とする
                    _initializedStoryLine = true;

                    CreateStorySlot(__instance,
                        copyFrom: UIStoryLine.TheCarnival,
                        newStageId: StageId.TheCarnivalP,
                        slotOffsetX: -128f,
                        slotOffsetY: 64f);
                }

                foreach (List<StageClassInfo> list in _storySlots.Keys)
                {
                    _storySlots[list].SetSlotData(list);

                    bool actived = list[0].currentState != StoryState.Close;
                    _storySlots[list].SetActiveStory(actived);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
            }
        }

        /// <summary>
        /// 新規ステージ用にストーリースロットを新規作成します。
        /// 指定した本家のステージアイコンをコピーして、それに指定した新規ステージを設定して、指定した位置だけずらします。
        /// </summary>
        /// <param name="targetStoryPanel"></param>
        /// <param name="copyFrom">コピー元のステージアイコン。</param>
        /// <param name="newStageId">設定する新規ステージのLOR ID。</param>
        /// <param name="slotOffsetX">コピー元からの表示位置のオフセット。(X方向)</param>
        /// <param name="slotOffsetY">コピー元からの表示位置のオフセット。(Y方向)</param>
        private static void CreateStorySlot(UIStoryProgressPanel targetStoryPanel, UIStoryLine copyFrom, LorId newStageId, float slotOffsetX = 0f, float slotOffsetY = 0f)
        {
            // 指定したステージアイコンスロットをコピー元(表示位置の起点)として取得する
            List<UIStoryProgressIconSlot> iconList = targetStoryPanel.iconList;
            UIStoryProgressIconSlot copyFromSlot = iconList.FirstOrDefault(slot => slot.currentStory == copyFrom);
            if (copyFromSlot == null)
            {
                Log.Instance.WarningWithCaller("Could not create new story slot. Because 'copyFrom' could not be found.");
                return;
            }

            // 使用する新規ステージ情報を取得する
            StageClassInfo stageInfo = Singleton<StageClassInfoList>.Instance.GetData(newStageId);
            if (stageInfo == null)
            {
                Log.Instance.WarningWithCaller($"Could not create new story slot. Because 'newStageId' could not be found. (newStageId: \"{newStageId}\")");
                return;
            }

            // コピー元のステージアイコンスロットを複製し、表示位置をコピー元からずらす
            UIStoryProgressIconSlot newSlot = CopySlot(copyFromSlot);
            newSlot.Initialized(targetStoryPanel);
            newSlot.transform.localPosition += new Vector3(slotOffsetX, slotOffsetY);

            // 複製したステージアイコンスロットに新規ステージ情報を設定する
            List<StageClassInfo> list = new List<StageClassInfo>() { stageInfo };
            newSlot.SetSlotData(list);
            _storySlots[list] = newSlot;
        }

        /// <summary>
        /// 指定したステージ アイコン スロットを複製して返します。
        /// </summary>
        /// <param name="sourceSlot">複製元となるステージ アイコン スロット。</param>
        /// <returns>複製されたステージ アイコン スロット。</returns>
        private static UIStoryProgressIconSlot CopySlot(UIStoryProgressIconSlot sourceSlot)
        {
            UIStoryProgressIconSlot newSlot = UnityEngine.Object.Instantiate(sourceSlot, sourceSlot.transform.parent);
            newSlot.currentStory = UIStoryLine.Rats;

            GameObject closeRect = newSlot.transform.GetChild(1).gameObject;
            newSlot.closeRect = closeRect;
            newSlot.anim_closeRect= newSlot.transform.GetChild(1).gameObject.GetComponent<Animator>();
            newSlot.cg_closeRect= newSlot.transform.GetChild(1).gameObject.GetComponent<CanvasGroup>();
            newSlot.img_highlighted= newSlot.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>();

            {
                GameObject root = closeRect.transform.GetChild(1).gameObject;
                newSlot.closeIconset = new StoryIconSet
                {
                    root = root,
                    img_iconbg = root.transform.GetChild(0).gameObject.GetComponent<Image>(),
                    img_iconFrame = root.transform.GetChild(1).gameObject.GetComponent<Image>(),
                    img_iconContent = root.transform.GetChild(2).gameObject.GetComponent<Image>(),
                };
            }

            GameObject openRect = newSlot.transform.GetChild(2).gameObject;
            newSlot.openRect = openRect;
            newSlot.openFrameTarget = openRect.transform.GetChild(0).GetChild(0).gameObject;

            {
                GameObject root = openRect.transform.GetChild(1).gameObject;
                newSlot.openIconset = new StoryIconSet
                {
                    root = root,
                    img_iconbg = root.transform.GetChild(0).gameObject.GetComponent<Image>(),
                    img_iconFrame = null,
                    img_iconContent = root.transform.GetChild(1).gameObject.GetComponent<Image>()
                };
            }

            newSlot.iconset_Level = new storyIconLevel[]
            {
                CreateStoryIconLevel(openRect.transform.GetChild(3).GetChild(0).gameObject),
                CreateStoryIconLevel(openRect.transform.GetChild(3).GetChild(1).gameObject),
                CreateStoryIconLevel(openRect.transform.GetChild(3).GetChild(2).gameObject),
            };

            {
                List<GameObject> connectLineList = sourceSlot.connectLineList;
                GameObject connectLine = connectLineList[0];
                newSlot.connectLineList = new List<GameObject>() { UnityEngine.Object.Instantiate(connectLine, connectLine.transform.parent) };
                newSlot.isChapterIcon = false;
                newSlot.currentGrade = Grade.grade1;
            }

            GameObject gameObject6 = null;
            for (int i = 0; i < openRect.transform.childCount; i++)
            {
                if (openRect.transform.GetChild(i).gameObject.name.Contains("[text]chaptername"))
                {
                    gameObject6 = openRect.transform.GetChild(i).gameObject;
                    break;
                }
            }

            TextMeshProUGUI openChapterName = gameObject6?.GetComponent<TextMeshProUGUI>();
            GameObject chapterGrade = newSlot.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
            newSlot.txt_openChapterName = openChapterName;
            newSlot.txt_chaptergrade = chapterGrade.GetComponent<TextMeshProUGUI>();

            return newSlot;
        }

        private static storyIconLevel CreateStoryIconLevel(GameObject root)
            => new storyIconLevel()
            {
                root = root,
                img_iconbg = root.transform.GetChild(0).gameObject.GetComponent<Image>(),
                img_iconFrame = root.transform.GetChild(1).gameObject.GetComponent<Image>(),
                txt_iconContent = root.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>(),
                selectable = root.transform.GetChild(3).gameObject.GetComponent<UICustomSelectable>(),
            };
    }
}
