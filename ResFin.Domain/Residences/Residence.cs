namespace ResFin.Domain.Residences;

public sealed class Residence : BaseEntity
    {

    #region Cunstructor
    
    private Residence(
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

    private Residence()
    {
        
    }
    #endregion

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
   public Money PricePerNight { get; set; }
    public Money? PriceDiscount { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedUTC { get; internal set; }
    public ResidenceType ResidenceType { get; private set; } = ResidenceType.Apartment;
    public Capacity Capacity { get; private set; } = Capacity.Four;
    public List<Amenity> Amenities { get; private set; } = new();

   
    public static Residence Create(
        Name name,
        Description description,
        Address address,
        Money pricePerNight,
        Money? priceDiscount,
        Money cleaningFee,
        DateTime? lastBookedUtc,
        ResidenceType residenceType,
        Capacity capacity,
        List<Amenity> amenities )
    {
        var residence = new Residence(Guid.NewGuid(), name, description, address, pricePerNight, priceDiscount, cleaningFee, lastBookedUtc, residenceType, capacity, amenities);
     
       residence.RaiseDomainEvent(new ResidenceCreatedDomainEvent(residence.Id));

        return residence;
    }
    }