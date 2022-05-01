


export class Token
{
    private _userId: number;
    private _role: string;


    constructor(userId:number,role:string)
    {
        this._userId = userId;
        this._role = role;
    }

    public get userId(): number 
    {
        return this._userId;
    }
    public set userId(value: number) 
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