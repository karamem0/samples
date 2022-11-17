//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

var clientId = "{{client-id}}";
var authUrl = "https://login.microsoftonline.com/{{tenant-name}}/oauth2/authorize";
var resource = "https://{{tenant-name}}.crm.dynamics.com";
var redirectUrl = "https://{{dev-site-url}}/SampleApplication/Pages/WebPart.aspx";

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
        url: resource + "/api/data/v8.0/accounts",
        beforeSend: function (req, res) {
          req.setRequestHeader("Authorization", "Bearer " + query["access_token"]);
        },
        success: function (data, status, req) {
          console.log(req.status);
          var items = data.value;
          for (var index = 0; index < items.length; index++) {
            $("#content").append("<div>" + items[index].name + "</div>");
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
