# AddOnSample

C# でプロダクトにアドオン機能を実装するサンプル。  

# 概要

1. アドオンとして追加の機能を実装したい開発者が、特定のインタフェース (※1) を実装したクラスライブラリを作成 (※2) する。
1. クラスライブラリのアセンブリ (.dll) を実行ファイル (ExpandableApp1 プロジェクトのアセンブリ) の横に addons ディレクトリを作りその中にコピーする。
1. 実行すると追加機能が呼び出される。

というサンプル。

# ※1、※2
#### ※1 特定のインタフェース
AddOnInterfaces プロジェクトのふたつのインタフェース

#### ※2 アドオンクラスライブラリプロジェクト
MyAddOn1、MyAddOn2 のふたつのプロジェクト

# 実行例
アドオンの .dll を置かない状態だと、コンソールの行入力を読み取っておうむ返しにテキストを出力します。  
アドオンの .dll を置くと、コンソールの入力に対してアドオン機能により可能されたテキスト (先頭と末尾にテキストが追加される) を出力します。
