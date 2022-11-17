//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';
import * as V8 from '@fluentui/react';
import * as V0 from '@fluentui/react-northstar';
import * as V9 from '@fluentui/react-components';
import * as V9Unstable from '@fluentui/react-components/unstable';
import * as MUI from '@material-ui/core';
import './App.css';

V8.initializeIcons();

function App() {

  return (
    <div className="app">
      <V0.Provider theme={V0.teamsTheme}>
        <V9.FluentProvider theme={V9.webLightTheme}>
          <div>
            <header>
              <h1>Fluent UI Components Comparison</h1>
            </header>
            <table className="table">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>@fluentui/react (v8)</th>
                  <th>@fluentui/react-northstar (v0)</th>
                  <th>@fluentui/react-components (v9)</th>
                  <th>@material-ui/core (v4)</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>Button</td>
                  <td>
                    <div>
                      <V8.DefaultButton>Cancel</V8.DefaultButton>
                      <V8.PrimaryButton>OK</V8.PrimaryButton>
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Button>Cancel</V0.Button>
                      <V0.Button primary>OK</V0.Button>
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Button>Cancel</V9.Button>
                      <V9.Button appearance="primary">OK</V9.Button>
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.Button variant="contained">Cancel</MUI.Button>
                      <MUI.Button color="primary" variant="contained">OK</MUI.Button>
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Text Input</td>
                  <td>
                    <div>
                      <V8.TextField placeholder="Title" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Input placeholder="Title" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Input placeholder="Title" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.TextField
                        label="Title"
                        placeholder="Title"
                        variant="outlined" />
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Radio Button</td>
                  <td>
                    <div>
                      <V8.ChoiceGroup options={[{ key: '1', text: 'Windows' }]} />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.RadioGroupItem label="Windows" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Radio label="Windows" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.FormControlLabel
                        control={<MUI.Radio color="primary" />}
                        label="Windows" />
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Checkbox</td>
                  <td>
                    <div>
                      <V8.Checkbox label="Mark as read" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Checkbox label="Mark as read" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Checkbox label="Mark as read" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.FormControlLabel
                        control={<MUI.Checkbox color="primary" />}
                        label="Mark as read" />
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Toggle</td>
                  <td>
                    <div>
                      <V8.Toggle inlineLabel label="Mark as read" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Checkbox toggle label="Mark as read" />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.ToggleButton>Mark as read</V9.ToggleButton>
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.FormControlLabel
                        control={<MUI.Switch color="primary" />}
                        label="Mark as read" />
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Dropdown</td>
                  <td>
                    <div>
                      <V8.Dropdown
                        styles={{ dropdown: { width: '10rem' } }}
                        options={[{ key: '1', text: 'Windows' }]} />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Dropdown items={[{ header: 'Windows' }]} fluid />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9Unstable.Dropdown>
                        <V9Unstable.Option>Windows</V9Unstable.Option>
                      </V9Unstable.Dropdown>
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.FormControl variant="outlined">
                        <MUI.InputLabel id="mui-select">Windows</MUI.InputLabel>
                        <MUI.Select
                          labelId="mui-select"
                          label="Windows"
                          style={{ width: '10rem' }}
                          variant="outlined">
                          <MUI.MenuItem value="Windows">Windows</MUI.MenuItem>
                        </MUI.Select>
                      </MUI.FormControl>
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Link</td>
                  <td>
                    <div>
                      <V8.Link>GitHub</V8.Link>
                    </div>
                  </td>
                  <td>
                    <div>
                      - (N/A)
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Link>GitHub</V9.Link>
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.Link>GitHub</MUI.Link>
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Date Picker</td>
                  <td>
                    <div>
                      <V8.DatePicker style={{ width: '10rem' }} />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Datepicker />
                    </div>
                  </td>
                  <td>
                    <div>
                      - (N/A)
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.TextField type="date" />
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>Loader</td>
                  <td>
                    <div>
                      <V8.Spinner />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V0.Loader />
                    </div>
                  </td>
                  <td>
                    <div>
                      <V9.Spinner />
                    </div>
                  </td>
                  <td>
                    <div>
                      <MUI.CircularProgress />
                    </div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </V9.FluentProvider>
      </V0.Provider>
    </div>
  )
}

export default App;
