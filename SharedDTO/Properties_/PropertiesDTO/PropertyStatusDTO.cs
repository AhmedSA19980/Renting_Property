using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Properties_.PropertiesDTO
{
    public  class PropertyStatusDTO
    {
      
            public int PropertyID { get; set; }
            public string CountryName { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
            public string PropertyTypeName { get; set; }
            public decimal Price { get; set; }
            public string PropertyStatus { get; set; } // "Active" / "Inactive"

        public PropertyStatusDTO(int PropertyID , string Name  ,string CountryName , string city , string Address
            ,string PropertyTypeName ,decimal Price , string PropertyStatus) { 
        
            this.PropertyID = PropertyID;
            this.CountryName = CountryName;
            this.Name = Name;
            this.City = city;
            this.Address = Address;
            this.PropertyTypeName = PropertyTypeName;
            this.Price = Price;
            this.PropertyStatus = PropertyStatus;

        
        
        
        }
        
    }
}
