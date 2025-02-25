using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using System.Globalization;
using doeArenaAPI.Model;
using doeArenaAPI.Services;



namespace doeArenaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class doeArenaController : ControllerBase
    {
        private readonly IdoeArenaService _idoeArenaService;

        public doeArenaController(IdoeArenaService serviceDoe)
        {
            _idoeArenaService = serviceDoe;
        }

        [HttpGet(Name = "getDoeArena")]
        public async Task<ActionResult<List<DoeArena>>> doeArenaValores()
        {
            var retorno = await _idoeArenaService.doeArenaValores();
            return Ok(retorno);
        }
    }
}
