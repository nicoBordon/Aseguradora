using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Aseguradora.BL.DTOs;
using Aseguradora.BL.Models;

namespace Aseguradora.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Persona, PersonaDTO>();//Get
                cfg.CreateMap<PersonaDTO, Persona>();//Post-Put
                cfg.CreateMap<Genero, GeneroDTO>();
                cfg.CreateMap<GeneroDTO, Genero>();
                cfg.CreateMap<AtributoAdicional, AtributoAdicionalDTO>();
                cfg.CreateMap<AtributoAdicionalDTO, AtributoAdicional>();
                cfg.CreateMap<TipoAtributoAdicional, TipoAtributoAdicionalDTO>();
                cfg.CreateMap<TipoAtributoAdicionalDTO, TipoAtributoAdicional>();
            }); 
        }
    }
}
