//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';
import './App.css'
import ScrollSynchronizer from './ScrollSynchronizer';

function App() {

  return (
    <div className="container">
      <ScrollSynchronizer>
        {
          ({ ref1, ref2 }) => (
            <React.Fragment>
              <textarea ref={ref1} className="textarea1"></textarea>
              <textarea ref={ref2} className="textarea2"></textarea>
            </React.Fragment>
          )
        }
      </ScrollSynchronizer>
    </div>
  );

}

export default App
