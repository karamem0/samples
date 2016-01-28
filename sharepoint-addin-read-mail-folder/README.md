# sharepoint-addin-read-mail-folder

![net452](https://img.shields.io/badge/.net-net452-green)
![3.1.1](https://img.shields.io/badge/jquery-3.1.1-green)
![SharePoint Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

SharePoint ホスト型のアドインから Outlook Mail REST API を実行するサンプルです。

## 実行方法

- SharePoint Online に開発者向けサイトを作成します。
- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションの委任されたアクセス許可に Exchange Online の Mail.Read を追加します。
- 登録したアプリケーションの 応答 URL を配置先の URL に変更します。
- 登録したアプリケーションのマニフェスト ファイルの oauth2AllowImplicitFlow を true に変更します。
- プロジェクトの Scripts/WebPart.js を開き、登録したアプリケーションの情報を設定します。
- プロジェクトを開発者向けサイトに発行します。
- 開発者サイトに新しいページを作成し、アプリ パーツを貼り付けます。
