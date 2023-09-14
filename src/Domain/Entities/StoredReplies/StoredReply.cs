using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.StoredReplies
{
    public class StoredReply : MyEntity
    {
        [Required]
        [StringLength(StoredReplyInvariants.NameMaxLength)]
        public string Title { get; private set; }
        public string Reply { get; private set; }

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
    }
}
