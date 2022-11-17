import { IPersonaProps } from '@pnp/spfx-controls-react/node_modules/office-ui-fabric-react/lib/components/Persona/Persona.types';

export interface IMailFormState {
    to: Array<IPersonaProps>;
    subject: string;
    body: string;
}
