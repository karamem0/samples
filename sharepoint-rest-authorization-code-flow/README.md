# sharepoint-rest-authorization-code-flow

UWP から SharePoint Online の REST API を実行するサンプルです。

[SharePoint Online の REST API を UWP から実行する](https://blog.karamem0.dev/entry/2016/06/05/000000)

## 実行方法

- SharePoint サイトにアプリの情報を登録して client_id および client_secret を取得します。
- AuthPage.xaml.cs の ClientId および ClientSercret の値を取得した値で書き換えます。
- init.ps1 の $SiteUrl, $UserName, $Password を環境に合わせて書き換えて実行します。実行すると「タイム レコーダー」というカスタム リストが作成されます。
- Visual Studio でプロジェクトを実行します。
