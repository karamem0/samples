using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Karamem0.Samples
{

    public sealed partial class PostPage : Page
    {

        private string SiteUrl { get; set; }

        private string AccessToken { get; set; }

        public PostPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var tuple = (Tuple<string, string>)e.Parameter;
            this.SiteUrl = tuple.Item1;
            this.AccessToken = tuple.Item2;
        }

        private async void OnCheckInTextBoxClick(object sender, RoutedEventArgs e)
        {
            var jsonContent = new JObject(
                new JProperty("__metadata", new JObject(new JProperty("type", "SP.ListItem"))),
                new JProperty("Title", "出勤"),
                new JProperty("Timestamp", DateTime.UtcNow)
            );
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
            var requestContent = JsonConvert.SerializeObject(jsonContent);
            var requestUri = new Uri(this.SiteUrl +
                "/_api/web/lists/getbytitle('" + Uri.EscapeUriString("タイム レコーダー") + "')/items",
                UriKind.Absolute);
            var requestMessage = new HttpRequestMessage();
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = requestUri;
            var responseMessage = await httpClient.SendAsync(requestMessage);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            var messageDialog = new MessageDialog(responseContent, responseMessage.ReasonPhrase);
            await messageDialog.ShowAsync();
        }

        private async void OnCheckOutTextBoxClick(object sender, RoutedEventArgs e)
        {
            var jsonContent = new JObject(
                new JProperty("__metadata", new JObject(new JProperty("type", "SP.ListItem"))),
                new JProperty("Title", "退勤"),
                new JProperty("Timestamp", DateTime.UtcNow)
            );
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
            var requestContent = JsonConvert.SerializeObject(jsonContent);
            var requestUri = new Uri(this.SiteUrl +
                "/_api/web/lists/getbytitle('" + Uri.EscapeUriString("タイム レコーダー") + "')/items",
                UriKind.Absolute);
            var requestMessage = new HttpRequestMessage();
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = requestUri;
            var responseMessage = await httpClient.SendAsync(requestMessage);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            var messageDialog = new MessageDialog(responseContent, responseMessage.ReasonPhrase);
            await messageDialog.ShowAsync();
        }

    }

}
