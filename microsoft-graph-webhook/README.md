# microsoft-graph-webhook

![.NET-netcoreapp2.1](https://img.shields.io/badge/.NET-netcoreapp2.1-green)

Azure Functions を使って変更通知 (サブスクリプション) を受け取るサンプルです。

## 実行方法

- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションのアプリケーションのアクセス許可に Microsoft Graph の Users.Read.All を追加します。
- プロジェクトを Azure Funtions にデプロイします。
- Azure Funtions のアプリケーション設定で登録したアプリケーションの情報を設定します。
- Azure Funtions の CreateWebhook エンドポイントを実行するとサブスクリプションを開始します。
- Azure Funtions の DeleteWebhook エンドポイントを実行するとサブスクリプションを終了します。
