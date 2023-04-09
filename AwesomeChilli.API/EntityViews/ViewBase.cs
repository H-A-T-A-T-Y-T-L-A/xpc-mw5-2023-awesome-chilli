namespace AwesomeChilli.API.EntityViews
{
    public class ViewBase<EntityT>
    {
        public Guid Id { get; set; }
        public ViewBase(EntityT entity) { }
    }
}
