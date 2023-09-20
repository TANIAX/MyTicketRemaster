using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Domain.Entities.StoredReplies;

public class StoredReply : MyEntity
{
    [Required]
    [MaxLength(StoredReplyInvariants.TitleMaxLength)]
    public string Title { get; private set; } 

    [Required]
    public string Reply { get; private set; }

    public StoredReply() { }
    public StoredReply(string title, string reply)
    {
        UpdateTitle(title);
        UpdateReply(reply);
    }
    public override bool Equals(object obj)
    {
        StoredReply sr = (StoredReply)obj;

        if (sr == null)
            return false;

        return sr.Title == Title && sr.Reply == sr.Reply;
    }
    public override int GetHashCode()
    {
        return string.Format("{0}_{1}", Title, Reply).GetHashCode();
    }

    public void UpdateTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty.");

        if (value.Length > PriorityInvariants.NameMaxLength)
            throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({StoredReplyInvariants.TitleMaxLength}).");

        Title = value;
    }

    public void UpdateReply(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty.");

        Reply = value;
    }
}

