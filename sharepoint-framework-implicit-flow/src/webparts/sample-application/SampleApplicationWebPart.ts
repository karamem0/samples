import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';
import {
  HttpClient,
  HttpClientResponse
} from '@microsoft/sp-http';

import styles from './SampleApplicationWebPart.module.scss';
import * as strings from 'SampleApplicationWebPartStrings';

export interface ISampleApplicationWebPartProps {
  appId: string;
  authUrl: string;
  resourceUrl: string;
}

export default class SampleApplicationWebPart extends BaseClientSideWebPart<ISampleApplicationWebPartProps> {

  public render(): void {
    if (window.location.hash == "") {
      var redirectUrl = window.location.href.split("?")[0];
      var authUrl = this.properties.authUrl + "?" +
        "response_type=token" + "&" +
        "client_id=" + encodeURI(this.properties.appId) + "&" +
        "resource=" + encodeURI(this.properties.resourceUrl) + "&" +
        "redirect_uri=" + encodeURI(redirectUrl);
      var popupWindow = window.open(authUrl, this.context.instanceId, "width=800px,height=600px");
      var handle = setInterval((self: any) => {
        if (popupWindow == null || popupWindow.closed == null || popupWindow.closed == true) {
          clearInterval(handle);
        } else {
          try {
            if (popupWindow.location.href.indexOf(redirectUrl) == -1) {
              return;
            }
            var hash = popupWindow.location.hash;
            console.log(hash);
            clearInterval(handle);
            popupWindow.close();
            var query = {};
            var elements = hash.slice(1).split("&");
            for (var index = 0; index < elements.length; index++) {
              var pair = elements[index].split("=");
              var key = decodeURIComponent(pair[0]);
              var value = decodeURIComponent(pair[1]);
              query[key] = value;
            }
            var accessToken = query["access_token"];
            var requestUrl = this.properties.resourceUrl + "/me?api-version=1.6";
            this.context.httpClient.get(requestUrl, HttpClient.configurations.v1, {
              headers: new Headers({
                "Accept": "application/json",
                "Authorization": `Bearer ${accessToken}`
              })
            })
              .then((response: HttpClientResponse) => {
                if (response.ok) {
                  return response.json();
                } else {
                  console.warn(response.statusText);
                }
              })
              .then((data: any) => {
                this.domElement.innerHTML = `
                  <div class="${styles.SampleApplication}">
                    <div class="${styles.container}">
                      <div class="${styles.row}">
                        <div class="${styles.column}">
                          <div>${strings.welcomeMessage.replace(/{displayName}/, data.displayName)}</div>
                        </div>
                      </div>
                    </div>
                  </div>`;
              });
          } catch (e) {
            console.error(e);
          }
        }
      }, 1, this);
    }
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return null;
  }

}
