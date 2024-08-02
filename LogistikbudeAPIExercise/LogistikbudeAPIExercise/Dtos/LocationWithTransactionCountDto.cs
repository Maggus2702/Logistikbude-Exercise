namespace LogistikbudeAPIExercise.Dtos
{
    public class LocationWithTransactionCountDto
    {
        public int LocationId { get; set; }

        public required string LocationName { get; set; }

        public int TransactionCount { get; set; }
    }
}
