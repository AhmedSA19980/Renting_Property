using PR_DataAccessLayer;
using SharedDTOLayer.Images;


namespace PR_BusinessLayer
{
    public  class clsImages
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;



        public int ContainerID { get; set; }



        public string ImageOnePath { get; set; }
        public string ImageTwoPath { get; set; }
        public string ImageThreePath { get; set; }
        public string ImageFourPath { get; set; }
        public string ImageFivePath { get; set; }
        public string ImageSixPath { get; set; }
        public string ImageSevenPath { get; set; }
        public string ImageEightPath { get; set; }
        public string ImageNinePath { get; set; }
      
        public ImagesDTO IDTO{
            get
            {
                return (new ImagesDTO(

                     this.ContainerID,
                this.ImageOnePath,
                this.ImageTwoPath,
                this.ImageThreePath,
                this.ImageFourPath,
                this.ImageFivePath,
                this.ImageSixPath,
                this.ImageSevenPath,
                this.ImageEightPath,
                this.ImageNinePath

                    ));
            }
            
        }
       
        public clsImages(ImagesDTO IDTO , enMode cMode = enMode.AddNew)
        {
            this.ContainerID = IDTO.ContainerID;
            this.ImageOnePath = IDTO.ImageOnePath;
           this. ImageTwoPath = IDTO.ImageTwoPath;
            this.ImageThreePath = IDTO.ImageThreePath;
            this.ImageFourPath = IDTO.ImageFourPath;
            this.ImageFivePath = IDTO.ImageFivePath;
            this.ImageSixPath = IDTO.ImageSixPath;
            this.ImageSevenPath = IDTO.ImageSevenPath;
            this.ImageEightPath = IDTO.ImageEightPath;
            this.ImageNinePath = IDTO.ImageNinePath;
            _Mode = cMode;
        }


        private bool _AddNewImages()
        {
            //call DataAccess Layer 

            this.ContainerID = clsImagesData.AddNewImages(IDTO);

            return (this.ContainerID != -1);
        }

        private bool _UpdateImages()
        {
            //call DataAccess Layer 

            return clsImagesData.UpdateImages(IDTO);

        }


        public static clsImages Find(int ContainerID)
        {


            ImagesDTO IDTO = clsImagesData.FindContainerByContainerID(ContainerID);

            if (IDTO != null)
            {
                return new clsImages(IDTO, enMode.Update);
            }
            else
                return null;

        }

        public static int DeleteContaninerImagesOnlyWhenPropertyFailed(int containerId)
        {
            return (clsImages.Find(containerId) != null) ? clsImagesData.DeleteContainerImages(containerId) ? 1 : -1 : -1;
        }

        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewImages())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateImages();

            }




            return false;
        }
    }
}
