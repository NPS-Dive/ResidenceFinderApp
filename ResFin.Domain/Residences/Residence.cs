
namespace ResFin.Domain.Residences;

public sealed class Residence : BaseEntity
    {

    #region Cunstructor
    
    public Residence(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money pricePerNight,
        Money? priceDiscount,
        Money cleaningFee,
        DateTime? lastBookedUtc,
        ResidenceType residenceType,
        Capacity capacity,
        List<Amenity> amenities) 
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        PricePerNight = pricePerNight;
        PriceDiscount = priceDiscount;
        CleaningFee = cleaningFee;
        LastBookedUTC = lastBookedUtc;
        ResidenceType = residenceType;
        Capacity = capacity;
        Amenities = amenities;
    }

    #endregion

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
   public Money PricePerNight { get; set; }
    public Money? PriceDiscount { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedUTC { get; private set; }
    public ResidenceType ResidenceType { get; private set; } = ResidenceType.Apartment;
    public Capacity Capacity { get; private set; } = Capacity.Four;
    public List<Amenity> Amenities { get; private set; } = new();
    }