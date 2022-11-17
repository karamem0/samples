//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';

import { render, screen } from '@testing-library/react';
import App from './App';

describe('App', () => {

  it('create shapshot', () => {
    render(<App />);
    expect(screen.queryAllByText(/^.*$/)[0]).toMatchSnapshot();
  });

});
