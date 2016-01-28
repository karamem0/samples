import * as React from 'react';
import { create } from 'react-test-renderer';
import SampleApplication from './SampleApplication';
import { ISampleApplicationProps } from './ISampleApplicationProps';

// とりあえず必ず PASS するテスト
it('test1', () => {
  expect(true).toBe(true);
});

// スナップショットを作成するテスト
it('test2', () => {
  const props = {} as ISampleApplicationProps;
  const tree = create(<SampleApplication {...props} />).toJSON();
  expect(tree).toMatchSnapshot();
});
