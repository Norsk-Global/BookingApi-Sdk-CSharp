using System;
using System.Collections.Generic;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IBookShipmentRequest
    {
        List<IPiece> Pieces { get; set; }
        DateTime ReadyByDate { get; set; }
        string Hawb { get; set; }
        string Description { get; set; }
        decimal Value { get; set; }
        string Currency { get; set; }
        bool NonDox { get; set; }
        bool Ddp { get; set; }
        bool Pallet { get; set; }
        string Invoice { get; set; }
        IRequester Requester { get; set; }
        IAddress Consignee { get; set; }
        ICollectionAddress CollectionAddress { get; set; }
        IShipperAddress Shipper { get; set; }
        IService Service { get; set; }
        IPicking Picking { get; set; }
        LabelFormat LabelFormat { get; set; }
        ISiteDetails Site { get; set; }
        IExportCustoms ExportCustoms { get; set; }
    }
}
