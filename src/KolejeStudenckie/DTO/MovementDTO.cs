using KolejeStudenckie.DTO.Interfaces;

namespace KolejeStudenckie.DTO
{
    public class MovementDTO : IDTO
    {
        public int CurrentSpeed { get; set; }
        public bool IsMoving { get; set; }
    }
}
