# Libフォルダーについて

このフォルダーは、 `Src` フォルダーにあるソースコードをビルドしてMODの実行ファイルを作成するために必須となる、各種ライブラリ (DLLファイル) を配置するためのフォルダーです。

ソースコードをビルドしたい場合、このフォルダーに以下のDLLファイルを配置してください。

- ゲーム本体からコピペして配置 (\*1)
  - `Assembly-CSharp.dll`
  - `Unity.TextMeshPro.dll`
  - `UnityEngine.AnimationModule.dll`
  - `UnityEngine.CoreModule.dll`
  - `UnityEngine.ImageConversionModule.dll`
  - `UnityEngine.UI.dll`
  - `UnityEngine.UIModule.dll`
- 「BaseMod for Workshop」からコピペして配置 (\*2)
  - `0Harmony.dll`
  - `BaseMod.dll`
  - `Mono.Cecil.dll`
  - `Mono.Cecil.Mdb.dll`
  - `Mono.Cecil.Pdb.dll`
  - `Mono.Cecil.Rocks.dll`
  - `MonoMod.Common.dll`
  - `MonoMod.RuntimeDetour.dll`
  - `MonoMod.Utils`
  - `MyJsonTool.dll`
  - `NAudio.dll`

\*1: Steamでゲーム本体を購入してダウンロードすると、一般的には `C:\Program Files (x86)\Steam\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Managed` フォルダーにこれらのDLLがインストールされます。

\*2: Steamワークショップで公開されているMOD「[BaseMod for Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2603522001)」をサブスクライブすると、一般的には `C:\Program Files (x86)\Steam\steamapps\workshop\content\1256670\2603522001\Assemblies` フォルダーにこれらのDLLがインストールされます。
