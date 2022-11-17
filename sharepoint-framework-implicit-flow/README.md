# sharepoint-framework-implicit-flow

![Node-10](https://img.shields.io/badge/Node-10-green)
![SPFx-1.4.0](https://img.shields.io/badge/SPFx-1.4.0-green)
![SharePoint-Online](https://img.shields.io/badge/SharePoint-Online-blue.svg)

**SharePoint Framework 1.6 で MSGraphClient がリリースされたため、このサンプルを参考にすることはお勧めしません。**

[第 12 回 Plus Programming .net 勉強会で LT してきました](https://zenn.dev/karamem0/articles/2018_01_27_220000)

SharePoint Framework で OAuth の Implicit Flow を独自実装するサンプルです。

## 実行方法

- Azure Active Directory にアプリケーションを登録します。
- プロジェクトの SampleApplicationWebPart.manifest を開き、AppId を書き換えます。
