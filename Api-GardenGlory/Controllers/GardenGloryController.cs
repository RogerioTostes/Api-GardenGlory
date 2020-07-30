using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Api_GardenGlory.Models;
using Dapper;
using System.Data.SqlClient;

namespace Api_GardenGlory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GardenGloryController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Passaro>), (int)HttpStatusCode.OK)]
        public IEnumerable<Passaro> Get(
            [FromServices] IConfiguration configuration)
        {
            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("GardenGlory")))
            {
                return conexao.Query<Passaro>(
                    "SELECT * FROM dbo.Passaro");
            }
        }

        [HttpGet("{Anel}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<Passaro> Get(
            [FromServices] IConfiguration configuration,
            string indicador)
        {
            Passaro resultado = null;

            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("GardenGlory")))
            {
                resultado = conexao.QueryFirstOrDefault<Passaro>(
                    "SELECT * FROM dbo.Indicadores " +
                    "WHERE Sigla = @siglaIndicador",
                    new { siglaIndicador = indicador });
            }

            if (resultado != null)
                return resultado;
            else
            {
                return NotFound(
                    new
                    {
                        Mensagem = "Indicador inválido ou inexistente."
                    });
            }
        }
    }
}