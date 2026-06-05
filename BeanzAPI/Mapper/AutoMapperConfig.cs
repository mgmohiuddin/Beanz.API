using AutoMapper; 

namespace Beanz.API.Mapper
{
    public static partial class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config =
                        new MapperConfiguration(cfg =>
                        {
                            MapAdministration(cfg);
                            MapHospitalInformationSystem(cfg);
                            MapHumanResourceManagementSystem(cfg);
                            MapSupplyChainManagmentMapper(cfg);
                            MapFinancialAccountingSystem(cfg);
                            MapSystemConfig(cfg);
                            
                        });
            return config;
        } 
    }
}