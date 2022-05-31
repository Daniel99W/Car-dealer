



export class CarParametersQueryDTO
{
    private _page!: number;
    public get page(): number {
        return this._page;
    }
    public set page(value: number) {
        this._page = value;
    }
    private _brand?: string | undefined;
    public get brand(): string | undefined {
        return this._brand;
    }
    public set brand(value: string | undefined) {
        this._brand = value;
    }
    private _carType?: string | undefined;
    public get carType(): string | undefined {
        return this._carType;
    }
    public set carType(value: string | undefined) {
        this._carType = value;
    }
    private _title?: string | undefined;
    public get title(): string | undefined {
        return this._title;
    }
    public set title(value: string | undefined) {
        this._title = value;
    }
    private _minProductionYear?: string | undefined;
    public get minProductionYear(): string | undefined {
        return this._minProductionYear;
    }
    public set minProductionYear(value: string | undefined) {
        this._minProductionYear = value;
    }
    private _maxProductionYear?: string | undefined;
    public get maxProductionYear(): string | undefined {
        return this._maxProductionYear;
    }
    public set maxProductionYear(value: string | undefined) {
        this._maxProductionYear = value;
    }

    private _minPrice?: string | undefined;
    public get minPrice(): string | undefined {
        return this._minPrice;
    }
    public set minPrice(value: string | undefined) {
        this._minPrice = value;
    }
    private _maxPrice?: string | undefined;
    public get maxPrice(): string | undefined {
        return this._maxPrice;
    }
    public set maxPrice(value: string | undefined) {
        this._maxPrice = value;
    }
    private _orderBy?: boolean | undefined;
    public get orderBy(): boolean | undefined {
        return this._orderBy;
    }
    public set orderBy(value: boolean | undefined) {
        this._orderBy = value;
    }
    private _carsPerPage!: number;
    public get carsPerPage(): number {
        return this._carsPerPage;
    }
    public set carsPerPage(value: number) {
        this._carsPerPage = value;
    }

    private _userId?: string|undefined
    public get userId():string|undefined 
    {
        return this._userId;
    }
    public set userId(value:string|undefined) 
    {
        this._userId = value;
    }


    constructor()
    {
        this._page = 1;
        this._carsPerPage = 5;
    }

}