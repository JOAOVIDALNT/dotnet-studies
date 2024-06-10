namespace TaskManager.Domain.Entities
{
    public class Task
    {
        public Task(string title, string description, DateTime validThru, int priority, List<string> tickets)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
            ValidThru = validThru;
            Priority = priority;
            Tickets = tickets;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ValidThru { get; private set; }
        public int Priority { get; private set; }
        public List<string> Tickets { get; private set; } = new List<string>();
    }
}
