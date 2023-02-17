namespace WebApiStore.Interfaces
{
    public interface ISoftDelete
    {
        DateTime? DeletedAt { get; set; }
    }
}
