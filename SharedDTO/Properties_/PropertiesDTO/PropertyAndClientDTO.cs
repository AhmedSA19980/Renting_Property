

namespace SharedDTOLayer.Properties_.PropertiesDTO
{
    public class PropertyAndClientDTO : PropertyDTO
    {
        public PropertyAndClientDTO(int ClientId, int PropertyID, int CountryID, string City, string Address,
          string? PlaceDescription, int ContainerID,
         byte NumberOfBedRooms, byte NumberOfBathRooms, byte PropertyTypeID, decimal Price, string Name) : base(PropertyID, CountryID,
              City, Address,
           PlaceDescription, ContainerID,
          NumberOfBedRooms,
          NumberOfBathRooms, PropertyTypeID, Price, Name)
        {
            this.ClientID = ClientId;

            this.PropertyID = PropertyID;
            this.CountryID = CountryID;
            this.City = City;
            this.Address = Address;
            this.PlaceDescription = PlaceDescription;
            this.ContainerID = ContainerID;
            this.NumberOfBedrooms = NumberOfBedRooms;
            this.NumberOfBathrooms = NumberOfBathRooms;
            this.PropertyTypeID = PropertyTypeID;
            this.Price = Price;
            this.Name = Name;

        }
        public int ClientID { get; set; }
    }

}
