Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$path = "{{filepath}}"
$name = [System.IO.Path]::GetFileName($path)

$solution = Get-SPSolution -Identity $name -ErrorAction SilentryContinue
if ($solution -isnot $null) {
    if ($solution.Deployed -eq $true) {
        Uninstall-SPSolution -Identity $name -Confirm:$false
    }
    while ($true) {
        try {
            Remove-SPSolution -Identity $name -Confirm:$false -ErrorAction Stop
            break
        } catch {
            Start-Sleep -Seconds 1
        }
    }
}
Add-SPSolution -LiteralPath $path
Install-SPSolution -Identity $name -GACDeployment
