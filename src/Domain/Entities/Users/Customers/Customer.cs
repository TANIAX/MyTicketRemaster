using MyTicketRemaster.Domain.Entities.Users.Contacts;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MyTicketRemaster.Domain.Entities.Users.Customers;

public class Customer : User
{
    #region Properties
    [Required]
    [MaxLength(CustomerInvariants.CompanyNameMaxLength)]
    public string CompanyName { get; private set; }

    [Required]
    [MaxLength(CustomerInvariants.AddressStreetMaxLength)]
    public Address Address { get; private set; }
    public virtual ICollection<TContact> Contacts { get; private set; }
    #endregion

    #region Constructors
    public Customer() : base()
        =>Contacts = new List<TContact>();
    

    public Customer(string companyName, string email, string phoneNumber, string signature, string language, string profilPicture, string applicationUserId, Address address)
        : base(email, phoneNumber, signature, language, profilPicture, applicationUserId)
    {
        UpdateCompanyName(companyName);
        UpdateAddress(address);
    }
    #endregion

    #region Methods

    public void UpdateCompanyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("CompanyName cannot be empty.");

        if (value.Length > CustomerInvariants.CompanyNameMaxLength)
            throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum company name length ({CustomerInvariants.CompanyNameMaxLength}).");

        CompanyName = value;
    }   

    [MemberNotNull(nameof(Address))]
    public void UpdateAddress(Address address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void AddContact(TContact contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        Contacts.Add(contact);
    }

    public void RemoveContact(TContact contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        Contacts.Remove(contact);
    }
    #endregion

}