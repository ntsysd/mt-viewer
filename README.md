# ElogView

ELOG シリーズ（ELOG-MT, ELOG-DUAL, ELOG-AMT）の測定データを可視化する
Windows デスクトップアプリケーション。

## Features

- PHX (15 Hz), ADU (32 Hz), AMT (120 Hz) データの表示
- 電場 (EX, EY) / 磁場 (HX, HY, HZ) 5チャンネル表示
- 時間軸レンジ: 30 秒 〜 24 時間
- E/H 独立 Y 軸レンジ（AUTO 対応）
- 1 Hz 平均フィルタ、Detrend 処理
- 印刷プレビュー

## Requirements

- Windows: .NET Framework 4.7.2

## Build

Visual Studio 2019 以上で `ElogView.sln` を開いてビルド。

```sh
msbuild ElogView.sln /p:Configuration=Release
```

実行ファイル: `ElogView/bin/Release/ElogView.exe`

## License

BSD 3-Clause License. See [LICENSE](LICENSE).
