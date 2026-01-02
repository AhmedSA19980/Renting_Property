

namespace SharedDTOLayer.ProperiesOwner.PropertiesOwnerDTO
{
    public class PropertyOwnerDTO
    {
        public int PropertyOwnerId { get; set; }
        public int ClientID { get; set; }

        public int PropertyID { get; set; }

        public PropertyOwnerDTO(int PropertyOwnerId, int ClientID, int PropertyID)
        {

            this.PropertyOwnerId = PropertyOwnerId;
            this.ClientID = ClientID;
            this.PropertyID = PropertyID;


        }
    }


}
