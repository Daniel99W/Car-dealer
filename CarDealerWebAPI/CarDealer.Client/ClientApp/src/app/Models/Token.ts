


export class Token
{
    private _userId: string;
    private _role: string;


    constructor(userId:string,role:string)
    {
        this._userId = userId;
        this._role = role;
    }

    public get userId():string
    {
        return this._userId;
    }
    public set userId(value: string) 
    {
        this._userId = value;
    }

    public get role(): string 
    {
        return this._role;
    }
    public set role(value: string) 
    {
        this._role = value;
    }


}