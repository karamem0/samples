import { Version } from '@microsoft/sp-core-library';
import {
    BaseClientSideWebPart,
    IPropertyPaneConfiguration,
    PropertyPaneTextField
} from '@microsoft/sp-webpart-base';

import styles from './MyApplication.module.scss';
import * as strings from 'MyApplicationStrings';
import { IMyApplicationWebPartProps } from './IMyApplicationWebPartProps';
import { MyApplicationUserProps } from './MyApplicationUserProps';

export default class MyApplicationWebPart extends BaseClientSideWebPart<IMyApplicationWebPartProps> {

    private userProperties: MyApplicationUserProps;

    public render(): void {
        this.userProperties = new MyApplicationUserProps(this.context.instanceId);
        if (window.location.hash == "") {
            var loginName = this.context.pageContext.user.loginName;
            if (this.userProperties.loginName != loginName) {
                this.userProperties.clear();
                this.userProperties.loginName = loginName;
            }
            if (this.userProperties.accessToken == null) {
                var redirectUrl = window.location.href.split("?")[0];
                var requestUrl = this.properties.authUrl + "?" +
                    "response_type=token" + "&" +
                    "client_id=" + encodeURI(this.properties.appId) + "&" +
                    "resource=" + encodeURI(this.properties.resourceUrl) + "&" +
                    "redirect_uri=" + encodeURI(redirectUrl);
                var popupWindow = window.open(requestUrl, this.context.instanceId, "width=600px,height=400px");
                var handle = setInterval((self) => {
                    if (popupWindow == null || popupWindow.closed == null || popupWindow.closed == true) {
                        clearInterval(handle);
                    }
                    try {
                        if (popupWindow.location.href.indexOf(redirectUrl) != -1) {
                            var hash = popupWindow.location.hash;
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
                            self.userProperties.accessToken = query["access_token"];
                            self.userProperties.expiresIn = query["expires_in"];
                            self._renderBody();
                            self._renderContent();
                        }
                    } catch (e) {
                        console.error(e);
                    }
                }, 1, this);
            } else {
                this._renderBody();
                this._renderContent();
            }
        }
    }

    private _renderBody(): void {
        this.domElement.innerHTML = `
            <div class="${styles.myApplication}">
                <div id="${this.context.manifest.id}" class="${styles.container}">
                </div>
            </div>`;
    }

    private _renderContent(): void {
        var container = this.domElement.querySelector(`#${this.context.manifest.id}`);
        var requestUrl = this.properties.resourceUrl + "/api/v2.0/me/mailfolders";
        fetch(requestUrl, {
            method: "GET",
            headers: new Headers({
                "Accept": "application/json",
                "Authorization": `Bearer ${this.userProperties.accessToken}`
            })
        })
            .then(response => response.json())
            .then(data => {
                var items = data.value;
                for (var index = 0; index < items.length; index++) {
                    var displayName = items[index].DisplayName;
                    var unreadItemCount = items[index].UnreadItemCount;
                    container.innerHTML += `<div>${displayName}: ${unreadItemCount}</div>`;
                }
            });
    }

    protected get dataVersion(): Version {
        return Version.parse('1.0');
    }

    protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
        return {
            pages: [
                {
                    groups: [
                        {
                            groupName: strings.GeneralGroupName,
                            groupFields: [
                                PropertyPaneTextField('appId', {
                                    label: strings.AppIdFieldLabel
                                }),
                                PropertyPaneTextField('authUrl', {
                                    label: strings.AuthUrlFieldLabel
                                }),
                                PropertyPaneTextField('resourceUrl', {
                                    label: strings.ResourceUrlFieldLabel
                                })
                            ]
                        }
                    ]
                }
            ]
        };
    }
}
