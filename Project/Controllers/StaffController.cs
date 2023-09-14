using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTOs;
using Project.Helper;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IStaffRepo _repository;
        public StaffController(IStaffRepo repository)
        {
            _repository = repository;

        }
        [HttpGet("GetLogo")]
        public ActionResult GetImg()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName = Path.Combine(imgDir, "logo.png");
            string respHeader = "image/png";
            return PhysicalFile(fileName, respHeader);
        }

        [HttpGet("GetVersion")]
        public string GetVersion()
        {
            return "V1";
        }
        [HttpGet("GetAllStaff")]
        public ActionResult<IEnumerable<StaffOutDto>> GetStaff() 
        {
            IEnumerable<Staff> staff = _repository.GetAllStaff();
            IEnumerable<StaffOutDto> c = staff.Select(e => new StaffOutDto 
            { ID = e.ID, FirstName = e.FirstName, LastName = e.LastName, 
                Title = e.Title, Email = e.Email, Tel = e.Tel, Url = e.Url, Research = e.Research}); 
            return Ok(c);

        }
        [HttpGet("GetStaffPhoto/{id}")]
        public ActionResult GetStaffImage(int Id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName = Path.Combine(imgDir, Id +".jpg");
            string respHeader = "image/png";
            if (System.IO.File.Exists(fileName)) 
            { 
                respHeader = "image/png"; 
            }
            else
            {
                fileName = Path.Combine(imgDir, "default.png");
            }
            return PhysicalFile(fileName, respHeader);

        }
        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int Id)
        {
            Staff staff = _repository.GetStaffByID(Id);
            string path = Directory.GetCurrentDirectory();
            string imgDirectory = Path.Combine(path, "StaffPhotos");
            string fileName = Path.Combine(imgDirectory, Id + ".jpg");
            string photoString, photoType;
            ImageFormat imageFormat;

            if (System.IO.File.Exists(fileName))
            {
                CardOut cardOut = new CardOut();
                cardOut.Name = staff.LastName + ";" + staff.FirstName + ";;" + staff.Title + ";";
                cardOut.FirstName = staff.FirstName;
                cardOut.ID = staff.ID.ToString();
                cardOut.LastName = staff.LastName;
                cardOut.Title = staff.Title;
                cardOut.Research = Helper.CategoriesFilter.Filter(staff.Research);  //remove spaces
                cardOut.Email = staff.Email;
                cardOut.Tel = staff.Tel;
                cardOut.Url = staff.Url;
                cardOut.Org = "Southern Hemisphere Institue of Technology";
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(200, 200), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
                cardOut.Photo = photoString;    //type should be jpg
                cardOut.PhotoType = ".jpg";
                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);
            }
            else
            {
                fileName = Path.Combine(imgDirectory, "logo.png");
                CardOut cardOut = new CardOut();
                cardOut.Name = ";;;;";
                cardOut.FirstName = "";
                cardOut.ID = "";
                cardOut.LastName = "";
                cardOut.Title = "";
                cardOut.Research = "";  //remove spaces
                cardOut.Email = "";
                cardOut.Tel = "";
                cardOut.Url = "";
                cardOut.Org = "";
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
                cardOut.Photo = photoString;    //type should be jpg
                cardOut.PhotoType = ".png";
                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);
            }



            

        }
    }
}
