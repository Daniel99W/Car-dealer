import { Brand } from "./Brand";
import { CarType } from "./CarType";
import { FuelType } from "./FuelType";



export class User
{
    private _id!: string;
    public get id(): string {
        return this._id;
    }
    public set id(value: string) {
        this._id = value;
    }
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
    private _role!: string;
    public get role(): string {
        return this._role;
    }
    public set role(value: string) {
        this._role = value;
    }
    
}