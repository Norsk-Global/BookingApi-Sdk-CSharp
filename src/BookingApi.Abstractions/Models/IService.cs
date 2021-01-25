using System.Collections.Generic;

namespace BookingApi.Abstractions.Models
{
    public interface IService
    {
        string Code { get; set; }

        List<IEnhancement> Enhancements { get; set; }

        string Supplier { get; set; }

        string Route { get; set; }
    }
}
