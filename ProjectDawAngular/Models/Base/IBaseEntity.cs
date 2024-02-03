namespace ProjectDawAngular.Models.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        bool IsDeleted { get; set; }
    }
}
