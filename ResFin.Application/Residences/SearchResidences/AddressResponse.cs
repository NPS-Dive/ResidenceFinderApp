

namespace ResFin.Application.Residences.SearchResidences
    {
    public sealed class AddressResponse
        {
        public string Country { get; init; }
        public string StateOrProvince { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Alley { get; init; }
        public string Number { get; init; }
        public string ZipCode { get; init; }
        }
    }