using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeAbilities.TypeSystem
{
    /// <summary>
    /// <see cref="BattleUnitBufListDetail"/> の拡張メソッドを提供します。
    /// </summary>
    public static class BattleUnitBufListDetailExtension
    {
        /// <summary>
        /// 指定したタイプが状態として付与されている事を判定します。
        /// </summary>
        /// <param name="bufListDetail">判定する対象の状態リスト。</param>
        /// <param name="type">判定するタイプ。</param>
        /// <returns>指定したタイプが状態として付与されている場合は true、そうでない場合は false を返します。</returns>
        public static bool HasType(this BattleUnitBufListDetail bufListDetail, PokeType type)
            => bufListDetail.GetActivatedBufList().OfType<BattleUnitBufTypeBase>().Any(b => b.Type == type);

        /// <summary>
        /// 付与されているタイプのコレクションを取得します。
        /// </summary>
        /// <param name="bufListDetail">取得する対象の状態リスト。</param>
        /// <returns>状態として付与されているタイプのコレクション。</returns>
        public static IEnumerable<PokeType> GetTypes(this BattleUnitBufListDetail bufListDetail)
            => bufListDetail.GetActivatedBufList().OfType<BattleUnitBufTypeBase>().Select(b => b.Type);

        /// <summary>
        /// 指定した状態の型と完全一致する状態を指定した幕から検索して返します。
        /// </summary>
        /// <typeparam name="T">検索する状態の型。 <see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を検索する対象の状態リスト。</param>
        /// <param name="readyType">状態を検索する幕。</param>
        /// <returns>指定した状態が有効な状態で見つかった場合はその状態。見つからなかった場合はnull。</returns>
        public static T FindBufExact<T>(this BattleUnitBufListDetail bufListDetail, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf
            => bufListDetail.GetBufList(readyType).FirstOrDefault(b => b.GetType() == typeof(T) && !b.IsDestroyed()) as T;

        /// <summary>
        /// 指定した状態の型と完全一致する状態が、指定した幕にアクティブ状態で付与されている事を判定します。
        /// </summary>
        /// <typeparam name="T">判定する状態の型。 <see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">付与を判定する対象の状態リスト。</param>
        /// <param name="readyType">付与を判定する幕。省略した場合はこの幕。</param>
        /// <returns>指定した状態が有効な状態で付与されている場合は true、そうでない場合は false。</returns>
        public static bool HasBufExact<T>(this BattleUnitBufListDetail bufListDetail, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf
            => bufListDetail.GetBufList(readyType).Any(b => b.GetType() == typeof(T) && !b.IsDestroyed());

        /// <summary>
        /// 指定した状態の型と完全一致する状態を指定した幕から全て削除します。
        /// </summary>
        /// <typeparam name="T">削除する状態の型。</typeparam>
        /// <param name="bufListDetail">削除する対象の状態リスト。</param>
        /// <param name="readyType">削除する対象の幕。省略した場合はこの幕。</param>
        public static void RemoveBufAllExact<T>(this BattleUnitBufListDetail bufListDetail, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf
            => bufListDetail.GetBufList(readyType).RemoveAll(b => b.GetType() == typeof(T));

        /// <summary>
        /// 状態の型、付与数、付与元の行動キャラクター、付与対象の幕を指定して状態を付与します。このメソッドはバトルページの効果により付与するものとして扱います。
        /// </summary>
        /// <typeparam name="T">付与する状態の型。パラメーターなしのデフォルトコンストラクタを持つ、 <see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        public static T AddBufByCard<T>(this BattleUnitBufListDetail bufListDetail, int stack, BattleUnitModel actor = null, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf, new()
            => AddBufDefaultConstructor<T>(bufListDetail, stack, actor, readyType, true);

        /// <summary>
        /// 状態の型、付与数、付与元の行動キャラクター、付与対象の幕を指定して状態を付与します。このメソッドはバトルページ以外(パッシブ、幻想体ページなど)の効果により付与するものとして扱います。
        /// </summary>
        /// <typeparam name="T">付与する状態の型。パラメーターなしのデフォルトコンストラクタを持つ、 <see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        public static T AddBufByEtc<T>(this BattleUnitBufListDetail bufListDetail, int stack, BattleUnitModel actor = null, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf, new()
            => AddBufDefaultConstructor<T>(bufListDetail, stack, actor, readyType, false);

        /// <summary>
        /// 状態、付与数、付与元の行動キャラクター、付与対象の幕を指定して状態を付与します。このメソッドはバトルページの効果により付与するものとして扱います。
        /// </summary>
        /// <typeparam name="T">付与する状態の型。<see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="addingBuf">付与しようとしている状態。このインスタンスの付与数は無視されます。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        public static T AddBufByCard<T>(this BattleUnitBufListDetail bufListDetail, T addingBuf, int stack, BattleUnitModel actor = null, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf
            => AddBufCreatedInstance(bufListDetail, addingBuf, stack, actor, readyType, true);

        /// <summary>
        /// 状態、付与数、付与元の行動キャラクター、付与対象の幕を指定して状態を付与します。このメソッドはバトルページ以外(パッシブ、幻想体ページなど)の効果により付与するものとして扱います。
        /// </summary>
        /// <typeparam name="T">付与する状態の型。<see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="addingBuf">付与しようとしている状態。このインスタンスの付与数は無視されます。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        public static T AddBufByEtc<T>(this BattleUnitBufListDetail bufListDetail, T addingBuf, int stack, BattleUnitModel actor = null, BufReadyType readyType = BufReadyType.ThisRound) where T : BattleUnitBuf
            => AddBufCreatedInstance(bufListDetail, addingBuf, stack, actor, readyType, false);

        /// <summary>
        /// 指定した幕に対応する状態リストを取得します。
        /// </summary>
        /// <param name="readyType">状態リストを取得する幕。</param>
        /// <returns>
        /// 指定した幕に対応する状態リスト。
        /// <list type="bullet">
        /// <item><see cref="BufReadyType.ThisRound"/> の場合、 <see cref="BattleUnitBufListDetail.GetActivatedBufList"/> メソッドで返されるその幕の状態リスト。</item>
        /// <item><see cref="BufReadyType.NextRound"/> の場合、 <see cref="BattleUnitBufListDetail.GetReadyBufList"/> メソッドで返される次の幕の状態リスト。</item>
        /// <item><see cref="BufReadyType.NextNextRound"/> の場合、 <see cref="BattleUnitBufListDetail.GetReadyReadyBufList"/> メソッドで返される 2 幕後の状態リスト。</item>
        /// </list>
        /// </returns>
        private static List<BattleUnitBuf> GetBufList(this BattleUnitBufListDetail bufListDetail, BufReadyType readyType)
        {
            switch (readyType)
            {
                case BufReadyType.ThisRound:
                    return bufListDetail._bufList;
                case BufReadyType.NextRound:
                    return bufListDetail._readyBufList;
                case BufReadyType.NextNextRound:
                    return bufListDetail._readyReadyBufList;
            }

            throw new InvalidOperationException($"Value of BufReadyType is invalid. (Value: {readyType})");
        }

        /// <summary>
        /// 状態の型、付与数、付与元の行動キャラクター、付与対象の幕、バトルページの効果によるものかどうかを指定して状態を付与します。
        /// </summary>
        /// <typeparam name="T">パラメーターなしのデフォルトコンストラクタを持つ、 <see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <param name="byCard">バトルページの効果による付与である事を示す値。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        private static T AddBufDefaultConstructor<T>(this BattleUnitBufListDetail bufListDetail, int stack, BattleUnitModel actor, BufReadyType readyType, bool byCard) where T : BattleUnitBuf, new()
        {
            string GetName(BattleUnitModel unit)
                => unit is null ? "null" : $"'{unit.UnitData.unitData.name}' (位置: {unit.index})";
            Log.Instance.DebugWithCaller($"Called. {{ 対象キャラクター: {GetName(bufListDetail._self)}, 状態の型名: '{typeof(T).Name}', 補正前の付与数: {stack}, 付与元の行動キャラクター: {GetName(actor)}, 付与する幕: {readyType}, バトルページの効果による付与: {byCard} }}");

            // 付与数0で付与するカスタム状態があるので、ここでは付与数0指定でも状態付与できるようにしている
            // (本家のAddKeywordBufXxxメソッドやBaseModのAddBufByXxx拡張メソッドでは、付与数0指定だと状態付与できない)
            if (stack < 0) { Log.Instance.DebugWithCaller("Completed. (付与数がマイナス)"); return null; }

            // 火傷を今の幕以外に付与しようとしている場合、今の幕に変えて付与させる
            if (readyType != BufReadyType.ThisRound && typeof(T) == typeof(BattleUnitBuf_burn))
            {
                return AddBufDefaultConstructor<T>(bufListDetail, stack, actor, BufReadyType.ThisRound, byCard);
            }

            if (actor == null)
            {
                actor = bufListDetail._self;
            }

            // 状態リストから、今回付与しようとしている状態の型と完全一致する状態を現在の状態として取得する
            // ※同じ型の状態が付与されていない場合はnullとする
            T currentBuf = bufListDetail.FindBufExact<T>(readyType);
            Log.Instance.Debug($"- 現在の状態: {(currentBuf is null ? null : $"{{ 型名: '{currentBuf.GetType().Name}', 付与数: {currentBuf.stack} }}")}");

            // 今回付与しようとしている状態のインスタンスを決定する
            // ※同じ型の状態が付与されておらず現在の状態を取得できなかった場合や、独立アイコン状態
            //   (状態が付与されるたび、付与数を加算せず同じ状態アイコンを並べていく形式)である場合はインスタンスを新規生成する
            //   そうでない場合は取得した現在の状態を対象とする
            T addingBuf = (currentBuf == null || currentBuf.independentBufIcon) ? new T() { stack = 0 } : currentBuf;
            Log.Instance.Debug($"- 付与しようとしている状態: {{ 型名: '{addingBuf.GetType().Name}', 現在の状態と同じインスタンス: {(addingBuf == currentBuf)} }}");

            if (!bufListDetail.CanAddBuf(addingBuf)) { Log.Instance.DebugWithCaller("Completed. (状態付与できない)"); return null; }

            // 追加しようとしている状態と現在の状態のインスタンスが異なる場合は、インスタンスを新規生成したと判断する。
            // 新規生成時は状態リストへの追加と状態の初期化を行う
            // ※この処理により、
            //   「addingBuf._ownerフィールドが設定されている」
            //   「addingBufは状態リストに追加されているが付与数は加算される前」
            //   という状態を保証する
            if (addingBuf != currentBuf)
            {
                bufListDetail.GetBufList(readyType).Add(addingBuf);
                addingBuf.Init(bufListDetail._self);
            }

            // 指定された付与数を補正して、その補正後の値で状態の付与数を加算する
            int s = addingBuf.ModifyAndAddStack(stack, actor, readyType, byCard);
            Log.Instance.Debug($"- 実際の付与数: {s}");

            Log.Instance.DebugWithCaller("Completed. (付与成功)");
            return addingBuf;
        }

        /// <summary>
        /// 状態、付与数、付与元の行動キャラクター、付与対象の幕、バトルページの効果によるものかどうかを指定して状態を付与します。
        /// </summary>
        /// <typeparam name="T">付与する状態の型。<see cref="BattleUnitBuf" /> クラスまたはそのサブクラス。</typeparam>
        /// <param name="bufListDetail">状態を付与する対象の状態リスト。</param>
        /// <param name="addingBuf">付与しようとしている状態。このインスタンスの付与数は無視されます。</param>
        /// <param name="stack">状態の付与数。0未満を指定した場合、状態付与を行いません。</param>
        /// <param name="actor">状態の付与元となる行動キャラクター。nullの場合は状態を付与する対象キャラクターが指定されます。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <param name="byCard">バトルページの効果による付与である事を示す値。</param>
        /// <returns>付与した後の状態への参照。付与できなかった場合はnull。</returns>
        private static T AddBufCreatedInstance<T>(this BattleUnitBufListDetail bufListDetail, T addingBuf, int stack, BattleUnitModel actor, BufReadyType readyType, bool byCard) where T : BattleUnitBuf
        {
            string GetName(BattleUnitModel unit)
                => unit is null ? "null" : $"'{unit.UnitData.unitData.name}' (位置: {unit.index})";
            Log.Instance.DebugWithCaller($"Called. {{ 対象キャラクター: {GetName(bufListDetail._self)}, 状態の型名: '{addingBuf.GetType().Name}', 補正前の付与数: {stack}, 付与元の行動キャラクター: {GetName(actor)}, 付与する幕: {readyType}, バトルページの効果による付与: {byCard} }}");

            if (stack < 0) { Log.Instance.DebugWithCaller("Completed. (付与数がマイナス)"); return null; }

            if (readyType != BufReadyType.ThisRound && addingBuf.bufType == KeywordBuf.Burn)
            {
                return AddBufCreatedInstance(bufListDetail, addingBuf, stack, actor, BufReadyType.ThisRound, byCard);
            }

            if (actor == null)
            {
                actor = bufListDetail._self;
            }

            T currentBuf = bufListDetail.FindBufExact<T>(readyType);
            Log.Instance.Debug($"- 現在の状態: {(currentBuf is null ? null : $"{{ 型名: '{currentBuf.GetType().Name}', 付与数: {currentBuf.stack} }}")}");

            addingBuf.stack = 0;
            T actualAddingBuf = (currentBuf == null || currentBuf.independentBufIcon) ? addingBuf : currentBuf;
            Log.Instance.Debug($"- 付与しようとしている状態: {{ 型名: '{actualAddingBuf.GetType().Name}', 現在の状態と同じインスタンス: {(actualAddingBuf == currentBuf)} }}");

            if (!bufListDetail.CanAddBuf(actualAddingBuf)) { Log.Instance.DebugWithCaller("Completed. (状態付与できない)"); return null; }

            if (actualAddingBuf != currentBuf)
            {
                bufListDetail.GetBufList(readyType).Add(actualAddingBuf);
                actualAddingBuf.Init(bufListDetail._self);
            }

            int s = actualAddingBuf.ModifyAndAddStack(stack, actor, readyType, byCard);
            Log.Instance.Debug($"- 実際の付与数: {s}");

            Log.Instance.DebugWithCaller("Completed. (付与成功)");
            return actualAddingBuf;
        }

        /// <summary>
        /// 指定した追加付与数を補正し、その補正した付与数を加算します。
        /// </summary>
        /// <param name="addingBuf">付与しようとしている状態。</param>
        /// <param name="addingStack">追加する付与数。補正前の数値。</param>
        /// <param name="actor">状態を付与しようとしているキャラクター。</param>
        /// <param name="readyType">状態を付与する幕。</param>
        /// <param name="byCard">バトルページの効果によって状態を付与しようとしている事を表す値。</param>
        /// <returns>実際に付与された補正後の付与数。</returns>
        private static int ModifyAndAddStack(this BattleUnitBuf addingBuf, int addingStack, BattleUnitModel actor, BufReadyType readyType, bool byCard)
        {
            // Memo: BattleUnitBufListDetailクラスのAddKeywordBufByCard/ByEtc系メソッドと同等の処理を一つのメソッドとしてまとめている

            int modifiedStack = addingStack; // 補正後の付与数
            BattleUnitModel target = addingBuf._owner; // 付与しようとしている対象のキャラクター

            if (byCard)
            {
                modifiedStack += actor.OnGiveKeywordBufByCard(addingBuf, addingStack, target);
                modifiedStack += target.OnAddKeywordBufByCard(addingBuf, addingStack);
                modifiedStack *= actor.GetMultiplierOnGiveKeywordBufByCard(addingBuf, target);
            }
            modifiedStack = target.bufListDetail.ModifyStack(addingBuf, modifiedStack);

            int beforeStack = addingBuf.stack; // 加算される前の付与数

            addingBuf.stack += modifiedStack;
            addingBuf.OnAddBuf(modifiedStack);

            if (byCard)
            {
                target.OnAddKeywordBufByCardForEvent(addingBuf.bufType, modifiedStack, readyType);
            }

            int afterStack = addingBuf.stack; // 加算された後の付与数
            if (addingBuf.bufType == KeywordBuf.WarpCharge && afterStack > beforeStack)
            {
                target.OnGainChargeStack();
            }

            target.bufListDetail.CheckGift(addingBuf.bufType, modifiedStack, actor);
            if (readyType == BufReadyType.ThisRound)
            {
                target.bufListDetail.CheckAchievements();
            }

            return afterStack - beforeStack;
        }
    }
}
