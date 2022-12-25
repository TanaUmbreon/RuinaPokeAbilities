using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace PokeAbilities
{
    /// <summary>
    /// ログ出力機能を提供します。
    /// </summary>
    public class Log
    {
        /// <summary>タイムスタンプの書式指定文字列</summary>
        private const string TimestampFormat = "yyyy-MM-dd HH:mm:ss.fff";
        /// <summary>ログ ファイルの出力先パス</summary>
        private readonly string FilePath = Path.Combine(AssemblyInfo.DirectoryPath, $"..\\{AssemblyInfo.Name}.log");

        /// <summary>
        /// このクラスのインスタンスを取得します。
        /// 初回呼び出し時にログ ファイルが新規作成されます。既に存在する場合は上書きされます。
        /// </summary>
        public static Log Instance { get; } = new Log();

        /// <summary>
        /// <see cref="Log"/> の新しいインスタンスを生成します。
        /// </summary>
        private Log()
            => File.WriteAllText(FilePath, "");

        /// <summary>
        /// 指定したメッセージでデバッグ レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void Debug(string message)
            => AddLog(LogLevel.Debug, message);

        /// <summary>
        /// 指定したオブジェクトのフィールドを展開したものをデバッグ レベルのログとして追加します。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DebugExpandedFields(object obj, string paramName)
        {
            if (paramName == null) { throw new ArgumentNullException(paramName); }

            Debug($"{{\"{paramName}\": {Expand(obj)}}}");
        }

        /// <summary>
        /// 指定したメッセージにこのメソッドの呼び出し元情報を追加して、デバッグ レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void DebugWithCaller(string message)
            => Debug($"[{GetCallerInfo(new StackTrace())}] {message}");

        public void DebugOnBattleDiceCardBufWithCaller(string message, BattleDiceCardBuf cardBuf)
        {
            StackFrame frame = new StackTrace().GetFrame(1);
            string caller = frame is null ? "Caller not found" : $"{frame.GetMethod().DeclaringType.Name}.{frame.GetMethod().Name}";
            Debug($"[{caller}] {message} (CardName={cardBuf._card.GetName()}, CardOwner={cardBuf._card.owner.faction}:{cardBuf._card.owner.index}:{cardBuf._card.owner.UnitData.unitData.name})");
        }

        public void DebugOnBattleUnitBufWithCaller(string message, BattleUnitBuf buf)
        {
            StackFrame frame = new StackTrace().GetFrame(1);
            string caller = frame is null ? "Caller not found" : $"{frame.GetMethod().DeclaringType.Name}.{frame.GetMethod().Name}";
            string nameWithStack = buf.bufActivatedNameWithStack;
            if (string.IsNullOrEmpty(nameWithStack)) { nameWithStack = $"{buf.GetType().Name}:{buf.stack}"; }
            Debug($"[{caller}] {message} (BufState={nameWithStack}, BufOwner={buf._owner.faction}:{buf._owner.index}:{buf._owner.UnitData.unitData.name})");
        }

        public void DebugOnBattleDiceBehavior(BattleDiceBehavior behavior, string message)
        {
            Debug($"{message} (DiceInfo={behavior.behaviourInCard.Detail}:{behavior.behaviourInCard.Min}-{behavior.behaviourInCard.Dice}, DiceScriptName={behavior.behaviourInCard.Script}, CardName={behavior.card.card.GetName()}, CardOwner={behavior.owner.faction}:{behavior.owner.index}:{behavior.owner.UnitData.unitData.name})");
        }

        /// <summary>
        /// 指定したメッセージで情報レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void Info(string message)
            => AddLog(LogLevel.Info, message);

        /// <summary>
        /// 指定したメッセージにこのメソッドの呼び出し元情報を追加して、情報レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void InfoWithCaller(string message)
            => Info($"[{GetCallerInfo(new StackTrace())}] {message}");

        /// <summary>
        /// 指定したメッセージで警告レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void Warning(string message)
            => AddLog(LogLevel.Warning, message);

        /// <summary>
        /// 指定したメッセージにこのメソッドの呼び出し元情報を追加して、警告レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void WarningWithCaller(string message)
            => Warning($"[{GetCallerInfo(new StackTrace())}] {message}");

        /// <summary>
        /// 指定したメッセージでエラー レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void Error(string message)
            => AddLog(LogLevel.Error, message);

        /// <summary>
        /// 指定したメッセージにこのメソッドの呼び出し元情報を追加して、エラー レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public void ErrorWithCaller(string message)
            => Error($"[{GetCallerInfo(new StackTrace())}] {message}");

        /// <summary>
        /// 指定した例外の説明メッセージとスタックトレースでエラー レベルのログを追加します。
        /// </summary>
        /// <param name="message">出力する例外。</param>
        public void Error(Exception ex)
            => Error($"{ex.Message}\n{ex.StackTrace}");

        /// <summary>
        /// 例外がスローされた時の規定のエラー レベルのログを追加します。
        /// 指定した例外の説明メッセージとスタックトレースがログに追加されます。
        /// </summary>
        /// <param name="ex"></param>
        public void ErrorOnExceptionThrown(Exception ex)
        {
            Error($"[{GetCallerInfo(new StackTrace())}] Exception thrown.");
            Error(ex);
        }

        /// <summary>
        /// タイムスタンプと、指定したレベルおよびメッセージをログに追加します。
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        private void AddLog(LogLevel level, string message)
            => File.AppendAllText(FilePath, $"{DateTime.Now.ToString(TimestampFormat)}|{level.Text,-5}|{message}\n");

        /// <summary>
        /// 指定したスタック トレースから呼び出し元のクラス名およびメソッド名を返します。
        /// </summary>
        /// <param name="trace"></param>
        /// <returns></returns>
        private string GetCallerInfo(StackTrace trace)
        {
            StackFrame caller = trace.GetFrame(1);
            if (caller == null) { return "Caller not found"; }
            return $"{caller.GetMethod().DeclaringType.Name}.{caller.GetMethod().Name}";
        }

        private string Expand(object obj)
        {
            return ExpandObject(obj, new Stack<object>());
        }

        private string ExpandObject(object obj, Stack<object> expandedObjectStack)
        {
            const int MaxDepth = 4;
            if (expandedObjectStack.Contains(obj) || expandedObjectStack.Count >= MaxDepth) { return "\"...\""; }
            expandedObjectStack.Push(obj);

            try
            {
                switch (obj)
                {
                    case null:
                        return "null";
                    case string str:
                        return $"\"{str.Replace("\"", "\"\"").Replace("\n", "\\n")}\"";
                    case IEnumerable arr:
                        return $"[{string.Join(", ", ExpandCollection(arr, expandedObjectStack))}]";
                    case int num:
                        return num.ToString();
                    case float num:
                        return num.ToString();
                    case bool b:
                        return b.ToString().ToLower();
                    case Enum e:
                        return $"\"{e.GetType().Name}.{e}\"";
                    case byte num:
                        return num.ToString();
                    case short num:
                        return num.ToString();
                    case long num:
                        return num.ToString();
                    case double num:
                        return num.ToString();
                    case DateTime date:
                        return $"\"{date}\"";
                    default:
                        return $"{{{string.Join(", ", ExpandFields(obj, expandedObjectStack))}}}";
                }
            }
            finally
            {
                expandedObjectStack.Pop();
            }
        }

        private IEnumerable<string> ExpandCollection(IEnumerable objects, Stack<object> expandedObjectStack)
        {
            foreach (object obj in objects)
            {
                yield return ExpandObject(obj, expandedObjectStack);
            }
        }

        private IEnumerable<string> ExpandFields(object obj, Stack<object> expandedObjectStack)
        {
            foreach (FieldInfo member in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                object memberValue = member.GetValue(obj);
                yield return $"\"{member.Name}\": {ExpandObject(memberValue, expandedObjectStack)}";
            }
        }

        /// <summary>
        /// ログのレベルを表します。
        /// </summary>
        private class LogLevel
        {
            /// <summary>デバッグ</summary>
            public static readonly LogLevel Debug = new LogLevel("Debug");
            /// <summary>情報</summary>
            public static readonly LogLevel Info = new LogLevel("Info");
            /// <summary>警告</summary>
            public static readonly LogLevel Warning = new LogLevel("Warn");
            /// <summary>エラー</summary>
            public static readonly LogLevel Error = new LogLevel("Error");
            /// <summary>重大</summary>
            public static readonly LogLevel Fatal = new LogLevel("Fatal");

            /// <summary>
            /// ログのレベルを表す文字列を取得します。
            /// </summary>
            public string Text { get; }

            /// <summary>
            /// <see cref="LogLevel"/> の新しいインスタンスを生成します。
            /// </summary>
            /// <param name="text">ログのレベルを表す文字列。</param>
            private LogLevel(string text)
                => Text = text;
        }
    }
}
