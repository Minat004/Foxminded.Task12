using AutoMapper;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.DTOs.FinType;

namespace FinancialTime.WebAPI.Mappers;

public class FinTypeProfile : Profile
{
    public FinTypeProfile()
    {
        CreateMap<FinType, FinTypeDto>()
            .ForMember(dto => dto.Name, 
                expression => expression.MapFrom(src => src.Name))
            .ForMember(dto => dto.Budget, 
                expression => expression.MapFrom(src => src.Budget))
            .ForMember(dto => dto.ListOperations,
                expression => expression.MapFrom(src => src.ListOperations));

        CreateMap<FinType, FinTypeAddDto>()
            .ForMember(dto => dto.Name, expression =>
                expression.MapFrom(src => src.Name))
            .ForMember(dto => dto.Budget, expression =>
                expression.MapFrom(src => src.Budget));
        
        CreateMap<FinType, FinTypeEditDto>()
            .ForMember(dto => dto.Name, expression =>
                expression.MapFrom(src => src.Name))
            .ForMember(dto => dto.Budget, expression =>
                expression.MapFrom(src => src.Budget));
    }
}