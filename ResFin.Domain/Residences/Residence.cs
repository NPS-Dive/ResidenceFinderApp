using ResFin.Domain.Abstractions;

namespace ResFin.Domain.Residences;

public sealed class Residence : BaseEntity
    {
        public Residence(Guid id) 
            : base(id)
        {
        }

        public string Name { get; private set; }
    public string Description { get; private set; }
    public string Country { get; private set; }
    public string StateOrProvince { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string? Alley { get; private set; }
    public string? Number { get; private set; }
    public string? ZipCode { get; private set; }
    public decimal PricePerNight { get; private set; }
    public string PriceCurrency { get; private set; }
    public string? PriceDiscount { get; private set; }
    public decimal CleaningFee { get; private set; }
    public string CleaningFeeCurrency { get; private set; }
    public DateTime? LastBookedUTC { get; private set; }
    public ResidenceType ResidenceType { get; private set; } = ResidenceType.Apartment;
    public Capacity Capacity { get; private set; } = Capacity.Four;
    public List<Amenity> Amenities { get; private set; } = new();
    }