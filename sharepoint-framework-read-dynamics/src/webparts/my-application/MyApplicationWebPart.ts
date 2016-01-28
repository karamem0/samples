import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-property-pane';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import * as strings from 'MyApplicationWebPartStrings';
import MyApplication from './components/MyApplication';
import { IMyApplicationProps } from './components/IMyApplicationProps';

export interface IMyApplicationWebPartProps {
  endpoint: string;
}

export default class MyApplicationWebPart extends BaseClientSideWebPart<IMyApplicationWebPartProps> {

  public render(): void {
    const element: React.ReactElement<IMyApplicationProps> = React.createElement(
      MyApplication,
      {
        context: this.context,
        endpoint: this.properties.endpoint
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
                PropertyPaneTextField('endpoint', {
                  label: strings.EndpointFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
