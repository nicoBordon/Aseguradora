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

    public class GenerosController : ApiController
    {
        private readonly GeneroService generoService = new GeneroService(new GeneroRepository(AseguradoraContext.Create()));
        private readonly IMapper mapper;
        /// <summary>
        /// Inicializamos el objeto mapedor de clases
        /// </summary>
        public GenerosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<GeneroDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var generos = await generoService.GetAll();
                if (generos == null)
                    return NotFound();
                var generosDtos = generos.Select(x => mapper.Map<GeneroDTO>(x));
                return Ok(generosDtos);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// Obtiene un Objeto Genero por su ID
        /// </summary>
        /// <param name="id">ID Genero</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneroDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                var genero = await generoService.GetById(id);
                if (genero == null)
                    return NotFound();
                var generoDto = mapper.Map<GeneroDTO>(genero);
                return Ok(generoDto);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// Inserta un nuevo Objeto Genero
        /// </summary>
        /// <param name="generoDTO">Objeto Genero</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(GeneroDTO))]
        public async Task<IHttpActionResult> Insertar(GeneroDTO generoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var genero = mapper.Map<Genero>(generoDTO);
                genero = await generoService.Insert(genero);
                generoDTO = mapper.Map<GeneroDTO>(genero);
                return Ok(generoDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }
        }
        /// <summary>
        /// Actualiza un Objeto Genero
        /// </summary>
        /// <param name="generoDTO">Objeto Genero</param>
        /// <param name="id">Id Objeto Genero</param>
        /// <returns>Objeto actualizado</returns>
        [HttpPut]
        [ResponseType(typeof(GeneroDTO))]
        public async Task<IHttpActionResult> Put(GeneroDTO generoDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (generoDTO.GeneroID != id)
                return BadRequest();
            var flag = generoService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                var genero = mapper.Map<Genero>(generoDTO);
                genero = await generoService.Update(genero);
                generoDTO = mapper.Map<GeneroDTO>(genero);
                return Ok(generoDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un objeto Genero. El mismo no debe estar relacionado con ningun objeto Persona.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var genero = await generoService.GetById(id);
            if (genero == null)
                return NotFound();
            try
            {
                if (!await generoService.DeletedCheckOnEntity(id))
                {
                    await generoService.Delete(id);
                    return Ok();
                }
                else
                {
                    throw new Exception("ForeignKeys");
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }


}
