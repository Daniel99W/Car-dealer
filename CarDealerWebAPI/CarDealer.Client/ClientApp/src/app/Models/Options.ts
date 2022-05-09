



export class Options <T>
{
    private _options: Array<T>;
    public get options(): Array<T> 
    {
        return this._options;
    }
    public set options(value: Array<T>) 
    {
        this._options = value;
    }
    private _selectedOption?:T
    public get selectedOption(): T | undefined
     {
        return this._selectedOption;
    }
    public set selectedOption(value:T|undefined)
     {
        this._selectedOption = value;
    }

    constructor()
    {
        this._options = new Array<T>();
    }
    

    
}