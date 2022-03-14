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
    /// <summary>
    /// controlador de atributos adicionales
    /// </summary>
    [RoutePrefix("api/AtributosAdicionales")]
    public class AtributosAdicionalesController : ApiController
    {
        private readonly AtributoAdicionalService atributoAdicionalService = new AtributoAdicionalService(new AtributoAdicionalRepository(AseguradoraContext.Create()));
        private readonly IMapper mapper;
        /// <summary>
        /// Inicializacion del objeto mapeador de clases mapper
        /// </summary>
        public AtributosAdicionalesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtine los atributos adicionales registrados de las personas registradas en la aseguradora.
        /// </summary>
        /// <returns>Lista de Objetos Atributos Adicionales</returns>
        [HttpGet]
        [Route("GetAll")]
        [ResponseType(typeof(IEnumerable<AtributoAdicionalDTO>))]

        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var atributosAdicionales = await atributoAdicionalService.GetAll();
                if (atributosAdicionales == null)
                    return NotFound();
                var atributosAdicionalesDTO = atributosAdicionales.Select(x => mapper.Map<AtributoAdicionalDTO>(x));
                return Ok(atributosAdicionalesDTO);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// Obtiene un Atributo Adicional registrado 
        /// </summary>
        /// <param name="id">Id de un Objteto Atributo</param>
        /// <returns>Objeto Atributo Adicional</returns>
        [HttpGet]
        [Route("GetById/{id}")]
        [ResponseType(typeof(AtributoAdicionalDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {

            try
            {
                var atributoAdicional = await atributoAdicionalService.GetById(id);
                if (atributoAdicional == null)
                    return NotFound();
                var atributoAdicionalDTO = mapper.Map<AtributoAdicionalDTO>(atributoAdicional);
                return Ok(atributoAdicionalDTO);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// Obtiene la coleccion de objetos registrados relacionados con una persona
        /// </summary>
        /// <param name="id">ID de una persona registrada.</param>
        /// <returns>Lista de Objetos Atributos Adicionales</returns>
        [HttpGet]
        [Route("GetByPersonId/{id}")]
        [ResponseType(typeof(ICollection<AtributoAdicionalDTO>))]
        public async Task<IHttpActionResult> GetByPersonId(int id)
        {


            try
            {
                var atributosAdicionales = await atributoAdicionalService.GetByPersonId(id);
                if (atributosAdicionales == null)
                    return NotFound();
                var atributosAdicionalesDTO = atributosAdicionales.Select(x => mapper.Map<AtributoAdicionalDTO>(x));
                return Ok(atributosAdicionalesDTO);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Registra un nuevo AtributoAdicional
        /// </summary>
        /// <param name="atributoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(AtributoAdicionalDTO))]
        public async Task<IHttpActionResult> Insertar(AtributoAdicionalDTO atributoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var atributo = mapper.Map<AtributoAdicional>(atributoDTO);
                atributo = await atributoAdicionalService.Insert(atributo);
                atributoDTO = mapper.Map<AtributoAdicionalDTO>(atributo);
                return Ok(atributoDTO);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Actualiza un Atributo Adicional Registrado
        /// </summary>
        /// <param name="atributoDTO">Objeto AtributoAdicional</param>
        /// <param name="id">Id del objeto </param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(AtributoAdicionalDTO))]
        public async Task<IHttpActionResult> Put(AtributoAdicionalDTO atributoDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != atributoDTO.AtributoAdicionalID)
                return BadRequest();
            var flag = await atributoAdicionalService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                var atributo = mapper.Map<AtributoAdicional>(atributoDTO);
                atributo = await atributoAdicionalService.Update(atributo);
                return Ok(atributo);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un atributo registrado
        /// </summary>
        /// <param name="id">ID del atributo a eliminar</param>
        /// <returns>HttpResult</returns>
        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await atributoAdicionalService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                await atributoAdicionalService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

    }
}
