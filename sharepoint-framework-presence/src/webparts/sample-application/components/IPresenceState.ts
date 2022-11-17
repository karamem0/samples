import { IPresence } from "./IPresence";

export interface IPresenceState {
  presences: Array<IPresence>;
  message: string;
}
