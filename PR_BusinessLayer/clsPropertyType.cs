using PR_DataAccessLayer;
using SharedDTOLayer.PropertyTypes.PropertyTypesDTO;
using System.Data;


namespace PR_BusinessLayer
{
    public class clsPropertyType
    {
        public sbyte PropertyTypeID { set; get; }
        public string PropertyName { set; get; }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;



        public PropertyTypeDTO PDTO
        {
            get
            {
                return (new PropertyTypeDTO(
            (byte)this.PropertyTypeID,
            this.PropertyName
           
            ));
            }

        }


        public clsPropertyType(PropertyTypeDTO PDTO, enMode cMode = enMode.AddNew)
        {
            this.PropertyTypeID =(sbyte) PDTO.PropertyTypeID;
            this.PropertyName = PDTO.PropertyTypeName;
        
            _Mode = cMode;
        }



        private bool _AddNewPropertyType()
        {
            //call DataAccess Layer 

            this.PropertyTypeID =(sbyte) clsPropertyTypeData.AddNewPropertyType(PDTO);

            return (this.PropertyTypeID != -1);
        }

        private bool _UpdatePropertyType()
        {
            //call DataAccess Layer 

            return clsPropertyTypeData.UpdateTypeProperty(PDTO);

        }


        public static  clsPropertyType Find(sbyte PropertyTypeID)
        {
            PropertyTypeDTO PDTO = clsPropertyTypeData.GetPropertyByPropertyID(PropertyTypeID);

            if (PDTO != null)

                return new clsPropertyType(PDTO, enMode.Update);
            else
                return null;

        }
        
        public static clsPropertyType Find(string PropertyTypeName)
        {

            PropertyTypeDTO PDTO = clsPropertyTypeData.GetPropertyTypeByPropertyName(PropertyTypeName);


            if (PDTO != null)

                return new clsPropertyType(PDTO , enMode.Update);
            else
                return null;

        }



        

        public static DataTable GetAllPropertiesType()
        {
            return clsPropertyTypeData.GetAllPropertiesType();

        }

        public static List<PropertyTypeDTO> GetPropertiesType()
        {
            return clsPropertyTypeData.GetPropertiesType();

        }

        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPropertyType())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePropertyType();

            }




            return false;
        }

        public static bool Delete(sbyte PropertyTypeID) {
            return clsPropertyTypeData.DeleteTypeProperty(PropertyTypeID);
        
        } 

    }
}
