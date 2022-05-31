


export class CreateUserDTO
{
    private _email!: string;
    public get Email(): string 
    {
        return this._email;
    }
    public set Email(value: string) 
    {
        this._email = value;
    }
    private _password!: string;
    public get Password(): string 
    {
        return this._password;
    }
    public set Password(value: string) 
    {
        this._password = value;
    }
    private _name!: string;
    public get Name(): string 
    {
        return this._name;
    }
    public set Name(value: string) 
    {
        this._name = value;
    }
    private _secondName!: string;
    public get SecondName(): string 
    {
        return this._secondName;
    }
    public set SecondName(value: string) 
    {
        this._secondName = value;
    }
    constructor(
        email:string,
        name:string,
        secondName:string,
        password:string)
    {
        this._email = email;
        this._name = name;
        this._secondName = secondName;
        this._password = password;
    }
}