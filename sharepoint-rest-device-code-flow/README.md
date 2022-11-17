# sharepoint-rest-device-code-flow

![.NET-net461](https://img.shields.io/badge/.NET-net461-green)
![SharePoint-Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

OAuth の Devide Code Flow を使用して SharePoint REST API を実行するサンプルです。

## 実行方法

- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションのアクセス許可に SharePoint Online を追加します。
- 登録したアプリケーションに管理者の同意を付与します。
- Program.cs の clientid の値を取得した値で書き換えます。
- Visual Studio でプロジェクトを実行します。
