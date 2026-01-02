
namespace SharedDTOLayer.PropertyTypes.PropertyTypesDTO
{

    public class PropertyTypeDTO
    {
        public byte PropertyTypeID { set; get; }
        public string PropertyTypeName { set; get; }

        public PropertyTypeDTO(byte PropertyTypeID, string PropertyTypeName)
        {
            this.PropertyTypeID = PropertyTypeID;
            this.PropertyTypeName = PropertyTypeName;
        }

    }
}
