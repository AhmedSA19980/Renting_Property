

namespace SharedDTOLayer.Countries.CountriesDTO
{
    public class CountryDTO
    {
        public CountryDTO(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;


        }

        public int CountryID { get; set; }
        public string CountryName { get; set; }



    }
}
