﻿using AutoMapper;
using Cph.FinancialDataSanitizer;

namespace Polygon.Net
{
    public class Mappers : Profile
    {
        private readonly AbbreviationParser _parser;

        public Mappers()
        {
            ConfigureMappings();
            _parser = new AbbreviationParser();
        }

        public void ConfigureMappings()
        {
            CreateMap<TickerInfo, TickerInfo>()
                .ForMember(dest => dest.Name,
                    map => map.MapFrom(src => _parser.ExpandAllAbbreviationsFromString(src.Name, true)));

            CreateMap<TickerDetailsInfo, TickerDetailsInfo>()
                .ForMember(dest => dest.Name,
                    map => map.MapFrom(src => _parser.ExpandAllAbbreviationsFromString(src.Name, true)));
        }
    }
}
