import * as React from 'react';
import { MSGraphClient } from '@microsoft/sp-http';

import { IPresenceProps } from './IPresenceProps';
import { IPresenceState } from './IPresenceState';
import { IPresence } from './IPresence';

import styles from './Presence.module.scss';
import * as strings from 'MyApplicationWebPartStrings';

const iconAvailable: string = require('../assets/presence_available.png');
const iconAway: string = require('../assets/presence_away.png');
const iconBusy: string = require('../assets/presence_busy.png');
const iconDnd: string = require('../assets/presence_dnd.png');
const iconOffline: string = require('../assets/presence_offline.png');
const iconUnknown: string = require('../assets/presence_unknown.png');

export default class Presence extends React.Component<IPresenceProps, IPresenceState> {

  constructor(props) {
    super(props);
    this.state = {
      presences: [],
      message: null
    };
  }

  private _handle: number;

  public componentDidMount(): void {
    this._handle = setInterval(() => {
      this.setState({ message: null });
      if (this.props.groupId) {
        this.props.context.msGraphClientFactory
          .getClient()
          .then((client: MSGraphClient) => {
            client
              .api('https://graph.microsoft.com/beta/groups/' + this.props.groupId + '/members')
              .get((error1, response1: any, rawResponse1?: any) => {
                if (error1) {
                  this.setState({ message: error1.message });
                }
                const presences: IPresence[] = response1.value.map((value: any) => {
                  return {
                    id: value.id,
                    name: value.displayName,
                    status: 'Unknown',
                    icon: iconUnknown
                  };
                });
                const payload: string = JSON.stringify({
                  ids: presences.map((value: IPresence) => { return value.id; })
                });
                client
                  .api('https://graph.microsoft.com/beta/communications/getPresencesByUserId')
                  .post(payload, (error2, response2: any, rawResponse2?: any) => {
                    if (error2) {
                      this.setState({ message: error2.message });
                    }
                    response2.value.forEach((value: any) => {
                      presences.forEach((presence: IPresence) => {
                        if (presence.id === value.id) {
                          presence.status = value.activity;
                          switch (presence.status) {
                            case 'Available':
                              presence.icon = iconAvailable;
                              break;
                            case 'Away':
                            case 'BeRightBack':
                              presence.icon = iconAway;
                              break;
                            case 'Busy':
                              presence.icon = iconBusy;
                              break;
                            case 'DoNotDisturb':
                              presence.icon = iconDnd;
                              break;
                            case 'Offline':
                              presence.icon = iconOffline;
                              break;
                            default:
                              presence.icon = iconUnknown;
                              break;
                          }
                        }
                      });
                    });
                    this.setState({ presences: presences });
                  });
              });
          });
      } else {
        this.setState({ message: strings.GroupIdUndefinedLabel });
      }
    }, 1000);
  }

  public componentWillUnmount(): void {
    clearInterval(this._handle);
  }

  public render(): React.ReactElement<IPresenceProps> {
    if (this.state.message) {
      return (
        <div className={styles.presence}>
          <div className={styles.container}>
            <div>{this.state.message}</div>
          </div>
        </div>
      );
    } else {
      return (
        <div className={styles.presence}>
          <div className={styles.container}>
            {
              this.state.presences.map((presence: IPresence) => {
                return (
                  <div>
                    <img src={presence.icon} />
                    <span className={styles.name}>{presence.name}</span>
                  </div>
                );
              })
            }
          </div>
        </div>
      );
    }
  }

}
