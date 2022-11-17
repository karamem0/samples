#
# Copyright (c) 2011-2026 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/samples/blob/main/LICENSE
#

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$url = "{{site-url}}"

$web = Get-SPWeb $url
for ($i = 0; $i -lt $web.Lists.Count; $i++) {
    $list = $web.Lists[$i]
    $field = $list.Fields["Created"]
    $field = $field -as [Microsoft.SharePoint.SPFieldDateTime]
    if ($field -isnot $null) {
        $field.FriendlyDisplayFormat = [Microsoft.SharePoint.SPDateTimeFieldFriendlyFormatType]::Disabled
        $field.Update()
    }
    $field = $list.Fields["Modified"]
    $field = $field -as [Microsoft.SharePoint.SPFieldDateTime]
    if ($field -isnot $null) {
        $field.FriendlyDisplayFormat = [Microsoft.SharePoint.SPDateTimeFieldFriendlyFormatType]::Disabled
        $field.Update()
    }
}
