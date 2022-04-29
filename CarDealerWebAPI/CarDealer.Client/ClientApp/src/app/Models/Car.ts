import { User } from "oidc-client";
import { Brand } from "./Brand";
import { CarType } from "./CarType";
import { FuelType } from "./FuelType";




export  class Car
{
    private _id!: string;
    public get id(): string {
        return this._id;
    }
    public set id(value: string) {
        this._id = value;
    }
    private _title!: string;
    public get title(): string {
        return this._title;
    }
    public set title(value: string) {
        this._title = value;
    }
    private _carNumer!: string;
    public get carNumer(): string {
        return this._carNumer;
    }
    public set carNumer(value: string) {
        this._carNumer = value;
    }
    private _productionYear: number | undefined;
    public get productionYear(): number | undefined {
        return this._productionYear;
    }
    public set productionYear(value: number | undefined) {
        this._productionYear = value;
    }
    private _price!: number;
    public get price(): number {
        return this._price;
    }
    public set price(value: number) {
        this._price = value;
    }
    private _secondHand!: boolean;
    public get secondHand(): boolean {
        return this._secondHand;
    }
    public set secondHand(value: boolean) {
        this._secondHand = value;
    }
    private _addingDate!: Date;
    public get addingDate(): Date {
        return this._addingDate;
    }
    public set addingDate(value: Date) {
        this._addingDate = value;
    }
    private _userId!: number;
    public get userId(): number {
        return this._userId;
    }
    public set userId(value: number) {
        this._userId = value;
    }
    private _description!: string;
    public get description(): string {
        return this._description;
    }
    public set description(value: string) {
        this._description = value;
    }
    private _modelName!: string;
    public get modelName(): string {
        return this._modelName;
    }
    public set modelName(value: string) {
        this._modelName = value;
    }
    private _cilindricCapacity!: number;
    public get cilindricCapacity(): number {
        return this._cilindricCapacity;
    }
    public set cilindricCapacity(value: number) {
        this._cilindricCapacity = value;
    }

    private _carType?: CarType | undefined;
    public get carType(): CarType | undefined {
        return this._carType;
    }
    public set carType(value: CarType | undefined) {
        this._carType = value;
    }
    private _fuelType?: FuelType | undefined;
    public get fuelType(): FuelType | undefined {
        return this._fuelType;
    }
    public set fuelType(value: FuelType | undefined) {
        this._fuelType = value;
    }
    private _brand?: Brand | undefined;
    public get brand(): Brand | undefined {
        return this._brand;
    }
    public set brand(value: Brand | undefined) {
        this._brand = value;
    }
    private _user?: User | undefined;
    public get user(): User | undefined {
        return this._user;
    }
    public set user(value: User | undefined) {
        this._user = value;
    }

}