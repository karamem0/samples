# sharepoint-rest-authorization-code-flow

![Windows 10 SDK-1809](https://img.shields.io/badge/Windows%2010%20SDK-1809-green)
![SharePoint-Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

[SharePoint Online の REST API を UWP から実行する](https://zenn.dev/karamem0/articles/2016_06_05_000000)

UWP から SharePoint Online の REST API を実行するサンプルです。

## 実行方法

- SharePoint サイトにアプリの情報を登録して client_id および client_secret を取得します。
- AuthPage.xaml.cs の ClientId および ClientSercret の値を取得した値で書き換えます。
- init.ps1 の $SiteUrl, $UserName, $Password を環境に合わせて書き換えて実行します。実行すると「タイム レコーダー」というカスタム リストが作成されます。
- Visual Studio でプロジェクトを実行します。
