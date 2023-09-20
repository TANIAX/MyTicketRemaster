namespace MyTicketRemaster.Domain.Entities.TicketsHeader;

public static class TicketHeaderInvariants
{
    public const int TitleMaxLength = 100;
    public const int InternTitleMaxLength = 120;
    public const int DescriptionMaxLength = 500;
    public const int EmailMaxLength = 255;
    public const int ReadMinValue = 0;
    public const int ReadMaxValue = 3;
    public const int SatisfactionMinValue = 0;
    public const int SatisfactionMaxValue = 3;
}