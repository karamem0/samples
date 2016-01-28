import * as typescript2 from 'typescript-application-2';
import * as typescript4 from 'typescript-application-4';

it('jest.spyOn() with typescript 2', () => {
  jest.spyOn(typescript2, 'HelloWorld');
});

it('jest.spyOn() with typescript 4', () => {
  jest.spyOn(typescript4, 'HelloWorld');
});
