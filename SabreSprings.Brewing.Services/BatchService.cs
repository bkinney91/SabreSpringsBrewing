using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            batches = batches.OrderByDescending(x=>x.Status == "On Tap")
                .ThenBy(x=> x.SubStatus)
                .ThenByDescending(x=> x.Status == "Conditioning")
                .ThenByDescending(x=> x.Status == "Fermenting")
                .ThenByDescending(x=> x.Status == "Planned")
                .ThenByDescending(x=> x.Status == "Archived")
                .ThenByDescending(x=> x.DateBrewed).ToList();
            foreach(Batch batch in batches)
            {
                string statusText = batch.Status;
                if (string.IsNullOrEmpty(batch.SubStatus) == false)
                {
                    statusText += ": " + batch.SubStatus;
                }
                Beer beer = await BeerDataProvider.Get(batch.Beer);
                BatchTableRow row = new BatchTableRow()
                {
                    BatchId = batch.Id,
                    BatchName = batch.BatchName,
                    BatchNumber = batch.BatchNumber,
                    BeerName = beer.Name,
                    Style = beer.Style,
                    DateBrewed = batch.DateBrewed,
                    DatePackaged = batch.DatePackaged,
                    StatusText = statusText
                };
                tableRows.Add(row);
            }

            return tableRows;
        }
    }
}
