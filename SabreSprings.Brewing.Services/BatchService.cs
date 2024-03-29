﻿using SabreSprings.Brewing.Data.Interfaces;
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
            return this.MapToDto(batch);
        }

        public async Task<List<BatchTableRow>> GetBatchTable()
        {
            List<BatchTableRow> tableRows = new List<BatchTableRow>();
            List<Batch> batches = await BatchDataProvider.GetAllBatches();
            batches = batches.OrderByDescending(x=>x.Status == "On Tap")
                .ThenByDescending(x=> x.Status == "Conditioning")
                .ThenByDescending(x=> x.Status == "Fermenting")
                .ThenByDescending(X => X.Status == "Souring")
                .ThenByDescending(x=> x.Status == "Planned")
                .ThenByDescending(x=> x.Status == "Archived")
                .ThenByDescending(x=> x.DateBrewed).ToList();
            foreach(Batch batch in batches)
            {               
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
                    StatusText = batch.Status,
                    TapNumber = batch.TapNumber,
                    FermentationTank = batch.FermentationTank,
                    Logo = beer.Logo
                };
                tableRows.Add(row);
            }

            return tableRows;
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
                Status = "Planned",
                Brewers = dto.Brewers,
                Yeast = dto.Yeast,
                PreBoilGravity = dto.PreBoilGravity,
                OriginalGravity = dto.OriginalGravity,
                FinalGravity = dto.FinalGravity,
                ABV = dto.ABV,
                PintsRemaining = dto.PintsRemaining,
                DateBrewed = dto.DateBrewed,
                DatePackaged = dto.DatePackaged,
                DateTapped = dto.DateTapped,
                BrewingNotes = dto.BrewingNotes,
                TastingNotes = dto.TastingNotes,
                Created = DateTime.Now                
            };
            await BatchDataProvider.Add(entity);
        }

        public async Task Update(BatchDto dto)
        {
            
            Batch entity = await BatchDataProvider.Get(dto.Id);
            entity.ABV = dto.ABV;
            entity.BatchName = dto.BatchName;
            entity.Status = dto.Status;
            entity.Brewers = dto.Brewers;
            entity.Yeast = dto.Yeast;
            entity.TapNumber = dto.TapNumber;
            entity.FermentationTank = dto.FermentationTank;
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


        private BatchDto MapToDto(Batch batch)
        {
            BatchDto dto = new BatchDto()
            {
                Id = batch.Id,
                Beer = batch.Beer,
                BatchName = batch.BatchName,
                BatchNumber = batch.BatchNumber,
                Status = batch.Status,
                Brewers = batch.Brewers,               
                Yeast = batch.Yeast,
                FermentationTank = batch.FermentationTank,
                TapNumber = batch.TapNumber,
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
    }
}
