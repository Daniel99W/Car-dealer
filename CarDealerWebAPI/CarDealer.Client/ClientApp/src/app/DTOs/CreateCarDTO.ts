




export class CreateCarDTO
{
    private _title: string;
    public get title(): string 
    {
        return this._title;
    }
    public set title(value: string) 
    {
        this._title = value;
    }
    private _carNumber: string;
    public get CarNumber(): string 
    {
        return this._carNumber;
    }
    public set CarNumber(value: string) 
    {
        this._carNumber = value;
    }
    private _productionYear: number;
    public get productionYear(): number {
        return this._productionYear;
    }
    public set productionYear(value: number) {
        this._productionYear = value;
    }
    
    private _price: number;
    public get price(): number 
    {
        return this._price;
    }
    public set price(value: number)
     {
        this._price = value;
    }
    private _secondHand: boolean;
    public get secondHand(): boolean 
    {
        return this._secondHand;
    }
    public set secondHand(value: boolean) 
    {
        this._secondHand = value;
    }
    private _addingDate: string;
    public get addingDate(): string 
    {
        return this._addingDate;
    }
    public set addingDate(value: string) 
    {
        this._addingDate = value;
    }
    private _userId: string;
    public get userId(): string 
    {
        return this._userId;
    }
    public set userId(value: string)
     {
        this._userId = value;
    }
    private _fuelTypeId?: string;
    public get fuelTypeId(): string |undefined
    {
        return this._fuelTypeId;
    }
    public set fuelTypeId(value: string|undefined) 
    {
        this._fuelTypeId = value;
    }
    private _description: string;
    public get description(): string 
    {
        return this._description;
    }
    public set description(value: string)
     {
        this._description = value;
    }
    private _model: string;
    public get model(): string 
    {
        return this._model;
    }
    public set model(value: string) 
    {
        this._model = value;
    }
    private _cilindricCapacity: number;
    public get cilindricCapacity(): number 
    {
        return this._cilindricCapacity;
    }
    public set cilindricCapacity(value: number)
     {
        this._cilindricCapacity = value;
    }
    private _brandId?: string;
    public get brandId(): string |undefined
    {
        return this._brandId;
    }
    public set brandId(value: string|undefined) 
    {
        this._brandId = value;
    }
    private _carTypeId?: string;
    public get carTypeId(): string |undefined
    {
        return this._carTypeId;
    }
    public set carTypeId(value: string|undefined)
     {
        this._carTypeId = value;
    }

    constructor(title:string,
        carNumber:string,
        productionYear:number,
        price:number,
        secondHand:boolean,
        addingDate:string,
        userId:string,
        description:string,
        model:string,
        cilindricCapacity:number,
        fuelTypeId?:string,
        brandId?:string,
        carTypeId?:string
        )
        {
            this._title = title;
            this._carNumber = carNumber;
            this._productionYear = productionYear;
            this._price = price;
            this._secondHand = secondHand;
            this._addingDate = addingDate;
            this._userId = userId;
            this._fuelTypeId = fuelTypeId;
            this._description = description;
            this._model = model;
            this._cilindricCapacity = cilindricCapacity;
            this._brandId = brandId;
            this._carTypeId = carTypeId;
        }
}