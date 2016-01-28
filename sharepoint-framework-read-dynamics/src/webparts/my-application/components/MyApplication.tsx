import * as React from 'react';
import styles from './MyApplication.module.scss';

import { AadHttpClient, HttpClientResponse } from '@microsoft/sp-http';
import { IMyApplicationProps } from './IMyApplicationProps';
import { IMyApplicationState } from './IMyApplicationState';
import { IAccount } from '../models/IAccount';

export default class MyApplication extends React.Component<IMyApplicationProps, IMyApplicationState> {

  constructor(props: IMyApplicationProps) {
    super(props);
    this.state = {
      accounts: []
    };
  }

  public render(): React.ReactElement<IMyApplicationProps> {
    return (
      <div className={styles.myapplication}>
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
