using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class BatchService : IBatchService
    {
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly IBeerDataProvider BeerDataProvider;
        public BatchService(IBatchDataProvider batchDataProvider, IBeerDataProvider beerDataProvider)
        {
            BatchDataProvider = batchDataProvider;
            BeerDataProvider = beerDataProvider;
        }

        public async Task<List<BatchTableRow>> GetBatchTable()
        {
            List<BatchTableRow> tableRows = new List<BatchTableRow>();
            List<Batch> batches = await BatchDataProvider.GetAllBatches();
            foreach(Batch batch in batches)
            {
                Beer beer = await BeerDataProvider.Get(batch.Beer);
                BatchTableRow row = new BatchTableRow()
                {
                    BatchId = batch.Id,
                    BatchName = batch.BatchName,
                    BatchNumber = batch.BatchNumber,
                    BeerName = beer.Name,

                };
            }
            return tableRows;
        }
    }
}
