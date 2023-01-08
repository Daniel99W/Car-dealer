



export class MessageDTO
{
    private _senderId!: string;
    public get senderId(): string {
        return this._senderId;
    }
    public set senderId(value: string) {
        this._senderId = value;
    }
    private _subject!: string;
    public get subject(): string {
        return this._subject;
    }
    public set subject(value: string) {
        this._subject = value;
    }
    private _content!: string;
    public get content(): string {
        return this._content;
    }
    public set content(value: string) {
        this._content = value;
    }
    private _receiverId!: string;
    public get receiverId(): string {
        return this._receiverId;
    }
    public set receiverId(value: string) {
        this._receiverId = value;
    }
}