import { WebPartContext } from "@microsoft/sp-webpart-base";

export interface IPresenceProps {
  context: WebPartContext;
  groupId: string;
}
