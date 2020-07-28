namespace CrossCoreExtIdApi.Models
{
    public class CrossCoreExtIdInput : ICrossCoreInput
    {
        public string extension_d683a96de17e4f92bb31a015d243ca03_PhoneNumber
        {
            set => PhoneNumber = value;
        }

        public string extension_d683a96de17e4f92bb31a015d243ca03_MiddleName
        {
            set => MiddleName = value;
        }

        public string PostalCode
        {
            set => Postal = value;
        }

        public string StreetAddress
        {
            set => Street = value;
        }

        public string State
        {
            set => StateProvinceCode = value;
        }

        public string City
        {
            set => PostTown = value;
        }

        public string Country
        {
            set => CountryCode = value;
        }

        public string CorrelationId { get; set; }

        public string DeviceIpAddress { get; set; }

        public string Email { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string SurName { get; set; }

        public string Street { get; set; }

        public string PostTown { get; set; }

        public string Postal { get; set; }

        public string StateProvinceCode { get; set; }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}