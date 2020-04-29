
export interface BatchDetailsDto
{
    beer: string;
    batchNumber: number;
    batchName: string;
    style: string;
    status: string;
    subStatus: string;
    brewers: string;
    recipe: string;
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