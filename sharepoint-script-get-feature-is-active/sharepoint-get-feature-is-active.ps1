Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$url = "{{siteurl}}"
$locale = 1041
$version = 15

$features = Get-SPFeature -Web $url -Limit All | Where-Object { $_.Hidden -eq $false }

Get-SPFeature -Limit All |
    Where-Object { $_.Scope -eq "Web" } |
    Where-Object { $_.CompatibilityLevel -eq $version } |
    Where-Object { $_.Hidden -eq $false } |
    ForEach-Object { [PSCustomObject]@{
        Id = $_.Id
        Title = $_.GetTitle($locale)
        IsActive = ($features | ForEach-Object { $_.Id }) -contains $_.Id
    }} |
    Sort-Object Title
