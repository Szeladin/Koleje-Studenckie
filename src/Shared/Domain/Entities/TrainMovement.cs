namespace Domain.Entities
{
    public class TrainMovement
    {
        public int CurrentSpeed { get; set; } = 0;
        public bool IsMoving { get; set; } = false;
    }
}
