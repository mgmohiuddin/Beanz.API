using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beanz.API.Mapper
{

    public static partial class AutoMapperConfig
    {

        public static void MapAdministration(IMapperConfigurationExpression cfg)
        {

            //cfg.CreateMap<Vendor, VendorDTO>();
            //cfg.CreateMap<VendorDTO, Vendor>();

            //cfg.CreateMap<DynamicReportGenerator, DynamicReportGeneratorDTO>()
            //   .ForMember(dest => dest.ReportHeadScripts, act => act.MapFrom(src => src.ReportHeader))
            //   .ForMember(dest => dest.ReportBodyContent, act => act.MapFrom(src => src.ReportBody))
            //   .ForMember(dest => dest.ReportFooterScripts, act => act.MapFrom(src => src.ReportFooter));
            //cfg.CreateMap<DynamicReportGeneratorDTO, DynamicReportGenerator>()
            //    .ForMember(dest => dest.ReportHeader, act => act.MapFrom(src => src.ReportHeadScripts))
            //    .ForMember(dest => dest.ReportBody, act => act.MapFrom(src => src.ReportBodyContent))
            //    .ForMember(dest => dest.ReportFooter, act => act.MapFrom(src => src.ReportFooterScripts));
        }
    }
}
