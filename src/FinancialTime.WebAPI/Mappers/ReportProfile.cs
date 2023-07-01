using AutoMapper;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.DTOs.Report;

namespace FinancialTime.WebAPI.Mappers;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportDateDto>()
            .ForMember(dto => dto.Date, 
                expression => expression.MapFrom(src => src.StartDate))
            .ForMember(dto => dto.ResultIncome, 
                expression => expression.MapFrom(src => src.ResultIncome))
            .ForMember(dto => dto.ResultExpense,
                expression => expression.MapFrom(src => src.ResultExpense))
            .ForMember(dto => dto.Operations,
                expression => expression.MapFrom(src => src.Operations));
        
        CreateMap<Report, ReportPeriodDto>()
            .ForMember(dto => dto.StartDate, 
                expression => expression.MapFrom(src => src.StartDate))
            .ForMember(dto => dto.EndDate, 
                expression => expression.MapFrom(src => src.EndDate))
            .ForMember(dto => dto.ResultIncome, 
                expression => expression.MapFrom(src => src.ResultIncome))
            .ForMember(dto => dto.ResultExpense,
                expression => expression.MapFrom(src => src.ResultExpense))
            .ForMember(dto => dto.Operations,
                expression => expression.MapFrom(src => src.Operations));
    }
}