# sharepoint-addin-read-dynamics

![.NET-net452](https://img.shields.io/badge/.NET-net452-green)
![jQuery-3.0.0](https://img.shields.io/badge/jQuery-3.0.0-green)
![SharePoint-Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

[SharePoint Online から Dynamics 365 の Web API を実行する](https://zenn.dev/karamem0/articles/2016_06_24_200000)

SharePoint ホスト型のアドインから Dynamics CRM Web API を実行するサンプルです。

## 実行方法

- SharePoint Online に開発者向けサイトを作成します。
- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションの委任されたアクセス許可に Dyamics CRM Online を追加します。
- 登録したアプリケーションの 応答 URL を配置先の URL に変更します。
- 登録したアプリケーションのマニフェスト ファイルの oauth2AllowImplicitFlow を true に変更します。
- プロジェクトの Scripts/WebPart.js を開き、登録したアプリケーションの情報を設定します。
- プロジェクトを開発者向けサイトに発行します。
- 開発者サイトに新しいページを作成し、アプリ パーツを貼り付けます。
