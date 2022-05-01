



export class LoginDTO
{
    private _email!: string;
    public get Email(): string {
        return this._email;
    }
    public set Email(value: string) {
        this._email = value;
    }
    private _password!: string;
    public get Password(): string {
        return this._password;
    }
    public set Password(value: string) {
        this._password = value;
    }
}