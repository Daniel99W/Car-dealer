



export class PaginatedResultDTO<T>
{
    private _prevPage?: number | undefined;
    public get prevPage(): number | undefined {
        return this._prevPage;
    }
    public set prevPage(value: number | undefined) {
        this._prevPage = value;
    }
    private _nextPage?: number | undefined;
    public get nextPage(): number | undefined {
        return this._nextPage;
    }
    public set nextPage(value: number | undefined) {
        this._nextPage = value;
    }
    private _totalPages!: number;
    public get totalPages(): number {
        return this._totalPages;
    }
    public set totalPages(value: number) {
        this._totalPages = value;
    }
    private _currentPage!: number;
    public get currentPage(): number {
        return this._currentPage;
    }
    public set currentPage(value: number) {
        this._currentPage = value;
    }
    private _results!: Array<T>;
    public get results(): Array<T> {
        return this._results;
    }
    public set results(value: Array<T>) {
        this._results = value;
    }
}