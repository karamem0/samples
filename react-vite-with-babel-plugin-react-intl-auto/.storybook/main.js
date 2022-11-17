//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

module.exports = {
  stories: [
    '../src/**/*.stories.mdx',
    '../src/**/*.stories.@(js|jsx|ts|tsx)'
  ],
  addons: [
    '@storybook/addon-links',
    '@storybook/addon-essentials',
    '@storybook/addon-interactions'
  ],
  framework: '@storybook/react',
  core: {
    builder: '@storybook/builder-vite'
  },
  features: {
    storyStoreV7: true
  },
  viteFinal: (config) => {
    const react = require('@vitejs/plugin-react');
    config.plugins = [
      ...config.plugins.filter((plugin) => {
        return !(
          Array.isArray(plugin) && plugin[0].name === 'vite:react-babel'
        );
      }),
      react({
        exclude: [/\.stories\.(t|j)sx?$/, /node_modules/],
        babel: {
          plugins: [
            'react-intl-auto'
          ]
        },
      }),
    ];
    return config;
  }
}
