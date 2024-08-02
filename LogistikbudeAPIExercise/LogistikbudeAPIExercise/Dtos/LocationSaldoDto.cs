namespace LogistikbudeAPIExercise.Dtos
{
    public class LocationSaldoDto
    {
        public int LocationId { get; set; }

        public required string LocationName { get; set; }

        public int Saldo { get; set; }
    }
}
