using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MurderMysteryAI.Api.Contracts.Admin;
using MurderMysteryAI.Api.Contracts.BL;
using MurderMysteryAI.Application.BL;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Api.Mapping
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            // Domain → Admin DTO
            CreateMap<Case, CaseAdminDTO>()
                .ForMember(d => d.Status, cfg => cfg.MapFrom(s => s.Status.ToString()));

            CreateMap<Npc, NpcAdminDto>();
            CreateMap<Evidence, EvidenceAdminDto>();
            CreateMap<CaseFact, CaseFactAdminDto>();

            // Admin Request → Domain
            CreateMap<AddNpcRequest, Npc>()
                .ForMember(d => d.TraitsJson, cfg => cfg.MapFrom(s => s.TraitsJson ?? "{}"))
                .ForMember(d => d.SecretsJson, cfg => cfg.MapFrom(s => s.SecretsJson ?? "{}"));

            CreateMap<AddEvidenceRequest, Evidence>()
                .ForMember(d => d.Source, cfg => cfg.MapFrom(s => s.Source ?? "manual"));

            CreateMap<CaseFactUpsert, CaseFact>()
                .ForMember(d => d.Confidence, cfg => cfg.MapFrom(s => s.Confidence ?? 1.0));
        }
    }
}