using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http.Filters;

namespace Karamem0.Samples
{

    public sealed partial class AuthPage : Page
    {

        private static readonly string AppId = "00000003-0000-0ff1-ce00-000000000000";

        private static readonly string AuthPath = "/_layouts/15/OAuthAuthorize.aspx";

        private static readonly string ServicePath = "/_vti_bin/client.svc";

        private static readonly string TokenUrl = "https://accounts.accesscontrol.windows.net/{0}/tokens/OAuth/2";

        private static readonly string ClientId = "{{clientid}}";

        private static readonly string ClientSecret = "{{clientsecret}}";

        private static readonly string RedirectUrl = "https://login.microsoftonline.com/common/oauth2/nativeclient";

        private string SiteUrl { get; set; }

        public AuthPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.SiteUrl = ((string)e.Parameter).TrimEnd('/');
            this.WebView.Source = new Uri(
                this.SiteUrl + AuthPath +
                    "?" + "isdlg=0" +
                    "&" + "client_id=" + ClientId +
                    "&" + "scope=Web.Manage" +
                    "&" + "response_type=code" +
                    "&" + "redirect_uri=" + Uri.EscapeUriString(RedirectUrl),
                UriKind.Absolute);
            this.WebView.NavigationStarting += this.OnWebViewNavigationStarting;
        }

        private async void OnWebViewNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs e)
        {
            if (e.Uri.ToString().StartsWith(RedirectUrl) != true)
            {
                return;
            }
            var filter = new HttpBaseProtocolFilter();
            foreach (var cookie in filter.CookieManager.GetCookies(new Uri(this.SiteUrl, UriKind.Absolute)))
            {
                filter.CookieManager.DeleteCookie(cookie);
            }
            var httpClient = new HttpClient();
            var serviceUrl = this.SiteUrl.TrimEnd('/') + ServicePath;
            var realmRequestMessage = new HttpRequestMessage();
            realmRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            realmRequestMessage.Method = HttpMethod.Get;
            realmRequestMessage.RequestUri = new Uri(serviceUrl, UriKind.Absolute);
            var realmResponseMessage = await httpClient.SendAsync(realmRequestMessage);
            var realmHeader = realmResponseMessage.Headers.WwwAuthenticate.First();
            var realmMatch = Regex.Match(realmHeader.Parameter, "realm=\"(.+?)\"");
            var realmValue = realmMatch.Groups[1].Value;
            var code = e.Uri.Query.TrimStart('?').Split('&')
                .Select(x => x.Split('='))
                .Where(x => x[0] == "code")
                .Select(x => x[1])
                .FirstOrDefault();
            var tokenUrl = string.Format(TokenUrl, realmValue);
            var tokenRequestContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "grant_type", "authorization_code" },
                { "client_id", ClientId + "@" + realmValue },
                { "client_secret", ClientSecret },
                { "code", code },
                { "redirect_uri", RedirectUrl },
                { "resource", AppId + "/" +  new Uri(this.SiteUrl).Host + "@" + realmValue },
            });
            var tokenRequestMessage = new HttpRequestMessage();
            tokenRequestMessage.Method = HttpMethod.Post;
            tokenRequestMessage.Content = tokenRequestContent;
            tokenRequestMessage.RequestUri = new Uri(tokenUrl, UriKind.Absolute);
            var tokenResponseMessage = await httpClient.SendAsync(tokenRequestMessage);
            var tokenResponseContent = await tokenResponseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(tokenResponseContent);
            var accessToken = jsonObject["access_token"];
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(PostPage), Tuple.Create(this.SiteUrl, (string)accessToken));
            }
        }

    }

}
