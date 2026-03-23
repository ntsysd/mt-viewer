# Changelog

## v1.5.1 (2026-03-23)

### Bug Fixes
- 外部SSD上のデータ読み込みで描画が崩れる問題を修正（fs.Read short read対策）
- 120Hz(AMT) 24時間データでバッファオーバーランする問題を修正
- 設定ファイル(settings.xml)の要素欠損時にクラッシュする問題を修正
- データ破損時のタイムスタンプ値域チェックを追加
- ファイルサイズ変数を long に変更（2GB超対応）
- 未使用メソッド(NotImplementedException)を削除

### Performance
- バイナリデータ変換(Byte3_to_int32)をビット演算に変更しGC負荷を削減
- データ配列コピーを必要分のみに最適化
- グラフ描画時のXDate生成を軽量化(ToOADate使用)

### Other
- BSD 3-Clause LICENSEファイルを追加

## v1.5.0 (2024-11-11)

- ELOG-AMT 120Hz データ表示に対応
- Model選択(MT/DUAL/AMT)とMode選択の連動

## v1.4.1

- ELOG-DUAL対応
- グラフ時間軸幅の不一致を改善

## v1.4.0

- E/H独立Y軸レンジ対応
- 数値指定によるY軸レンジ設定
- Range値表示

## v1.3.0

- E/H独立Y軸レンジ
- 時間レンジ追加（30秒、1分）

## v1.2.2

- ウィンドウ終了時のバグ修正

## v1.2.1

- ウィンドウ終了時のバグ修正

## v1.2.0

- グラフレイアウト変更（縦EX-EY-HX-HY-HZ配置）
- Y軸AUTO機能
