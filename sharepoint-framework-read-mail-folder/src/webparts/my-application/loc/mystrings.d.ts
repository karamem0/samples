declare interface IMyApplicationStrings {
    GeneralGroupName: string;
    AppIdFieldLabel: string;
    AuthUrlFieldLabel: string;
    ResourceUrlFieldLabel: string;
}

declare module 'MyApplicationStrings' {
    const strings: IMyApplicationStrings;
    export = strings;
}
