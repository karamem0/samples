declare interface IMyApplicationWebPartStrings {
  GroupIdFieldLabel: string;
  GroupIdUndefinedLabel: string;
}

declare module 'MyApplicationWebPartStrings' {
  const strings: IMyApplicationWebPartStrings;
  export = strings;
}
