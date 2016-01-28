import { WebPartContext } from "@microsoft/sp-webpart-base";

export interface IMyApplicationProps {
  context: WebPartContext;
  endpoint: string;
}
