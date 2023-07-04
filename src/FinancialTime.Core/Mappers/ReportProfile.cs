using AutoMapper;
using FinancialTime.Core.DTOs.Report;
using FinancialTime.Core.ViewModels;

namespace FinancialTime.Core.Mappers;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<ReportViewModel, ReportDateDto>()
            .ForMember(dto => dto.Date, 
                expression => expression.MapFrom(src => src.StartDate))
            .ForMember(dto => dto.ResultIncome, 
                expression => expression.MapFrom(src => src.ResultIncome))
            .ForMember(dto => dto.ResultExpense,
                expression => expression.MapFrom(src => src.ResultExpense))
            .ForMember(dto => dto.Operations,
                expression => expression.MapFrom(src => src.Operations));
        
        CreateMap<ReportViewModel, ReportPeriodDto>()
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