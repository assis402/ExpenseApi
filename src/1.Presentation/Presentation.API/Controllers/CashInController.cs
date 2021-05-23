using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Data;
using Domain.Entities;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashInController : ControllerBase
    {
        ExpenseDB _mongoDB;
        IMongoCollection<CashIn> _cashInsCollection;

        public CashInController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _cashInsCollection = _mongoDB.DB.GetCollection<CashIn>(typeof(CashIn).Name.ToLower());
        }

        [HttpPost]
        public ActionResult Post([FromBody] CashInDto dto)
        {
            CashIn CashIn = new CashIn(dto.Description, dto.Month, dto.Value);

            _cashInsCollection.InsertOne(CashIn);
            
            return StatusCode(201, "CashIn adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult Get()
        {
            var CashIns = _cashInsCollection.Find(Builders<CashIn>.Filter.Empty).ToList();
            
            return Ok(CashIns);
        }
    }
}
