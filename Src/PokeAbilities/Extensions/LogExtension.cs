using System.Diagnostics;

namespace PokeAbilities.Extensions
{
    public static class LogExtension
    {
        public static void DebugOnBattleDiceCardBufWithCaller(this Log log, BattleDiceCardBuf cardBuf, string message)
        {
            StackFrame frame = new StackTrace().GetFrame(1);
            string caller = frame is null ? "Caller not found" : $"{frame.GetMethod().DeclaringType.Name}.{frame.GetMethod().Name}";
            log.Debug($"[{caller}] {message} (ページ名={cardBuf._card.GetName()}, 所有={cardBuf._card.owner.faction}:{cardBuf._card.owner.index}:{cardBuf._card.owner.UnitData.unitData.name})");
        }

        public static void DebugOnBattleUnitBufWithCaller(this Log log, BattleUnitBuf buf, string message)
        {
            StackFrame frame = new StackTrace().GetFrame(1);
            string caller = frame is null ? "Caller not found" : $"{frame.GetMethod().DeclaringType.Name}.{frame.GetMethod().Name}";
            string nameWithStack = buf.bufActivatedNameWithStack;
            if (string.IsNullOrEmpty(nameWithStack)) { nameWithStack = $"{buf.GetType().Name}:{buf.stack}"; }
            log.Debug($"[{caller}] {message} (状態={nameWithStack}, 所有={buf._owner.faction}:{buf._owner.index}:{buf._owner.UnitData.unitData.name})");
        }

        public static void DebugOnBattleDiceBehavior(this Log log, BattleDiceBehavior behavior, string message)
        {
            log.Debug($"{message} (ダイス情報={behavior.behaviourInCard.Detail}:{behavior.behaviourInCard.Min}-{behavior.behaviourInCard.Dice}, ダイス効果スクリプト名={behavior.behaviourInCard.Script}, ページ名={behavior.card.card.GetName()}, 所有={behavior.owner.faction}:{behavior.owner.index}:{behavior.owner.UnitData.unitData.name})");
        }
    }
}
