




export class UserDTO
{
    private _name!: string;
    public get name(): string {
        return this._name;
    }
    public set name(value: string) {
        this._name = value;
    }
    private _secondName!: string;
    public get secondName(): string {
        return this._secondName;
    }
    public set secondName(value: string) {
        this._secondName = value;
    }

    private _email!: string;
    public get email(): string {
        return this._email;
    }
    public set email(value: string) {
        this._email = value;
    }


    constructor()
    {

    }
}