
using LogistikbudeAPIExercise.Dtos;
using LogistikbudeAPIExercise.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogistikbudeAPIExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger;
        private LocationService _locationService;

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
            _locationService = new LocationService();
        }

        /// <summary>
        /// Resturns Locations with the most inbound plus outbound transactions in descending order. If no count is defined 3 Locations are returned.
        /// </summary>
        /// <param name="locationCount">Max Count of Locations to be returned.</param>
        /// <returns>IEnumerable<LocationTransactionCountDto></returns>
        [HttpGet("GetWithMostTransactions/{locationCount:int?}")]
        public IEnumerable<LocationWithTransactionCountDto> GetWithMostTransactions(int locationCount = 3)
        {
            var result = _locationService.GetWithMostTransactions(locationCount);

            return result;
        }


        [HttpGet("GetAllWithUnconfirmedInboundTransactions")]
        public IEnumerable<LocationWithUnconfirmedInboundTransactionCountDto> GetAllWithUnconfirmedInboundTransactions()
        {
            var result = _locationService.GetAllWithUnconfirmedInboundTransactions();

            return result;
        }


        [HttpGet("GetAllWithSaldoTillFirtMay24ForEPAL")]
        public IEnumerable<LocationSaldoDto> GetAllWithSaldoTillFirtMay24ForEPAL()
        {
            var result = _locationService.GetAllWithSaldoTillFirtMay24ForEPAL();

            return result;
        }
    }
}