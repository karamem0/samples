# sharepoint-rest-password-credentials-flow

OAuth の Resource Owner Password Credentials Flow を使用して SharePoint REST API を実行するサンプルです。

[SharePoint Online の REST API を対話なしで実行する](https://blog.karamem0.dev/entry/2016/05/19/080000)

## 実行方法

- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションのアクセス許可に SharePoint Online を追加します。
- 登録したアプリケーションに管理者の同意を付与します。
- Program.cs の clientid の値を取得した値で書き換えます。
- Visual Studio でプロジェクトを実行します。
