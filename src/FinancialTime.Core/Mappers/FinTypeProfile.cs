﻿using AutoMapper;
using FinancialTime.Core.DTOs.FinType;
using FinancialTime.Core.Models;

namespace FinancialTime.Core.Mappers;

public class FinTypeProfile : Profile
{
    public FinTypeProfile()
    {
        CreateMap<FinType, FinTypeDto>()
            .ForMember(dto => dto.Id, 
                expression => expression.MapFrom(src => src.Id))
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
                expression.MapFrom(src => src.Budget))
            .ReverseMap();
        
        CreateMap<FinType, FinTypeEditDto>()
            .ForMember(dto => dto.Name, 
                expression => expression.MapFrom(src => src.Name))
            .ForMember(dto => dto.Budget, 
                expression => expression.MapFrom(src => src.Budget))
            .ReverseMap();
    }
}