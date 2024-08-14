
using LogistikbudeAPIExercise.Dtos;
using LogistikbudeAPIExercise.Services;
using LogistikbudeAPIExercise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogistikbudeAPIExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger;
        private readonly ILocationService _locationService;

        public LocationsController(ILogger<LocationsController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        /// <summary>
        /// Resturns Locations with the most inbound plus outbound transactions in descending order. If no count is defined 3 Locations are returned.
        /// </summary>
        /// <param name="locationCount">Max Count of Locations to be returned.</param>
        /// <returns>IEnumerable<LocationTransactionCountDto></returns>
        [HttpGet("GetWithMostTransactions/{locationCount:int?}")]
        public IActionResult GetWithMostTransactions(int locationCount = 3)
        {
            _logger.LogInformation(GetType().Name + ", GetWithMostTransactions: Was called!");

            try
            {
                var result = _locationService.GetWithMostTransactions(locationCount);
                _logger.LogInformation(GetType().Name + ", GetWithMostTransactions: Was called successfully!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().Name + ", GetWithMostTransactions: ERROR-Message: " + ex.Message + "; ERROR-InnerMessage: " + ex.InnerException?.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns all Locations with unconfirmed inbound Transactions and their count.
        /// </summary>
        /// <returns>IEnumerable<LocationWithUnconfirmedInboundTransactionCountDto></returns>
        [HttpGet("GetAllWithUnconfirmedInboundTransactions")]
        public IActionResult GetAllWithUnconfirmedInboundTransactions()
        {
            _logger.LogInformation(GetType().Name + ", GetAllWithUnconfirmedInboundTransactions: Was called!");
            
            try
            {
                var result = _locationService.GetAllWithUnconfirmedInboundTransactions();
                _logger.LogInformation(GetType().Name + ", GetAllWithUnconfirmedInboundTransactions: Was called successfully!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().Name + ", GetWithMostTransactions: ERROR-Message: " + ex.Message + "; ERROR-InnerMessage: " + ex.InnerException?.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns the Salod (Inbound - Outbound Transactions) for all Locations till day 01.05.2024 and Loadcarrier EPAL
        /// </summary>
        /// <returns>IEnumerable<LocationSaldoDto></returns>
        [HttpGet("GetAllWithSaldoTillFirtMay24ForEPAL")]
        public IActionResult GetAllWithSaldoTillFirtMay24ForEPAL()
        {
            _logger.LogInformation(GetType().Name + ", GetAllWithSaldoTillFirtMay24ForEPAL: Was called!");
            
            try
            {
                var result = _locationService.GetAllWithSaldoTillFirtMay24ForEPAL();
                _logger.LogInformation(GetType().Name + ", GetAllWithSaldoTillFirtMay24ForEPAL: Was called successfully!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().Name + ", GetWithMostTransactions: ERROR-Message: " + ex.Message + "; ERROR-InnerMessage: " + ex.InnerException?.Message);
                return BadRequest();
            }
        }
    }
}