//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';
import { ComponentStory, ComponentMeta } from '@storybook/react';

import App from './App';

export default {
  title: 'App',
  component: App,
} as ComponentMeta<typeof App>;

const Template: ComponentStory<typeof App> = (args) => <App />;

export const Primary = Template.bind({});
Primary.args = {};
