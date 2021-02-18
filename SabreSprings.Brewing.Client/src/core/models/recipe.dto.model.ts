export interface RecipeDto
{
   id: number;
   boilTime: number;
   yeast: string;
   pitchTemperature: number;
   fermentationTemperatureLow: number;
   fermentationTemperatureHigh: number;
   strikeWaterVolume: number;
   strikeWaterTemperature: number;
   mashTemperature: number;
   mashInstructions: string;
   daysInPrimaryFermentation: number;
   daysInSecondaryFermentation: number;
   preBoilGravity: number;
   originalGravity: number;
   finalGravity: number;
   abv: number;
   ibu: number;
   srm: number;

}