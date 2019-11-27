using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Services
{
    public class BatchService
    {
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly IBeerDataProvider BeerDataProvider;
        public BatchService(IBatchDataProvider batchDataProvider, IBeerDataProvider beerDataProvider)
        {
            BatchDataProvider = batchDataProvider;
            BeerDataProvider = beerDataProvider;
        }

        public List<BatchTableRow> GetBatchTable()
        {
            List<BatchTableRow> tableRows = new List<BatchTableRow>();
            List<Batch> batches = BatchDataProvider.GetAllBatches();
            foreach(Batch batch in batches)
            {
                Beer beer = BeerDataProvider.Get(batch.Beer);
                BatchTableRow row = new BatchTableRow()
                {
                    BatchId = batch.Id,
                    BatchName = batch.BatchName,
                    BatchNumber = batch.BatchNumber,
                    BeerName = beer.Name,

                };
            }            
        }
    }
}
