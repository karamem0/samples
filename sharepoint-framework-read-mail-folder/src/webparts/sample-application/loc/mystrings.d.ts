declare interface ISampleApplicationStrings {
  GeneralGroupName: string;
  AppIdFieldLabel: string;
  AuthUrlFieldLabel: string;
  ResourceUrlFieldLabel: string;
}

declare module 'SampleApplicationStrings' {
  const strings: ISampleApplicationStrings;
  export = strings;
}
