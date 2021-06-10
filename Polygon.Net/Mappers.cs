using AutoMapper;
using M5.FinancialDataSanitizer;

namespace Polygon.Net
{
    public class Mappers : Profile
    {
        private AbbreviationParser _parser;
        public Mappers()
        {
          ConfigureMappings();
          _parser = new AbbreviationParser();
        }

        public void ConfigureMappings()
        {
            CreateMap<TickerDetailsInfoV1, TickerDetailsInfoV1>()
                .ForMember(dest => dest.Name,
                    map => map.MapFrom(src => _parser.ExpandAllAbbreviationsFromString(src.Name, true)));
            CreateMap<TickerInfo, TickerInfo>()
                .ForMember(dest => dest.Name,
                    map => map.MapFrom(src => _parser.ExpandAllAbbreviationsFromString(src.Name, true)));
            CreateMap<TickerDetailsInfo, TickerDetailsInfo>()
                .ForMember(dest => dest.Name,
                    map => map.MapFrom(src => _parser.ExpandAllAbbreviationsFromString(src.Name, true)));
        }
    }
}