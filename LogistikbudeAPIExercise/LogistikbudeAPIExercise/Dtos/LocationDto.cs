namespace LogistikbudeAPIExercise.Dtos
{
    public class LocationDto
    {
        public int FromLocationId { get; set; }

        public required string FromLocationName { get; set; }

        public required List<TransactionDto> TransactionDtos { get; set; }
    }
}
