using AutoMapper;
using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsConnector;

public class AutoMapperConfig
{
    public static Mapper InitializeAutoMapper()
    {
        var config = new MapperConfiguration((cfg) =>
        {
            cfg.CreateMap<AddCollateralRequestDto, Collateral>();
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}
