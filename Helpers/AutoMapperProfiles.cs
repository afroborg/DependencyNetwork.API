using AutoMapper;
using DpcNtwk.API.Models;
using DpcNtwk.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ColumnForCreateDto, Column>();
            CreateMap<CardForCreateDto, Card>();
        }
    }
}
