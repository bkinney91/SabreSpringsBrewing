
export interface BatchDetailsDto
{
    beer: string;
    batchNumber: number;
    batchName: string;
    style: string;
    status: string;
    brewers: string;
    tapNumber: number;
    fermentationTank: number;
    yeast: string;
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