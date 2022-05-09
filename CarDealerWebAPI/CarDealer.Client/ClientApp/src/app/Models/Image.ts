



export class Image
{
    private _id!: string;
    public get Id(): string 
    {
        return this._id;
    }
    public set Id(value: string) 
    {
        this._id = value;
    }
    private _imageName!: string;
    public get imageName(): string
    {
        return this._imageName;
    }
    public set imageName(value: string) 
    {
        this._imageName = value;
    }
    private _carId!: number;
    public get carId(): number 
    {
        return this._carId;
    }
    public set carId(value: number) 
    {
        this._carId = value;
    }
}