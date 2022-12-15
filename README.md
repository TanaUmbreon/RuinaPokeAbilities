# Poke Abilities

ゲーム「[Library Of Ruina](https://store.steampowered.com/app/1256670/Library_Of_Ruina/)」のワークショップ対応版MOD第3弾です。ポ○モンの特性とタイプをパッシブとして追加します。

## 実装済みの機能

- [x] キャラクターとバトルページへのタイプ付与。
- [x] タイプ相性によるダメージ・混乱ダメージ量の増減。
  - 攻撃キャラクターのバトルページに付与されたタイプと、攻撃を受けるキャラクターに付与されたタイプの相性で増減が決定する。
    - `効果はバツグンだ！`：与えるダメージ・混乱ダメージ量+20%
    - `効果は今ひとつのようだ……`：与えるダメージ・混乱ダメージ量-20%
    - `効果がないようだ…`：与えるダメージ・混乱ダメージ量-40%
  - タイプ相性は本家第六世代以降のものと同じ。
- [x] タイプ一致によるダメージ・混乱ダメージ量の増加。
  - 攻撃キャラクターに付与されたタイプと攻撃キャラクターのバトルページに付与されたタイプが同じ場合に増加する。
    - `タイプ一致`：与えるダメージ・混乱ダメージ量+20%
- [x] タイプ付与された敵との接待。
  - 謝肉祭の接待のクリア後、謝肉祭のストーリーアイコンそばに新規接待を追加。
    - 新規接待に必要な本(`携帯獣の本`)は謝肉祭の接待終了後に手に入る。
      - ロボトミーコーポレーションの本やねじれの本と同じ入手の仕方。
    - 接待する相手は謝肉祭と同じで、敵キャラクターにそれぞれタイプ系パッシブを追加している。
    - 接待して入手する本を燃やすことで、各ポケモンのコアページ(帰属専用)が手に入る。
      - このコアページのパッシブを帰属することで味方キャラクターも使用できるようになる。

## 未実装 (旧バージョンから移植中)

- [ ] 各ポケモンのコアページに特性をモチーフにしたパッシブを追加する。
- [ ] 天候変化系のバトルページを追加する。
