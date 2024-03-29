
export interface BatchDto
{
    id :number;
    beer : number;
    batchNumber: number;
    batchName: string;
    style: string;
    status: string;
    brewers: string;
    yeast: string;
    tapNumber: number;
    fermentationTank: number;
    preboilGravity: string;
    originalGravity: string;
    finalGravity: string;
    abv: number;
    pintsRemaining: number;
    dateBrewed: Date;
    datePackaged: Date;
    dateTapped: Date;
    brewingNotes: string;
    tastingNotes: string;
    created: Date;
    createdBy: string;
}