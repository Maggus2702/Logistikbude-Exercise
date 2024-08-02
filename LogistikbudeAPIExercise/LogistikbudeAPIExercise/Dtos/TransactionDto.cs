namespace LogistikbudeAPIExercise.Dtos
{
    public class TransactionDto
    {
        public int DestinationLocationId { get; set; }

        public required string DestinationLocationName { get; set; }

        public DateTime Date { get; set; }

        public DateTime? AcceptedDate { get; set; }

        public required string LoadCarriers { get; set; }
    }
}
