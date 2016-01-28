import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';

import * as strings from 'MyApplicationWebPartStrings';
import Presence from './components/Presence';
import { IPresenceProps } from './components/IPresenceProps';

export interface IMyApplicationWebPartProps {
  groupId: string;
}

export default class MyApplicationWebPart extends BaseClientSideWebPart<IMyApplicationWebPartProps> {

  public render(): void {
    const element: React.ReactElement<IPresenceProps> = React.createElement(
      Presence,
      {
        context: this.context,
        groupId: this.properties.groupId
      }
    );

    ReactDom.render(element, this.domElement);
  }

  protected onDispose(): void {
    ReactDom.unmountComponentAtNode(this.domElement);
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
              groupFields: [
                PropertyPaneTextField('groupId', {
                  label: strings.GroupIdFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }

}
