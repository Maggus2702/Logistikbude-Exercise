namespace LogistikbudeAPIExercise.Dtos
{
    public class LocationWithUnconfirmedInboundTransactionCountDto
    {
        public int LocationId { get; set; }

        public required string LocationName { get; set; }

        public int UnconfirmedTransactionCount { get; set; }
    }
}
