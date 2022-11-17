import * as React from 'react';

import { MSGraphClient } from '@microsoft/sp-http';

import { IMailFormProps } from './IMailFormProps';
import { IMailFormState } from './IMailFormState';

import styles from './MailForm.module.scss';
import * as strings from 'SampleApplicationWebPartStrings';
import { PeoplePicker, PrincipalType } from '@pnp/spfx-controls-react/lib/PeoplePicker';
import { TextField } from 'office-ui-fabric-react/lib/TextField';
import { PrimaryButton } from 'office-ui-fabric-react/lib/Button';

export default class SampleApplication extends React.Component<IMailFormProps, IMailFormState> {

  constructor(props) {
    super(props);
    this.state = {
      to: [],
      subject: "",
      body: ""
    };
  }

  public render(): React.ReactElement<IMailFormProps> {
    return (
      <div className={styles.mailform}>
        <div className={styles.container}>
          <PeoplePicker
            context={this.props.context}
            titleText="宛先"
            personSelectionLimit={99}
            principalTypes={[PrincipalType.User]}
            selectedItems={value => this.setState({ to: value })} />
          <TextField
            label="件名"
            value={this.state.subject}
            onChanged={value => this.setState({ subject: value })} />
          <TextField
            label="本文"
            multiline
            rows={10}
            onChanged={value => this.setState({ body: value })} />
          <div className={styles.buttons}>
          <PrimaryButton
              text="送信"
              onClick={this._onSendButtonClick.bind(this)} />
          </div>
        </div>
      </div>
    );
  }

  private _onSendButtonClick(): void {
    this.props.context.msGraphClientFactory
      .getClient()
      .then((client: MSGraphClient) => {
        client.api('/me/sendMail').post(
          {
            message: {
              toRecipients: this.state.to.map(value => { return { emailAddress: { address: value.secondaryText } }; }),
              subject: this.state.subject,
              body: {
                content: this.state.body,
                contentType: 'text'
              }
            }
          },
          (error: any, response: any, rawResponse: any) => {
            if (error) {
              window.alert("メールを送信できませんでした。");
            } else {
              window.alert("メールを送信しました。");
            }
          });
      });
  }

}
