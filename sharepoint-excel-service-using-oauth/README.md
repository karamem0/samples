# sharepoint-excel-service-using-oauth

![net461](https://img.shields.io/badge/.net-net461-green)
![SharePoint Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

[SharePoint Online の Excel Services (SOAP API) を叩いてみる](https://blog.karamem0.dev/entry/2017/06/13/190000)

OAuth を使用して SharePoint Online の Excel Services (SOAP API) を実行するサンプルです。

## 実行方法

- Azure Active Directory にアプリケーションを登録します。
- 登録したアプリケーションの委任されたアクセス許可に SharePoint Online の AllSites.Write を追加します。
- Program.cs の TenantName, ClientId の値を書き換えます。
- Visual Studio の [サービス参照の追加] から「***SharePoint サイトの URL***/_vti_bin/ExcelService.asmx」を追加します。
- プロジェクトを実行するとデバイス コードの入力を要求されるので、ブラウザーで表示されたデバイス コードを入力します。
