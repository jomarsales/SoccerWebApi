namespace SoccerApp.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; private set; }
        public bool Active { get; private set; }

        protected EntityBase() { }

        internal void SetActive()
        {
            Active = true;
        }
    }
}
