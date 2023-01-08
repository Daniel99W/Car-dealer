import { User } from "oidc-client";
import { UserDTO } from "../DTOs/UserDTO";




export class Message 
{
    private _id!: string;
    public get id(): string {
        return this._id;
    }
    public set id(value: string) {
        this._id = value;
    }
    private _content!: string;
    public get content(): string {
        return this._content;
    }
    public set content(value: string) {
        this._content = value;
    }
    private _senderId?: string | undefined;
    public get senderId(): string | undefined {
        return this._senderId;
    }
    public set senderId(value: string | undefined) {
        this._senderId = value;
    }
    private _subject?: string | undefined;
    public get subject(): string | undefined {
        return this._subject;
    }
    public set subject(value: string | undefined) {
        this._subject = value;
    }
    private _created?: Date | undefined;
    public get created(): Date | undefined {
        return this._created;
    }
    public set created(value: Date | undefined) {
        this._created = value;
    }
    private _userDTO?: UserDTO | undefined;
    public get userDTO(): UserDTO | undefined {
        return this._userDTO;
    }
    public set userDTO(value: UserDTO | undefined) {
        this._userDTO = value;
    }
}