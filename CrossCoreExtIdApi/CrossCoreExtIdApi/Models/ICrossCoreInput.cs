namespace CrossCoreExtIdApi.Models
{
    public interface ICrossCoreInput
    {
        string CorrelationId { get; set; }

        string DeviceIpAddress { get; set; }

        string Email { get; set; }

        string GivenName { get; set; }

        string MiddleName { get; set; }

        string SurName { get; set; }

        string Street { get; set; }

        string PostTown { get; set; }

        string Postal { get; set; }

        string StateProvinceCode { get; set; }

        string CountryCode { get; set; }

        string PhoneNumber { get; set; }
    }
}