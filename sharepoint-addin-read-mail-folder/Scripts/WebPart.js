var clientId = "{{clientid}}";
var authUrl = "https://login.microsoftonline.com/{{tenantname}}/oauth2/authorize";
var resource = "https://outlook.office.com";
var redirectUrl = "https://{{devsiteurl}}/SampleApplication/Pages/WebPart.aspx";

(function () {
    $(document).ready(function () {
        if (window.location.hash) {
            var query = {};
            var elements = window.location.hash.slice(1).split("&");
            for (var index = 0; index < elements.length; index++) {
                var hash = elements[index].split("=");
                var key = decodeURIComponent(hash[0]);
                var value = decodeURIComponent(hash[1]);
                query[key] = value;
            }
            $.ajax({
                type: "GET",
                url: resource + "/api/v2.0/me/mailfolders",
                beforeSend: function (req, res) {
                    req.setRequestHeader("Authorization", "Bearer " + query["access_token"]);
                },
                success: function (data, status, req) {
                    console.log(req.status);
                    var items = data.value;
                    for (var index = 0; index < items.length; index++) {
                        var displayName = items[index].DisplayName;
                        var unreadItemCount = items[index].UnreadItemCount;
                        $("#content").append("<div>" + displayName + ": " + unreadItemCount + "</div>");
                    }
                },
                error: function (req, status, error) {
                    console.log(req.status);
                }
            });
        } else {
            var url = authUrl + "?" +
                "response_type=token" + "&" +
                "client_id=" + encodeURI(clientId) + "&" +
                "resource=" + encodeURI(resource) + "&" +
                "redirect_uri=" + encodeURI(redirectUrl);
            window.location.replace(url);
        }
    });
})();
