﻿using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Domain;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class TapService : ITapService
    {
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly IBeerDataProvider BeerDataProvider;
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
                Beer beer = await BeerDataProvider.Get(batch.Beer);
                Tap tapDisplay = new Tap
                {
                    BeerDisplayName = beer.Name,
                    BatchNumber = batch.BatchNumber,
                    Style = beer.Style,
                    PintsRemaining = batch.PintsRemaining,
                    ABV = String.Format("{0:0%}", batch.ABV/100),
                    SuggestedGlassType = beer.SuggestedGlassType,
                    Brewers = batch.Brewers
                };
                int tapNumber = 0;
                bool properFormat = Int32.TryParse(batch.SubStatus, out tapNumber);
                if(properFormat == false)
                {
                    throw new FormatException("SubStatus for this beer could not be parsed to determine a tap number," +
                        $" please configure sub status for batch ID \"{batch.Id}\" properly.");
                }
                tapDisplay.TapNumber = tapNumber;                
                tapList.Add(tapDisplay);
            }
            return tapList;
        }

        public async Task ProcessPour(int tapNumber, decimal amountPoured)
        {

        }
    }
}
