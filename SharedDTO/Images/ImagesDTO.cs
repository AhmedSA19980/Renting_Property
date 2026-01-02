
namespace SharedDTOLayer.Images
{
    public class ImagesDTO
    {
        public ImagesDTO()
        {

            this.ContainerID = -1;
            this.ImageOnePath = "";
            this.ImageTwoPath = "";
            this.ImageThreePath = "";
            this.ImageFourPath = "";
            this.ImageFivePath = "";
            this.ImageSixPath = "";
            this.ImageSevenPath = "";
            this.ImageEightPath = "";
            this.ImageNinePath = "";

        }
        public ImagesDTO(int ContainerID, string imageOnePath, string imageTwoPath, string imageThreePath,
            string imageFourPath, string imageFivePath, string imageSixPath, string imageSevenPath,
           string imageEightPath, string imageNinePath)
        {

            this.ContainerID = ContainerID;
            this.ImageOnePath = imageOnePath;
            this.ImageTwoPath = imageTwoPath;
            this.ImageThreePath = imageThreePath;
            this.ImageFourPath = imageFourPath;
            this.ImageFivePath = imageFivePath;
            this.ImageSixPath = imageSixPath;
            this.ImageSevenPath = imageSevenPath;
            this.ImageEightPath = imageEightPath;
            this.ImageNinePath = imageNinePath;


        }


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



    }
}
