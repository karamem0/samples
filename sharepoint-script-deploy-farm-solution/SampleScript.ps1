#
# Copyright (c) 2011-2026 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/samples/blob/main/LICENSE
#

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$path = "{{file-path}}"
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
