﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.MeetingsServiceReference;

namespace IndignadoWeb.Models
{
    // model for meetings map

    public class MeetingsMapModel
    {
        public DTMeetingsCol meetings { get; set; }

        public float locationLati { get; set; }

        public float locationLong { get; set; }
    }

    // model for meetings notifications map

    public class MeetingsNotificationsMapModel
    {
        public DTMeetingsNotificationsCol meetingsNotifications { get; set; }

        public float locationLati { get; set; }

        public float locationLong { get; set; }
    }

    // model for Create meeting

    public class CreateMeetingModel
    {
        [Required]
        [Display(Name = "Name: ")]
        public String name { get; set; }

        [Display(Name = "Description: ")]
        public String description { get; set; }

        [Required]
        [Display(Name = "Location - Latitude: ")]
        public float locationLati { get; set; }

        [Required]
        [Display(Name = "Location - Longitude: ")]
        public float locationLong { get; set; }

        [Required]
        [Display(Name = "Minimum quorum: ")]
        public int minQuorum { get; set; }

        
        public DateTime dateBegin { get; set; }

        
        public DateTime dateEnd { get; set; }

        
        public int hoursBegin { get; set; }

        
        public int hoursEnd { get; set; }

        
        public int minutesBegin { get; set; }

        
        public int minutesEnd { get; set; }

        //public DTThemeCategoriesColMeetings themeCategories { get; set; }

        //public IEnumerable<SelectListItem> themeCategories { get; set; }

        public Collection<SelectListItem> themeCategories { get; set; }

        public Collection<int> themeCategoriesId { get; set; }

        [Required]
        public HttpPostedFileWrapper ImageUploaded { get; set; }

        public static void ResizeAndSave(string savePath, string fileName, Stream imageBuffer, int maxSideSize, bool makeItSquare)
        {
            int newWidth;
            int newHeight;
            Image image = Image.FromStream(imageBuffer);
            int oldWidth = image.Width;
            int oldHeight = image.Height;
            Bitmap newImage;
            if (makeItSquare)
            {
                int smallerSide = oldWidth >= oldHeight ? oldHeight : oldWidth;
                double coeficient = maxSideSize / (double)smallerSide;
                newWidth = Convert.ToInt32(coeficient * oldWidth);
                newHeight = Convert.ToInt32(coeficient * oldHeight);
                Bitmap tempImage = new Bitmap(image, newWidth, newHeight);
                int cropX = (newWidth - maxSideSize) / 2;
                int cropY = (newHeight - maxSideSize) / 2;
                newImage = new Bitmap(maxSideSize, maxSideSize);
                Graphics tempGraphic = Graphics.FromImage(newImage);
                tempGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                tempGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                tempGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                tempGraphic.DrawImage(tempImage, new Rectangle(0, 0, maxSideSize, maxSideSize), cropX, cropY, maxSideSize, maxSideSize, GraphicsUnit.Pixel);
            }
            else
            {
                int maxSide = oldWidth >= oldHeight ? oldWidth : oldHeight;

                if (maxSide > maxSideSize)
                {
                    double coeficient = maxSideSize / (double)maxSide;
                    newWidth = Convert.ToInt32(coeficient * oldWidth);
                    newHeight = Convert.ToInt32(coeficient * oldHeight);
                }
                else
                {
                    newWidth = oldWidth;
                    newHeight = oldHeight;
                }
                newImage = new Bitmap(image, newWidth, newHeight);
            }
            newImage.Save(savePath + fileName + ".jpg", ImageFormat.Jpeg);
            image.Dispose();
            newImage.Dispose();
        }  
    }
    
}
