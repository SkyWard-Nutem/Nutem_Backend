﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_ProductionOrder")]
    public class ProductionOrder : BaseAuditable
    {
        public ProductionOrder()
        {
            //this.LiquidPreparationEntities = new List<LiquidPreparationEntity>();
            //this.PalletPackingEntities = new List<PalletPackingEntity>();
            this.PostCheckListEntity = new List<PostCheckListEntity>();
            this.PreCheckListEntity = new List<PreCheckListEntity>();
            this.WeightCheck = new List<WeightCheck>();
            this.AttributeCheck = new List<AttributeCheck>();
            this.DowntimeTracking=new List<DowntimeTracking>();
            //this.AttributeCheckEntities = new List<AttributeCheckEntity>();
        }
        public string Code { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public decimal? PlannedQty { get; set; } = 0;
        public string? ItemName { get; set; }
        public bool IsActive { get; set; }
        public string? ItemNo { get; set; }
        public string? InventoryUOM { get; set; }
        public long? ProductId { get; set; }
        public string? Status { get; set; }
        //public virtual ICollection<LiquidPreparationEntity> LiquidPreparationEntities { get; set; }
        //public virtual ICollection<PalletPackingEntity> PalletPackingEntities { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostCheckListEntity> PostCheckListEntity { get; set; }
        [JsonIgnore]
        public virtual ICollection<PreCheckListEntity> PreCheckListEntity { get; set; }
        [JsonIgnore]
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        [JsonIgnore]
        public virtual ICollection<AttributeCheck> AttributeCheck { get; set; }
        [JsonIgnore]
        public virtual ICollection<DowntimeTracking> DowntimeTracking { get; set; }
        //public virtual ICollection<AttributeCheckEntity> AttributeCheckEntities { get; set; }
        //public virtual ICollection<DowntimeTrackingEntity> DowntimeTrackingEntities { get; set; }
    }
}
