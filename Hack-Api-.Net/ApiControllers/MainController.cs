using System;
using System.Collections.Generic;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HackApi.Data;
using HackApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HackApi.ApiController
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        public MainController() { }

        [HttpPost("uploadimage/{image}/as/{name}")]
        public ImageUploadResult PostImageToServer(string image, string name)
        {
            var cloudinary = GetCloudinaryAccountInfo();

            var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images/" + image);
            var tranform = new Transformation().Crop("scale").Width(200).Height(200);
            var eagerTransform = new List<Transformation>() {
                new Transformation().Width(250).Height(250).Crop("thumb").Gravity("face").Radius(20).Effect("sepia"),
                new Transformation().Width(100).Height(150).Crop("fit")
            };
            var imageId = image.Substring(0, 5);
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imagePath),
                PublicId= imageId,
                Transformation = tranform,
                EagerTransforms = eagerTransform,
                Tags= "Khophi_"+ imageId,
                Folder="/web",
                Overwrite=true,
                Colors=true
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            HackContext context = HttpContext.RequestServices.GetService(typeof(HackContext)) as HackContext;
            context.FillImageInfo(uploadResult,name);
            return uploadResult;
        }

        [HttpPost("uploadvideo/{video}/as/{name}")]
        public VideoUploadResult PostVideoToServer(string video, string name)
        {
            var cloudinary = GetCloudinaryAccountInfo();

            var vidPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"videos/" + video);
            var tranform = new Transformation().Crop("pad").Width(200).Height(200).
                Duration(10).Quality(120).Radius(20).Effect("reverse").Flags("splice").AudioCodec("none");
            var eagerTransform = new List<Transformation>() {
                new Transformation().Width(250).Height(250).Crop("crop").Radius(20),
                new Transformation().Width(100).Height(150).Crop("fit").Effect("brightness:20").AudioCodec("none")
            };
            var vidId = video.Substring(0, 10);
            var uploadParams = new VideoUploadParams
            {
                File = new FileDescription(vidPath),
                PublicId = vidId,
                Transformation = tranform,
                EagerTransforms = eagerTransform,
                Tags = "Khophi_" + vidId,
                Folder = "/videos",
                Overwrite = true,
                Colors = true,
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            HackContext context = HttpContext.RequestServices.GetService(typeof(HackContext)) as HackContext;
            context.FillVideoInfo(uploadResult,name);
            return uploadResult;
        }


        public Cloudinary GetCloudinaryAccountInfo()
        {
            var account = new Account
            {
                Cloud = "wendolin",
                ApiKey = "447918465166282",
                ApiSecret = "RCoyVQF9Gbxc6oNCNDfoNTK9-Nw"
            };
            var cloudinary = new Cloudinary(account);
            return cloudinary;
        }


    }
}
