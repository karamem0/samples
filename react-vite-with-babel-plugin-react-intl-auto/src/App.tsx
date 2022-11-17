//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { FormattedMessage, IntlProvider } from 'react-intl';
import translations from './translations';
import messages from './messages';

function App() {

  const [count, setCount] = useState(0);

  return (
    <div className="app">
      <header className="app-header">
        <img src={logo} className="app-logo" alt="logo" />
        <p>Hello Vite + React!</p>
        <p>
          <button type="button" onClick={() => setCount((count) => count + 1)}>
            count is: {count}
          </button>
        </p>
        <p>
          Edit <code>App.tsx</code> and save to test HMR updates.
        </p>
        <p>
          <a
            className="app-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
          </a>
          {' | '}
          <a
            className="app-link"
            href="https://vitejs.dev/guide/features.html"
            target="_blank"
            rel="noopener noreferrer"
          >
            Vite Docs
          </a>
        </p>
        <p>
          <IntlProvider locale='ja' messages={translations.ja}>
            <FormattedMessage {...messages.HelloWorld} />
          </IntlProvider>
        </p>
      </header>
    </div>
  );

}

export default App;
