using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;
using PropertyRentingApi.Utilities;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ContainerController(IConfiguration configuration) // Constructor injection
        {
            _configuration = configuration;
        }


        [HttpGet("GetImage")]
        public IActionResult GetImage(string fileName)
        {
            var uploadDirectory = @"D:\RentingPorpertySystem\";
            var filePath = Path.Combine(uploadDirectory, fileName);



            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            var image = System.IO.File.OpenRead(filePath);
            var mimeType = clsUitil.GetMimeType(filePath);


            return File(image, mimeType);
        }










        [HttpPost("AddContainer", Name = "AddImages")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddImages(IFormFile ImageOne, IFormFile ImageTwo, IFormFile ImageThree, IFormFile ImageFour = null, IFormFile ImageFive = null,
            IFormFile ImageSix = null,
            IFormFile ImageSeven = null, IFormFile ImageEight = null, IFormFile ImageNine = null)
        {
            ImagesDTO NewImages = new ImagesDTO();
            //we validate the data here


            // check content type if required
            bool imgFour = clsUitil.IsFileIsEmpty(ImageFour);
            bool imgFive = clsUitil.IsFileIsEmpty(ImageFive);
            bool imgSix = clsUitil.IsFileIsEmpty(ImageSix);
            bool imgSeven = clsUitil.IsFileIsEmpty(ImageSeven);
            bool imgEight = clsUitil.IsFileIsEmpty(ImageEight);
            bool imgNine = clsUitil.IsFileIsEmpty(ImageNine);

            NewImages.ImageOnePath = await clsUitil.UploadPropertyImages(ImageOne, _configuration);
            NewImages.ImageTwoPath = await clsUitil.UploadPropertyImages(ImageTwo, _configuration);
            NewImages.ImageThreePath = await clsUitil.UploadPropertyImages(ImageThree, _configuration);
            NewImages.ImageFourPath = await clsUitil.UploadPropertyImages(ImageFour, _configuration, imgFour);
            NewImages.ImageFivePath = await clsUitil.UploadPropertyImages(ImageFive, _configuration, imgFive);
            NewImages.ImageSixPath = await clsUitil.UploadPropertyImages(ImageSix, _configuration, imgSix);
            NewImages.ImageSevenPath = await clsUitil.UploadPropertyImages(ImageSeven, _configuration, imgSeven);
            NewImages.ImageNinePath = await clsUitil.UploadPropertyImages(ImageEight, _configuration, imgEight);
            NewImages.ImageEightPath = await clsUitil.UploadPropertyImages(ImageNine, _configuration, imgNine);

            //newStudent.Id = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(s => s.Id) + 1 : 1;

            PR_BusinessLayer.clsImages images = new PR_BusinessLayer.clsImages(new ImagesDTO(NewImages.ContainerID, NewImages.ImageOnePath, NewImages.ImageTwoPath, NewImages.ImageThreePath
                , NewImages.ImageFourPath, NewImages.ImageFivePath, NewImages.ImageSixPath, NewImages.ImageSevenPath, NewImages.ImageEightPath, NewImages.ImageNinePath));

            if (NewImages == null || string.IsNullOrEmpty(NewImages.ImageOnePath) ||
            string.IsNullOrEmpty(NewImages.ImageTwoPath) ||
            string.IsNullOrEmpty(NewImages.ImageThreePath))
            {
                return BadRequest("Invalid Property data.");
            }


            images.Save();

            NewImages.ContainerID = images.ContainerID;

            //we return the DTO only not the full student object
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetPropertyById", new { id = NewImages.ContainerID }, NewImages);


        }





        [HttpPut("UpdateContainer", Name = "UpdateImages")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateImages(int containerid, IFormFile ImageOne, IFormFile ImageTwo, IFormFile ImageThree, IFormFile ImageFour = null , IFormFile ImageFive = null,
            IFormFile ImageSix = null,
            IFormFile ImageSeven = null, IFormFile ImageEight = null, IFormFile ImageNine = null)
        {


            ImagesDTO imagesDTO = new ImagesDTO();
            //we validate the data here


            PR_BusinessLayer.clsImages Images = PR_BusinessLayer.clsImages.Find(containerid);
            //newStudent.Id = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(s => s.Id) + 1 : 1;
            bool ValidationProblem = true;
            if (Images == null)
            {
                return NotFound($"container Images with ID {containerid} not found.");
            }




            bool imgOne = clsUitil.IsFileIsEmpty(ImageOne);
          
            bool imgTwo = clsUitil.IsFileIsEmpty(ImageTwo);
            bool imgThree = clsUitil.IsFileIsEmpty(ImageThree);

            bool imgFour = clsUitil.IsFileIsEmpty(ImageFour);
            bool imgFive = clsUitil.IsFileIsEmpty(ImageFive);
            bool imgSix = clsUitil.IsFileIsEmpty(ImageSix);
            bool imgSeven = clsUitil.IsFileIsEmpty(ImageSeven);
            bool imgEight = clsUitil.IsFileIsEmpty(ImageEight);
            bool imgNine = clsUitil.IsFileIsEmpty(ImageNine);

            
          


           
            imagesDTO.ImageOnePath = await clsUitil.UploadPropertyImages(ImageOne , _configuration , imgOne);
            imagesDTO.ImageTwoPath = await clsUitil.UploadPropertyImages(ImageTwo, _configuration , imgTwo);
            imagesDTO.ImageThreePath = await clsUitil.UploadPropertyImages(ImageThree, _configuration , imgThree);
            imagesDTO.ImageFourPath = await clsUitil.UploadPropertyImages(ImageFour, _configuration , imgFour);
            imagesDTO.ImageFivePath = await clsUitil.UploadPropertyImages(ImageFive, _configuration, imgFive);
            imagesDTO.ImageSixPath = await clsUitil.UploadPropertyImages(ImageSix, _configuration, imgSix);
            imagesDTO.ImageSevenPath = await clsUitil.UploadPropertyImages(ImageSeven, _configuration, imgSeven);
            imagesDTO.ImageNinePath = await clsUitil.UploadPropertyImages(ImageEight, _configuration, imgEight);
            imagesDTO.ImageEightPath = await clsUitil.UploadPropertyImages(ImageNine, _configuration, imgNine);



           if(imgOne || imgTwo || imgThree )
            {

                clsUitil.DeleteFile(ImageOne, Images.ImageOnePath);
                clsUitil.DeleteFile(ImageTwo, Images.ImageTwoPath);
                clsUitil.DeleteFile(ImageThree, Images.ImageThreePath);

                
                
                if(Images.ImageFourPath != "") clsUitil.DeleteFile(ImageFour, Images.ImageFourPath);
                if (Images.ImageFivePath != "") clsUitil.DeleteFile(ImageFive, Images.ImageFivePath);


                if (Images.ImageSixPath != "") clsUitil.DeleteFile(ImageSix, Images.ImageSixPath);
                if (Images.ImageSevenPath != "") clsUitil.DeleteFile(ImageSeven, Images.ImageSevenPath);

                if (Images.ImageEightPath != "") clsUitil.DeleteFile(ImageEight, Images.ImageEightPath);
                if (Images.ImageNinePath != "") clsUitil.DeleteFile(ImageNine, Images.ImageNinePath);


                Images.ImageOnePath = imagesDTO.ImageOnePath;
                Images.ImageTwoPath = imagesDTO.ImageTwoPath;
                Images.ImageThreePath = imagesDTO.ImageThreePath;

                Images.ImageFourPath = imagesDTO.ImageFourPath;
                Images.ImageFivePath = imagesDTO.ImageFivePath;
                Images.ImageSixPath = imagesDTO.ImageSixPath;
                Images.ImageSevenPath = imagesDTO.ImageSevenPath;
                Images.ImageEightPath = imagesDTO.ImageEightPath;
                Images.ImageNinePath = imagesDTO.ImageNinePath;
                Images.Save();


               
            }
            else
            {
                Images.ImageOnePath = Images.ImageOnePath;
                Images.ImageTwoPath = Images.ImageTwoPath;
                Images.ImageThreePath = Images.ImageThreePath;

                Images.ImageFourPath = Images.ImageFourPath;
                Images.ImageFivePath = Images.ImageFivePath;
                Images.ImageSixPath = Images.ImageSixPath;
                Images.ImageSevenPath = Images.ImageSevenPath;
                Images.ImageEightPath = Images.ImageEightPath;
                Images.ImageNinePath = Images.ImageNinePath;

            }

         
            return Ok(Images.IDTO);


        }


        [HttpGet("GetContainerByID", Name = "GetContainerByID")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ImagesDTO>> GetContainerByID(int ContainerID)
        {

            if (ContainerID < 0)
            {

                return BadRequest($"Not accepted ID {ContainerID}");
            }

            PR_BusinessLayer.clsImages Container = PR_BusinessLayer.clsImages.Find(ContainerID);
            if (Container == null)
            {
                return NotFound($"Property with ID {ContainerID} not found.");
            }

            ImagesDTO IDTO = Container.IDTO;

            return Ok(IDTO);
        }


    }
}
