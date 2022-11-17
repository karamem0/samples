import * as React from 'react';

import { render } from '@testing-library/react';
import SampleApplication from './SampleApplication';

test("create snapshot", () => {
  const params = {
    description: 'SampleApplication',
    isDarkTheme: false,
    environmentMessage: 'Unknown',
    hasTeamsContext: false,
    userDisplayName: 'Megan Bowen'
  };
  const { asFragment } = render(<SampleApplication {...params} />);
  expect(asFragment()).toMatchSnapshot();
});
