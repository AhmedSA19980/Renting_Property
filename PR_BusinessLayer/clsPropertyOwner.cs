using PR_DataAccessLayer;
using SharedDTOLayer.ProperiesOwner.PropertiesOwnerDTO;


namespace PR_BusinessLayer
{
    public class clsPropertyOwner
    {
        public int PropertyOwnerId { get; set; }
        public int ClientID { get; set; }

        public int PropertyID { get; set; }



        public PropertyOwnerDTO PODTO
        {
            get
            {
                return (new PropertyOwnerDTO(
                    this.PropertyOwnerId,
                    this.PropertyID,
                    this.ClientID 

               ));
            }
        }


        public clsPropertyOwner(PropertyOwnerDTO PODTO)
        {
            this.PropertyID = PODTO.PropertyID;
            this.PropertyOwnerId = PODTO.PropertyOwnerId;
            this.ClientID = PODTO.ClientID;
           
        }


        public static clsPropertyOwner Find(int PropertyOwnerID)
        {
            PropertyOwnerDTO PODTO = clsPropertyOwnerData.FindPropertyOwnerByPropertyOwnerID(PropertyOwnerID);

            if (PODTO != null)
            {
                return new clsPropertyOwner(PODTO);
            }
            else
                return null;
        }

        public static int GetPropertyClientIdByPropertyID(int PropertyID)
        {
            return clsPropertyOwnerData.GetPropertyClientIdByPropertyID(PropertyID);    
        }

        public static List<PropertyOwnerDTO> GetAllByPropertyID(int ClientID)
        {
            List<PropertyOwnerDTO> Properties;
            if (ClientID != -1)
            {
                Properties = clsPropertyOwnerData.FindAllPropertiesBelongToOwner(ClientID);
                if (Properties.Count>  0)
                {
                   
                    return Properties;
                }
            }


            return null;
        }

    }
}
