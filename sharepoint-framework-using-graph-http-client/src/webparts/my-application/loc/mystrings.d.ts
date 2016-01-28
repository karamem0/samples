declare interface IMyApplicationWebPartStrings {
    welcomeMessage: string;
}

declare module 'MyApplicationWebPartStrings' {
    const strings: IMyApplicationWebPartStrings;
    export = strings;
}
