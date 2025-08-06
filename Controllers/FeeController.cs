using Microsoft.AspNetCore.Mvc;
using FeeCalculationEngine.Models;
using FeeCalculationEngine.Services;
using FeeCalculationEngine.Data;

namespace FeeCalculationEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly IFeeCalculator _feeCalculator;

        public FeeController()
        {
            _feeCalculator = new FeeCalculator();
        }

        [HttpPost("calculate")]
        public ActionResult<TransactionResult> Calculate([FromBody] TransactionRequest request)
        {
            var result = _feeCalculator.CalculateFee(request);
            HistoryStorage.AddToHistory(request, result);
            return Ok(result);
        }

        [HttpGet("history")]
        public ActionResult<List<TransactionHistory>> GetHistory()
        {
            var history = HistoryStorage.GetHistory();
            return Ok(history);
        }

        [HttpPost("batch")]
        public ActionResult<List<TransactionResult>> CalculateBatch([FromBody] List<TransactionRequest> requests)
        {
            var results = new List<TransactionResult>();
            var lockObj = new object();

            Parallel.ForEach(requests, request =>
            {
                var result = _feeCalculator.CalculateFee(request);
                HistoryStorage.AddToHistory(request, result);

                lock (lockObj)
                {
                    results.Add(result);
                }
            });

            return Ok(results);
        }


    }
}
