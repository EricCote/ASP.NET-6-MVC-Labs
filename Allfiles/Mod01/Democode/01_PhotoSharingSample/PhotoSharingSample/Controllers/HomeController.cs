﻿using Microsoft.AspNetCore.Mvc;
using PhotoSharingSample.Models;

namespace PhotoSharingSample.Controllers;

public class HomeController : Controller
{
    private PhotoSharingDB _dbContext;
    private IWebHostEnvironment _environment;

    public HomeController(PhotoSharingDB dbContext, IWebHostEnvironment environment)
    {
        _dbContext = dbContext;
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View(_dbContext.Photos.ToList());
    }

    public IActionResult GetImage(int PhotoId)
    {
        Photo? requestedPhoto = _dbContext.Photos.FirstOrDefault(p => p.PhotoID == PhotoId);
        if (requestedPhoto != null)
        {
            string webRootpath = _environment.WebRootPath;
            string folderPath = "\\images\\";
            string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

            FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return File(fileBytes, requestedPhoto.ImageMimeType);
        }
        else
        {
            return NotFound();
        }
    }
}
