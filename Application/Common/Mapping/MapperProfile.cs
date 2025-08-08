using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using Application.Common.DTOs.Response.Resource;
using Application.Common.DTOs.Response.Unit;
using Domain.Entities;

namespace Application.Common.Mapping;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        CreateMap<ReceiptDocument, ReceiptDocumentResponse>();
        CreateMap<ReceiptResource, ReceiptResourceResponse>();
        CreateMap<Resource, ResourceResponse>();
        CreateMap<UnitOfMeasurement, UnitResponse>();
    }
}