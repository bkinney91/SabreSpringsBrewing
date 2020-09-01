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


        public async Task<BatchDto> GetBatch(int id)
        {
            Batch batch = await BatchDataProvider.GetBatch(id);
            BatchDto dto = new BatchDto()
            {
                Id = batch.Id,
                Beer = batch.Beer,
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
            return dto;
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
            
            Batch entity = await BatchDataProvider.Get(dto.Id);
            entity.BatchName = dto.BatchName;
            entity.Status = dto.Status;
            entity.SubStatus = dto.SubStatus;
            entity.Brewers = dto.Brewers;
            entity.Yeast = dto.Yeast;
            entity.PreBoilGravity = dto.PreBoilGravity;
            entity.OriginalGravity = dto.OriginalGravity;
            entity.FinalGravity = dto.FinalGravity;
            entity.ABV = dto.ABV;
            entity.DateBrewed = dto.DateBrewed;
            entity.DatePackaged = dto.DatePackaged;
            entity.DateTapped = dto.DateTapped;
            entity.BrewingNotes = dto.BrewingNotes;
            entity.TastingNotes = dto.TastingNotes;
            entity.Created = DateTime.Now;            
            await BatchDataProvider.Update(entity);
        }
    }
}
