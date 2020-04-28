export interface BatchTableRow
{
    batchId: number;
    statusText: string;
    batchNumber: number;
    batchName: string;
    beerName: string;
    style: string;
    dateBrewed: Date;
    datePackaged: Date;
}