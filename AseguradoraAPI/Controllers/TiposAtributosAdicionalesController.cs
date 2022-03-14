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
    /// controlador de tipos de atributos adicionales
    /// </summary>
    public class TiposAtributosAdicionalesController : ApiController
    {
        private readonly TipoAtributoAdicionalService tipoAtributoAdicionalService = new TipoAtributoAdicionalService(new TipoAtributoAdicionalRepository(AseguradoraContext.Create()));
        private readonly IMapper mapper;
        /// <summary>
        /// Inicializacion del objeto mapeador de clases mapper
        /// </summary>
        public TiposAtributosAdicionalesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obteniene los tipos de atributos registrados
        /// </summary>
        /// <returns>Coleccion de tipos de atributo adicional</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<TipoAtributoAdicionalDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var tiposAtributos = await tipoAtributoAdicionalService.GetAll();
                if (tiposAtributos == null)
                    return NotFound();
                var tiposAtributosDTO = tiposAtributos.Select(x => mapper.Map<TipoAtributoAdicionalDTO>(x));
                return Ok(tiposAtributosDTO);
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }
        /// <summary>
        /// Obtiene un tipo de atributo adicional registrado
        /// </summary>
        /// <param name="id">Id del TipoAtributoAdicional</param>
        /// <returns>Objeto AtributoAdicional</returns>
        [HttpGet]
        [ResponseType(typeof(TipoAtributoAdicionalDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                var tiposAtributos = await tipoAtributoAdicionalService.GetById(id);
                if (tiposAtributos == null)
                    return NotFound();
                var tiposAtributosDTO = mapper.Map<TipoAtributoAdicionalDTO>(tiposAtributos);
                return Ok(tiposAtributosDTO);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
        /// <summary>
        /// Registra un nuevo TipoAtributoAdicional
        /// </summary>
        /// <param name="tipoAtributoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(TipoAtributoAdicionalDTO))]
        public async Task<IHttpActionResult> Insertar(TipoAtributoAdicionalDTO tipoAtributoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var tipoAtributo = mapper.Map<TipoAtributoAdicional>(tipoAtributoDTO);
                tipoAtributo = await tipoAtributoAdicionalService.Insert(tipoAtributo);
                tipoAtributoDTO = mapper.Map<TipoAtributoAdicionalDTO>(tipoAtributo);
                return Ok(tipoAtributoDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Actualiza un objeto Tipo Atributo Adicional
        /// </summary>
        /// <param name="tipoAtributoDTO">Objeto TipoAtributoAdicional</param>
        /// <param name="id">ID del objeto TipoAtributoAdicional</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put(TipoAtributoAdicionalDTO tipoAtributoDTO,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != tipoAtributoDTO.TipoAtributoAdicionalID)
                return BadRequest();
            var flag = tipoAtributoAdicionalService.GetById(id);
            if (flag == null)
                return NotFound();

            try
            {
                var tipoAtributo = mapper.Map<TipoAtributoAdicional>(tipoAtributoDTO);
                tipoAtributo = await tipoAtributoAdicionalService.Update(tipoAtributo);
                tipoAtributoDTO = mapper.Map<TipoAtributoAdicionalDTO>(tipoAtributo);
                return Ok(tipoAtributoDTO);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un tipo de atributo registrado, el mismo no debe estar asociado a ningun atributo adicional.
        /// </summary>
        /// <param name="id">ID del atributo a eliminar</param>
        /// <returns>HttpResult</returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var tipoatributo = await tipoAtributoAdicionalService.GetById(id);
            if (tipoatributo == null)
                return NotFound();
            
            try
            {
                if (!await tipoAtributoAdicionalService.DeletedCheckOnEntity(id))
                {
                    await tipoAtributoAdicionalService.Delete(id);
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
