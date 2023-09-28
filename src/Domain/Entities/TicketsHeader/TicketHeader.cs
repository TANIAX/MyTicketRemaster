using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Priorities;
using MyTicketRemaster.Domain.Entities.Projects;
using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Domain.Entities.TicketsLine;
using MyTicketRemaster.Domain.Entities.Types;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.Domain.Entities.TicketsHeader
{
    public class TicketHeader : MyEntity
    {

        #region Properties
        [Required]
        [MaxLength(TicketHeaderInvariants.TitleMaxLength)]
        public string Title { get; private set; }

        [Required]
        [MaxLength(TicketHeaderInvariants.InternTitleMaxLength)]
        public string InternTitle { get; private set; }

        [Required]
        [MaxLength(TicketHeaderInvariants.DescriptionMaxLength)]
        public string Description { get; private set; }

        [Required]
        [MaxLength(TicketHeaderInvariants.EmailMaxLength)]
        public string Email { get; private set; }

        public int Read { get; private set; }
        public int Satisfaction { get; private set; }

        public DateTime? ClosedDate { get; set; }

        public virtual Employee AssignTO { get; private set; }
        public virtual Customer Requester { get; private set; }
        public virtual TGroup Group { get; private set; }
        public virtual TStatus Status { get; private set; }
        public virtual Priority Priority { get; private set; }
        public virtual Project Project { get; private set; }
        public virtual TType Type { get; private set; }
        public virtual ICollection<TicketLine> TicketLines { get; private set; }

        #endregion

        #region Constructors
        public TicketHeader()
        {
            TicketLines = new List<TicketLine>();
        }

        public TicketHeader(string title, string internTitle, string description, string email, Employee assignTO, Customer requester, TGroup group, TStatus status, Priority priority, Project project, TType type, ICollection<TicketLine> ticketLines)
        {
            UpdateTitle(title);
            UpdateInternTitle(internTitle);
            UpdateDescription(description);
            UpdateEmail(email);
            UpdateAssignTO(assignTO);
            UpdateRequester(requester);
            UpdateGroup(group);
            UpdateStatus(status);
            UpdatePriority(priority);
            UpdateProject(project);
            UpdateType(type);
            UpdateTicketLines(ticketLines);
        }
        #endregion

        #region Methods
        public void UpdateTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be empty.");

            if (value.Length > TicketHeaderInvariants.TitleMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum title length ({TicketHeaderInvariants.TitleMaxLength}).");

            Title = value;
        }   

        public void UpdateInternTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("InternTitle cannot be empty.");

            if (value.Length > TicketHeaderInvariants.InternTitleMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum internTitle length ({TicketHeaderInvariants.InternTitleMaxLength}).");

            InternTitle = value;
        }

        public void UpdateDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty.");

            if (value.Length > TicketHeaderInvariants.DescriptionMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum description length ({TicketHeaderInvariants.DescriptionMaxLength}).");

            Description = value;
        }

        public void UpdateEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (value.Length > TicketHeaderInvariants.EmailMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum email length ({TicketHeaderInvariants.EmailMaxLength}).");

            Email = value;
        }

        public void UpdateRead(int value)
        {
            if (value < TicketHeaderInvariants.ReadMinValue)
                throw new ArgumentException($"Value ({value}) is less than minimum read value ({TicketHeaderInvariants.ReadMinValue}).");

            if (value > TicketHeaderInvariants.ReadMaxValue)
                throw new ArgumentException($"Value ({value}) exceeds maximum read value ({TicketHeaderInvariants.ReadMaxValue}).");

            Read = value;
        }

        public void UpdateSatisfaction(int value)
        {
            if (value < TicketHeaderInvariants.SatisfactionMinValue)
                throw new ArgumentException($"Value ({value}) is less than minimum satisfaction value ({TicketHeaderInvariants.SatisfactionMinValue}).");

            if (value > TicketHeaderInvariants.SatisfactionMaxValue)
                throw new ArgumentException($"Value ({value}) exceeds maximum satisfaction value ({TicketHeaderInvariants.SatisfactionMaxValue}).");

            Satisfaction = value;
        }

        public void UpdateClosedDate(DateTime? value)
        {
            if (value == null)
                throw new ArgumentException("ClosedDate cannot be null.");

            ClosedDate = value;
        }
        public void UpdateAssignTO(Employee value)
        {
            if (value == null)
                throw new ArgumentException("AssignTO cannot be null.");

            AssignTO = value;
        }

        public void UpdateRequester(Customer value)
        {
            if (value == null)
                throw new ArgumentException("Requester cannot be null.");

            Requester = value;
        }

        public void UpdateGroup(TGroup value)
        {
            if (value == null)
                throw new ArgumentException("Group cannot be null.");

            Group = value;
        }

        public void UpdateStatus(TStatus value)
        {
            if (value == null)
                throw new ArgumentException("Status cannot be null.");

            Status = value;
        }

        public void UpdatePriority(Priority value)
        {
            if (value == null)
                throw new ArgumentException("Priority cannot be null.");

            Priority = value;
        }

        public void UpdateProject(Project value)
        {
            if (value == null)
                throw new ArgumentException("Project cannot be null.");

            Project = value;
        }

        public void UpdateType(TType value)
        {
            if (value == null)
                throw new ArgumentException("Type cannot be null.");

            Type = value;
        }

        public void UpdateTicketLines(ICollection<TicketLine> value)
        {
            if (value == null)
                throw new ArgumentException("TicketLines cannot be null.");

            TicketLines = value;
        }

        public void AddTicketLine(TicketLine value)
        {
            if (value == null)
                throw new ArgumentException("TicketLine cannot be null.");

            TicketLines.Add(value);
        }

        public void RemoveTicketLine(TicketLine value)
        {
            if (value == null)
                throw new ArgumentException("TicketLine cannot be null.");

            TicketLines.Remove(value);
        }

        #endregion
    }
}
