using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedDTOLayer.Images;
using PropertyRentingApi.Utilities;
using System.Security.Claims;
using UtillsLayer;



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
            var mimeType = clsMemeType.GetMimeType(filePath);


            return File(image, mimeType);
        }


        [Authorize]
        [HttpPost("AddContainer", Name = "AddImages")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddImages(IFormFile ImageOne, IFormFile ImageTwo, IFormFile ImageThree, IFormFile ImageFour = null, IFormFile ImageFive = null,
            IFormFile ImageSix = null,
            IFormFile ImageSeven = null, IFormFile ImageEight = null, IFormFile ImageNine = null)
        {
            ImagesDTO NewImages = new ImagesDTO();
 
            bool imgFour = clsMedia.IsFileIsEmpty(ImageFour);
            bool imgFive = clsMedia.IsFileIsEmpty(ImageFive);
            bool imgSix = clsMedia.IsFileIsEmpty(ImageSix);
            bool imgSeven = clsMedia.IsFileIsEmpty(ImageSeven);
            bool imgEight = clsMedia.IsFileIsEmpty(ImageEight);
            bool imgNine = clsMedia.IsFileIsEmpty(ImageNine);

            NewImages.ImageOnePath = await clsMedia.UploadPropertyImages(ImageOne, _configuration);
            NewImages.ImageTwoPath = await clsMedia.UploadPropertyImages(ImageTwo, _configuration);
            NewImages.ImageThreePath = await clsMedia.UploadPropertyImages(ImageThree, _configuration);
            NewImages.ImageFourPath = await clsMedia.UploadPropertyImages(ImageFour, _configuration, imgFour);
            NewImages.ImageFivePath = await clsMedia.UploadPropertyImages(ImageFive, _configuration, imgFive);
            NewImages.ImageSixPath = await clsMedia.UploadPropertyImages(ImageSix, _configuration, imgSix);
            NewImages.ImageSevenPath = await clsMedia.UploadPropertyImages(ImageSeven, _configuration, imgSeven);
            NewImages.ImageNinePath = await clsMedia.UploadPropertyImages(ImageEight, _configuration, imgEight);
            NewImages.ImageEightPath = await clsMedia.UploadPropertyImages(ImageNine, _configuration, imgNine);



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


            PR_BusinessLayer.clsImages Images = PR_BusinessLayer.clsImages.Find(containerid);

            bool ValidationProblem = true;
            if (Images == null)
            {
                return NotFound($"container Images with ID {containerid} not found.");
            }




            bool imgOne = clsMedia.IsFileIsEmpty(ImageOne);
          
            bool imgTwo = clsMedia.IsFileIsEmpty(ImageTwo);
            bool imgThree = clsMedia.IsFileIsEmpty(ImageThree);

            bool imgFour = clsMedia.IsFileIsEmpty(ImageFour);
            bool imgFive = clsMedia.IsFileIsEmpty(ImageFive);
            bool imgSix = clsMedia.IsFileIsEmpty(ImageSix);
            bool imgSeven = clsMedia.IsFileIsEmpty(ImageSeven);
            bool imgEight = clsMedia.IsFileIsEmpty(ImageEight);
            bool imgNine = clsMedia.IsFileIsEmpty(ImageNine);

           

           
            imagesDTO.ImageOnePath = await clsMedia.UploadPropertyImages(ImageOne , _configuration , imgOne);
            imagesDTO.ImageTwoPath = await clsMedia.UploadPropertyImages(ImageTwo, _configuration , imgTwo);
            imagesDTO.ImageThreePath = await clsMedia.UploadPropertyImages(ImageThree, _configuration , imgThree);
            imagesDTO.ImageFourPath = await clsMedia.UploadPropertyImages(ImageFour, _configuration , imgFour);
            imagesDTO.ImageFivePath = await clsMedia.UploadPropertyImages(ImageFive, _configuration, imgFive);
            imagesDTO.ImageSixPath = await clsMedia.UploadPropertyImages(ImageSix, _configuration, imgSix);
            imagesDTO.ImageSevenPath = await clsMedia.UploadPropertyImages(ImageSeven, _configuration, imgSeven);
            imagesDTO.ImageNinePath = await clsMedia.UploadPropertyImages(ImageEight, _configuration, imgEight);
            imagesDTO.ImageEightPath = await clsMedia.UploadPropertyImages(ImageNine, _configuration, imgNine);



           if(imgOne || imgTwo || imgThree )
            {

                clsMedia.DeleteFile(ImageOne, Images.ImageOnePath);
                clsMedia.DeleteFile(ImageTwo, Images.ImageTwoPath);
                clsMedia.DeleteFile(ImageThree, Images.ImageThreePath);

                
                
                if(Images.ImageFourPath != "") clsMedia.DeleteFile(ImageFour, Images.ImageFourPath);
                if (Images.ImageFivePath != "") clsMedia.DeleteFile(ImageFive, Images.ImageFivePath);


                if (Images.ImageSixPath != "") clsMedia.DeleteFile(ImageSix, Images.ImageSixPath);
                if (Images.ImageSevenPath != "") clsMedia.DeleteFile(ImageSeven, Images.ImageSevenPath);

                if (Images.ImageEightPath != "") clsMedia.DeleteFile(ImageEight, Images.ImageEightPath);
                if (Images.ImageNinePath != "") clsMedia.DeleteFile(ImageNine, Images.ImageNinePath);


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


        [HttpGet("GetContainerByID", Name = "GetContainerByID")] 
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
                return NotFound($"Images container with ID  = {ContainerID} is not found.");
            }

            ImagesDTO IDTO = Container.IDTO;

            return Ok(IDTO);
        }

        //[Authorize]
        [HttpDelete("DeleteContainerImages", Name = "DeleteContainerImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> DeleteContainerImages(int ContainerId)
        {
            if (ContainerId < 1)
            {
                return BadRequest($"Not accepted ID {ContainerId}");
            }
          

            if (PR_BusinessLayer.clsImages.DeleteContaninerImagesOnlyWhenPropertyFailed(ContainerId) != -1)

                return Ok($"Container images with ID {ContainerId} has been deleted.");
            else
                return NotFound($"Container images  with ID {ContainerId} not found!");
        }

    }
}
