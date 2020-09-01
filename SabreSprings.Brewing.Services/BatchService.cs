using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Beer beer = await BeerDataProvider.GetBeer(batch.Beer);
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

        public async Task<BatchDetailsDto> GetBatchDetails(int id)
        {
            Batch batch = await BatchDataProvider.GetBatch(id);
            Beer beer = await BeerDataProvider.GetBeer(batch.Beer);
            BatchDetailsDto batchDetailsDto = new BatchDetailsDto()
            {
                Id = batch.Id,
                Beer = beer.Name,
                Style = beer.Style,
                BatchName = batch.BatchName,
                BatchNumber = batch.BatchNumber,
                Status = batch.Status,
                SubStatus = batch.SubStatus,
                Brewers = batch.Brewers,
                Recipe = batch.Recipe,
                Yeast = batch.Yeast,
                PreBoilGravity = batch.PreBoilGravity,
                OriginalGravity = batch.OriginalGravity,
                FinalGravity = batch.FinalGravity,
                ABV = batch.ABV,
                DateBrewed = batch.DateBrewed,
                DatePackaged = batch.DatePackaged,
                DateTapped = batch.DateTapped,
                BrewingNotes = batch.BrewingNotes,
                TastingNotes = batch.TastingNotes,
                Created = batch.Created,
                CreatedBy = batch.CreatedBy
            };
            return batchDetailsDto;
        }

        public async Task Add(BatchDto dto)
        {
            //Get latest batch number
            int batchNumber = await BatchDataProvider.GetLatestBatchNumber(dto.Beer);
            Batch entity = new Batch()
            {
                Beer = dto.Beer,
                BatchName = dto.BatchName,
                BatchNumber = batchNumber+1,
                Created = DateTime.Now                
            };
            await BatchDataProvider.Add(entity);
        }

        public async Task Update(BatchDto dto)
        {
            Batch entity = new Batch()
            {
                Id = dto.Id,
                Beer = dto.Beer,
                BatchName = dto.BatchName,
                Status = dto.Status,
                SubStatus = dto.SubStatus,
                Brewers = dto.Brewers,
                Yeast = dto.Yeast,
                PreBoilGravity = dto.PreBoilGravity,
                OriginalGravity = dto.OriginalGravity,
                FinalGravity = dto.FinalGravity,
                ABV = dto.ABV,
                DateBrewed = dto.DateBrewed,
                DatePackaged = dto.DatePackaged,
                DateTapped = dto.DateTapped,
                BrewingNotes = dto.BrewingNotes,
                TastingNotes = dto.TastingNotes,
                Created = DateTime.Now                
            };
            await BatchDataProvider.Update(entity);
        }
    }
}
