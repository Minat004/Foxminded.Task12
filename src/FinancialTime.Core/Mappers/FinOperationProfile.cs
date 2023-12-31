﻿using AutoMapper;
using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.Models;

namespace FinancialTime.Core.Mappers;

public class FinOperationProfile : Profile
{
    public FinOperationProfile()
    {
        CreateMap<FinOperation, FinOperationDto>()
            .ForMember(dto => dto.Id,
                expression => expression.MapFrom(src => src.Id))
            .ForMember(dto => dto.Value,
                expression => expression.MapFrom(src => src.Value))
            .ForMember(dto => dto.Date,
                expression => expression.MapFrom(src => src.Date))
            .ForMember(dto => dto.FinTypeId,
                expression => expression.MapFrom(src => src.FinTypeId))
            .ForMember(dto => dto.FinTypeName,
                expression => expression.MapFrom(src => src.FinType.Name))
            .ForMember(dto => dto.FinTypeBudget,
                expression => expression.MapFrom(src => src.FinType.Budget));

        CreateMap<FinOperation, FinOperationAddDto>()
            .ForMember(dto => dto.Value,
                expression => expression.MapFrom(src => src.Value))
            .ForMember(dto => dto.Date,
                expression => expression.MapFrom(src => src.Date))
            .ForMember(dto => dto.FinTypeId,
                expression => expression.MapFrom(src => src.FinTypeId))
            .ReverseMap();

        CreateMap<FinOperation, FinOperationEditDto>()
            .ForMember(dto => dto.Value,
                expression => expression.MapFrom(src => src.Value))
            .ForMember(dto => dto.Date,
                expression => expression.MapFrom(src => src.Date))
            .ForMember(dto => dto.FinTypeId,
                expression => expression.MapFrom(src => src.FinTypeId))
            .ReverseMap();
    }
}