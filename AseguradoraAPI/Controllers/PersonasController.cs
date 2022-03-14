using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Aseguradora.BL.Data;
using Aseguradora.BL.DTOs;
using Aseguradora.BL.Models;
using Aseguradora.BL.Repositories.Implements;
using Aseguradora.BL.Services.Implements;
using AseguradoraAPI;
using AutoMapper;

namespace Aseguradora.API.Controllers
{
    
    public class PersonasController : ApiController
    {
        private readonly PersonaService personaService = new PersonaService(new PersonaRepository(AseguradoraContext.Create()));
        private IMapper mapper;
        /// <summary>
        /// Inicializamos el objeto mapedor de clases
        /// </summary>
        public PersonasController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtiene las Personas registradas.
        /// </summary>
        /// <returns>Listado de objetos Persona</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        
        [ResponseType(typeof(IEnumerable<PersonaDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var personas = await personaService.GetAll();
                if (personas == null)
                    return NotFound();
                var personasDto = personas.Select(x => mapper.Map<PersonaDTO>(x));
                return Ok(personasDto);
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }

        }
        /// <summary>
        /// Obtiene una Persona por su ID.
        /// </summary>
        /// <param name="id">ID del objeto</param>
        /// <returns>Objeto Persona</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        [ResponseType(typeof(PersonaDTO))]

        public async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                var persona = await personaService.GetById(id);

                if (persona == null)
                    return NotFound();
                var personaDto = mapper.Map<PersonaDTO>(persona);
                return Ok(personaDto);


            }
            catch (Exception)
            {

                return InternalServerError();
            }

        }
        /// <summary>
        /// Inserta un Objeto Persona
        /// </summary>
        /// <param name="personaDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(PersonaDTO))]
        public async Task<IHttpActionResult> Insertar(PersonaDTO personaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var persona = mapper.Map<Persona>(personaDTO);
                persona = await personaService.Insert(persona);
                personaDTO = mapper.Map<PersonaDTO>(persona);
                return Ok(personaDTO);
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Actualiza un Objeto persona
        /// </summary>
        /// <param name="personaDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(PersonaDTO))]
        public async Task<IHttpActionResult> Put(PersonaDTO personaDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != personaDTO.PersonaID)
                return BadRequest();
            
            var flag = await personaService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var persona = mapper.Map<Persona>(personaDTO);
                persona = await personaService.Update(persona);
                return Ok(persona);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Elimina un objeto Persona. El mismo no debe estar relacionado con ningun Atributo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Delete( int id)
        {

          
            var flag = await personaService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await personaService.DeletedCheckOnEntity(id))
                {
                    await personaService.Delete(id);
                }
                else
                {
                    throw new Exception("ForeignKeys");
                }
                

                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
