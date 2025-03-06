namespace ResFin.Domain.Users;

public class User : BaseEntity
    {
    #region MyRegion

    private User (
        Guid id,
        FirstName name,
        LastName family,
        Email email,
        Phone? phone,
        CellPhone cellPhone,
        Address? address,
        UserType userType
        ) : base(id)
        {
        FirstName = name;
        LastName = family;
        Email = email;
        Phone = phone;
        CellPhone = cellPhone;
        Address = address;
        UserType = userType;
        }

        private User()
        {
            
        }

    #endregion

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Phone? Phone { get; private set; }
    public CellPhone CellPhone { get; private set; }
    public Address? Address { get; private set; }
    public UserType UserType { get; private set; }


    public static User Create (
        FirstName name,
        LastName family,
        Email email,
        Phone? phone,
        CellPhone cellPhone,
        Address? address,
        UserType userType
        )
        {
        var user = new User(Guid.NewGuid(), name, family, email, phone, cellPhone, address, userType);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
        }

    }