# アプリケーションの基底パス
$APP_DIR = "$PSScriptRoot/SampleApplication"
# マニフェスト ファイルのパス
$MANIFEST_FILE = "$APP_DIR/config/write-manifests.json"
# ソース ファイルの出力先のパス
$APP_SOURCE_DIR = "$APP_DIR/temp/deploy"
# パッケージ ファイルの出力先のパス
$APP_PACKAGE_FILE = "$APP_DIR/sharepoint/solution/SampleApplication.sppkg"

# CDN の URL
$CDN_BASE_PATH = '{{cdnpath}}'

# デプロイ先テナントのホスト名
$TENANT_HOST_NAME = '{{tenantname}}.sharepoint.com'
# レリムの取得先
$REALM_URL = '/_vti_bin/client.svc'
# アクセス トークンの取得先
$OAUTH_TOKEN_URL = 'https://accounts.accesscontrol.windows.net/{0}/tokens/oauth/2'
# アプリケーション ID
$OAUTH_APP_ID = '{{clientid}}'
# アプリケーション シークレット
$OAUTH_APP_SECRET = '{{clientsecret}}'
# リソース ID
$OAUTH_RESOURCE_ID = '00000003-0000-0ff1-ce00-000000000000'

# ソース ファイルの配置先サイト
$SOURCE_SITE_URL = '/path/to/site'
# ソース ファイルの配置先リスト
$SOURCE_LIST_URL = '/path/to/site/list'

# パッケージ ファイルの配置先サイト
$CATALOG_SITE_URL = '/path/to/site'

# アプリケーションのインストール先サイト
$INSTALL_SITE_URL = '/path/to/site'

$manifest = Get-Content $MANIFEST_FILE -Encoding 'UTF8' | ConvertFrom-Json
$manifest.cdnBasePath = $CDN_BASE_PATH
ConvertTo-Json $manifest | %{ [Text.Encoding]::UTF8.GetBytes($_) } | Set-Content $MANIFEST_FILE -Encoding 'Byte'

Set-Location $APP_DIR
npm update
gulp bundle --ship
gulp package-solution --ship

try {
    $request = @{
        Uri = [System.String]::Format('https://{0}{1}', $TENANT_HOST_NAME, $REALM_URL)
        Method = 'GET'
        Headers = @{
            'Authorization' = "Bearer"
        }
    }
    Invoke-RestMethod @request
}
catch {
    $response = $_.Exception.Response
    $response.Headers['WWW-Authenticate'] -match 'realm="(.+?)"' > $null
    $realm = $matches[1]
}

try {
    $request = @{
        Uri = [System.String]::Format($OAUTH_TOKEN_URL, $realm)
        Method = 'POST'
        Headers = @{
            'Accept' = 'application/json'
            'Content-Type' = 'application/x-www-form-urlencoded'
        }
        Body = 'grant_type=client_credentials' `
            + '&client_id=' + [System.Uri]::EscapeDataString($OAUTH_APP_ID + '@' + $realm) `
            + '&client_secret=' + [System.Uri]::EscapeDataString($OAUTH_APP_SECRET) `
            + '&resource=' + [System.Uri]::EscapeDataString($OAUTH_RESOURCE_ID + '/' + $TENANT_HOST_NAME + '@' + $realm)
    }
    $response = Invoke-RestMethod @request
    $token = $response.access_token
}
catch {
    Write-Error ($_.Exception)
    exit 1
}

foreach ($file in (Get-ChildItem -Path $DEPLOY_SOURCE_DIR -File)) {
    try {
        $request = @{
            Uri = [System.String]::Format( `
                "https://{0}{1}/_api/web/getfolderbyserverrelativeurl('{2}')/files/add(url='{3}',overwrite=true)", `
                $TENANT_HOST_NAME, $SOURCE_SITE_URL, $SOURCE_LIST_URL, $file.Name `
            )
            Method = 'POST'
            Headers = @{
                'Accept' = 'application/json;odata=nometadata'
                'Authorization' = "Bearer " + $token
            }
            InFile = $file.FullName
        }
        $response = Invoke-RestMethod @request
    }
    catch {
        Write-Error ($_.Exception)
        exit 1
    }
}

try {
    $file = Get-Item -Path $APP_PACKAGE_FILE
    $request = @{
        Uri = [System.String]::Format( `
            "https://{0}{1}/_api/web/tenantappcatalog/add(url='{2}',overwrite=true)" +  `
            '?$select=ListItemAllFields/UniqueId' + `
            '&$expand=ListItemAllFields/UniqueId', `
            $TENANT_HOST_NAME, $CATALOG_SITE_URL, $file.Name `
        )
        Method = 'POST'
        Headers = @{
            'Accept' = 'application/json;odata=nometadata'
            'Authorization' = "Bearer " + $token
        }
        InFile = $file.FullName
    }
    $response = Invoke-RestMethod @request
    $uniqueid = $response.ListItemAllFields.UniqueId
}
catch {
    Write-Error ($_.Exception)
    exit 1
}

try {
    $request = @{
        Uri = [System.String]::Format( `
            "https://{0}{1}/_api/web/tenantappcatalog/availableapps/getbyid('{2}')/deploy", `
            $TENANT_HOST_NAME, $CATALOG_SITE_URL, $uniqueid `
        )
        Method = 'POST'
        Headers = @{
            'Accept' = 'application/json;odata=nometadata'
            'Authorization' = "Bearer " + $token
        }
    }
    $response = Invoke-RestMethod @request
}
catch {
    Write-Error ($_.Exception)
    exit 1
}

try {
    $request = @{
        Uri = [System.String]::Format( `
            "https://{0}{1}/_api/web/tenantappcatalog/availableapps/getbyid('{2}')/install", `
            $TENANT_HOST_NAME, $INSTALL_SITE_URL, $uniqueid `
        )
        Method = 'POST'
        Headers = @{
            'Accept' = 'application/json;odata=nometadata'
            'Authorization' = "Bearer " + $token
        }
    }
    $response = Invoke-RestMethod @request
}
catch {
    Write-Error ($_.Exception)
    exit 1
}
