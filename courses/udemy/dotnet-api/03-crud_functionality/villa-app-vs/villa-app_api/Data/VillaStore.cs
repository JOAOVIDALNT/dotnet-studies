using villa_app_api.Models.Dto;

namespace villa_app_api.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO {Id = 1, Name = "Acapulco", Occupancy = 4, Sqft = 100 },
            new VillaDTO {Id = 2, Name = "Beira Mar", Occupancy = 3, Sqft = 75}
        };

    }
}
