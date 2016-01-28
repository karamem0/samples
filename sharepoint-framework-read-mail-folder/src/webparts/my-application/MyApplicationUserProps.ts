export class MyApplicationUserProps {

    private instanceId: string;

    constructor(instanceId: string) {
        this.instanceId = instanceId;
    }

    public get loginName(): string {
        return this._getValue("loginName");
    }

    public set loginName(value: string) {
        this._setValue("loginName", value);
    }

    public get accessToken(): string {
        return this._getValue("accessToken");
    }

    public set accessToken(value: string) {
        this._setValue("accessToken", value);
    }

    public get expiresIn(): string {
        return this._getValue("expiresIn");
    }

    public set expiresIn(value: string) {
        this._setValue("expiresIn", value);
    }

    public clear(): void {
        sessionStorage.removeItem(this.instanceId);
    }

    private _getValue(key: string): string {
        var stringValue = sessionStorage.getItem(this.instanceId);
        if (stringValue == null) {
            return null;
        }
        var jsonValue = JSON.parse(stringValue);
        return jsonValue[key];
    }

    private _setValue(key: string, value: string): void {
        var stringValue = sessionStorage.getItem(this.instanceId);
        if (stringValue == null) {
            stringValue = "{}";
        }
        var jsonValue = JSON.parse(stringValue);
        jsonValue[key] = value;
        stringValue = JSON.stringify(jsonValue);
        sessionStorage.setItem(this.instanceId, stringValue);
    }

}


