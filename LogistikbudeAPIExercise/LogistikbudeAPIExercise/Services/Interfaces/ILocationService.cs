using LogistikbudeAPIExercise.Dtos;

namespace LogistikbudeAPIExercise.Services.Interfaces
{
    public interface ILocationService
    {
        public List<LocationWithTransactionCountDto> GetWithMostTransactions(int count);
        public List<LocationWithUnconfirmedInboundTransactionCountDto> GetAllWithUnconfirmedInboundTransactions();
        public List<LocationSaldoDto> GetAllWithSaldoTillFirtMay24ForEPAL();
    }
}
