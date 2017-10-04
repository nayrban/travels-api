using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travels.dto.Dto.Request;
using travels.templates.Model;

namespace travels.service.api.Config
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<ProgramInfoRequest, RequestInfoModel>();
            cfg.CreateMap<EmailRequest, CustomizedTripsInfoModel>();
            cfg.CreateMap<ContactRequest, ContactInfoModel>();
            cfg.CreateMap<EnrollRequest, EnrollInfoModel>();
            //          cfg.CreateMap<MinistryCode, MinistryCodeResponse>();


            Mapper.Initialize(cfg);
        }
    }
}