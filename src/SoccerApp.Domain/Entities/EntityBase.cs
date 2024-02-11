namespace SoccerApp.Domain.Entities
{
    internal abstract class EntityBase
    {
        public int Id { get; private set; }
        public bool Active { get; private set; }

        internal void SetActive()
        {
            Active = true;
        }
    }
}
