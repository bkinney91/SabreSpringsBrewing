using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Domain;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class TapService : ITapService
    {
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly IBeerDataProvider BeerDataProvider;
        public static readonly object TapLock = new object();
        public TapService(IBatchDataProvider batchDataProvider, IBeerDataProvider beerDataProvider)
        {
            BatchDataProvider = batchDataProvider;
            BeerDataProvider = beerDataProvider;
        }


        public async Task<List<Tap>> GetOnTap()
        {
            List<Tap> tapList = new List<Tap>();
            List<Batch> batchesOnTap = await BatchDataProvider.GetOnTap();
            foreach (Batch batch in batchesOnTap)
            {
                Beer beer = await BeerDataProvider.GetBeer(batch.Beer);
                Tap tapDisplay = new Tap
                {
                    BeerDisplayName = beer.Name,
                    BatchId = batch.Id,
                    BatchNumber = batch.BatchNumber,
                    Style = beer.Style,
                    PintsRemaining = batch.PintsRemaining,
                    ABV = batch.ABV,
                    SuggestedGlassType = beer.SuggestedGlassType,
                    Brewers = batch.Brewers,
                    TastingNotes = batch.TastingNotes,
                    Logo = beer.Logo,
                    TapNumber = batch.TapNumber
                };            
                tapList.Add(tapDisplay);
            }
            tapList = tapList.OrderBy(x=> x.TapNumber).ToList();
            return tapList;
        }

        public async Task ProcessPour(Pour pour)
        {            
            int batchId = await BatchDataProvider.GetBatchOnTap(pour.TapNumber);
            await BatchDataProvider.SubtractPour(batchId, pour.AmountPoured);
        }
    }
}
