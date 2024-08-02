using LogistikbudeAPIExercise.Controllers;
using LogistikbudeAPIExercise.Dtos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace LogistikbudeAPIExercise.Services
{
    public class LocationService
    {
        private readonly List<LocationDto> _locationData;

        public LocationService()
        {
            _locationData = ReadExerciseData();
        }

        private List<LocationDto> ReadExerciseData()
        {
            var result = new List<LocationDto>();

            var dateFormat = "dd/MM/yyyy";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = dateFormat };

            using (StreamReader sr = File.OpenText(@".\Data\logistikbude_exercise.json"))
            {
                var deserializedObject = JsonConvert.DeserializeObject<List<LocationDto>>(sr.ReadToEnd(), dateTimeConverter);
                if (deserializedObject != null)
                    result = deserializedObject;
            }

            return result;
        }

        public List<LocationWithTransactionCountDto> GetWithMostTransactions(int count)
        {
            var result = _locationData
                .SelectMany(locations => locations.TransactionDtos)
                .GroupBy(transactions => transactions.DestinationLocationId)
                .Select(group => new LocationWithTransactionCountDto
                {
                    LocationId = group.Key,
                    LocationName = group.First().DestinationLocationName,
                    TransactionCount = group.Count()
                }).ToList();

            foreach (var location in _locationData)
            {
                if(result.Select(e => e.LocationId).Contains(location.FromLocationId))
                {
                    result.First(e => e.LocationId == location.FromLocationId).TransactionCount += location.TransactionDtos.Count;
                }
                else
                {
                    result.Add(new LocationWithTransactionCountDto
                    {
                        LocationId = location.FromLocationId,
                        LocationName = location.FromLocationName,
                        TransactionCount = location.TransactionDtos.Count()
                    });
                }
            }

            result = result.OrderByDescending(location => location.TransactionCount).Take(count).ToList();

            return result;
        }

        public List<LocationWithUnconfirmedInboundTransactionCountDto> GetAllWithUnconfirmedInboundTransactions()
        {
            var result = _locationData
                .SelectMany(locations => locations.TransactionDtos)
                .Where(transaction => transaction.AcceptedDate == null)
                .GroupBy(transactions => transactions.DestinationLocationId)
                .Select(group => new LocationWithUnconfirmedInboundTransactionCountDto
                {
                    LocationId = group.Key,
                    LocationName = group.First().DestinationLocationName,
                    UnconfirmedTransactionCount = group.Count()
                }).ToList();

            return result;
        }

        public List<LocationSaldoDto> GetAllWithSaldoTillFirtMay24ForEPAL()
        {
            var result = new List<LocationSaldoDto>();

            var inboundTransactions = _locationData
                .SelectMany(locations => locations.TransactionDtos)
                .Where (transaction => transaction.AcceptedDate != null && transaction.AcceptedDate <= DateTime.Parse("01.05.2024") && transaction.LoadCarriers.Contains("EPAL"))
                .GroupBy(transactions => transactions.DestinationLocationId)
                .Select(group => new LocationWithTransactionCountDto
                {
                    LocationId = group.Key,
                    LocationName = group.First().DestinationLocationName,
                    TransactionCount = group.Count()
                }).ToList();



            foreach (var location in _locationData)
            {
                if (inboundTransactions.Select(e => e.LocationId).Contains(location.FromLocationId))
                {
                    result.Add(new LocationSaldoDto
                    {
                        LocationId = location.FromLocationId,
                        LocationName = location.FromLocationName,
                        Saldo = inboundTransactions.First(e => e.LocationId == location.FromLocationId).TransactionCount - location.TransactionDtos.Where(a => a.LoadCarriers.Contains("EPAL")).ToList().Count
                    });
                }
                else
                {
                    result.Add(new LocationSaldoDto
                    {
                        LocationId = location.FromLocationId,
                        LocationName = location.FromLocationName,
                        Saldo = 0 - location.TransactionDtos.Count
                    });
                }
            }

            return result;
        }
    }
}
