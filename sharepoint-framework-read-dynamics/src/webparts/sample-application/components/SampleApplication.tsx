import * as React from 'react';
import styles from './SampleApplication.module.scss';

import { AadHttpClient, HttpClientResponse } from '@microsoft/sp-http';
import { ISampleApplicationProps } from './ISampleApplicationProps';
import { ISampleApplicationState } from './ISampleApplicationState';
import { IAccount } from '../models/IAccount';

export default class SampleApplication extends React.Component<ISampleApplicationProps, ISampleApplicationState> {

  constructor(props: ISampleApplicationProps) {
    super(props);
    this.state = {
      accounts: []
    };
  }

  public render(): React.ReactElement<ISampleApplicationProps> {
    return (
      <div className={styles.SampleApplication}>
        <table>
          <tr>
            <th>Name</th>
            <th>YomiName</th>
            <th>WebSiteUrl</th>
          </tr>
          {
            this.state.accounts.map((account: IAccount) => {
              return (
                <tr>
                  <td>{account.name}</td>
                  <td>{account.yominame}</td>
                  <td><a href={account.websiteurl}>{account.websiteurl}</a></td>
                </tr>
              );
            })
          }
        </table>
      </div>
    );

  }

  public componentDidMount(): void {
    if (this.props.endpoint == null) {
      return;
    }
    this.props.context.aadHttpClientFactory
      .getClient(this.props.endpoint)
      .then((client: AadHttpClient) => {
        client
          .get(this.props.endpoint + "/api/data/v9.0/accounts", AadHttpClient.configurations.v1)
          .then((response: HttpClientResponse) => response.json())
          .then((response: any) => {
            this.setState({ accounts: response.value as Array<IAccount> });
          });
      });
  }

}
