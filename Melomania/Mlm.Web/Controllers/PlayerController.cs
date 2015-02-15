using Mlm.Domain.Abstract.Database;
using Mlm.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TagLib;
using WebMatrix.WebData;

namespace Mlm.Web.Controllers
{
    public class PlayerController : Controller
    {
        //
        // GET: /Player/
        IRepository _db;
        public PlayerController(IRepository db)
        {
            _db = db;
        }

        public PartialViewResult Player()
        {
            return PartialView();
        }

        public RedirectToRouteResult AddMusic(HttpPostedFileBase music)
        {
            Music newItem = new Music();

            try
            {
                newItem.MimeType = music.ContentType;
                newItem.Track = new byte[music.ContentLength];

                music.InputStream.Read(newItem.Track, 0, music.ContentLength);

                TagLib.File tag = TagLib.File.Create(new SimpleFile(music.InputStream, music.FileName));

                newItem.Item_Information = new Item_Info()
                {
                    Like_Count = 0,
                    Repost_Count = 0
                };
                newItem.Information = new Music_Info()
                {
                    Name = tag.Name,
                    Album = tag.Tag.Album,
                    Autor = tag.Tag.Artists.First()
                };          
               
                var user = _db.users.FirstOrDefault(x => x.Id == WebSecurity.CurrentUserId);
                if (user != null)
                {
                    newItem.Users.Add(user);    
                }
                _db.Add(newItem);

                
                TempData["Message"] = "Новий трек завантажено на сервер.";
        }
            catch(Exception e)
            {
                TempData["Message"] = "Нажаль, сталась помилка при завантеженні.";
            }
            return RedirectToAction("Index", "Profile");
        }

    }

    public class SimpleFile : TagLib.File.IFileAbstraction
    {
        private Stream stream;
        private string name;
        public SimpleFile(Stream stream, string name)
        {
            this.stream = stream;
            this.name = name;
        }


        void TagLib.File.IFileAbstraction.CloseStream(Stream stream)
        {
            stream.Close();
        }

        string TagLib.File.IFileAbstraction.Name
        {
            get { return name; }
        }

        Stream TagLib.File.IFileAbstraction.ReadStream
        {
            get { return stream; }
        }

        Stream TagLib.File.IFileAbstraction.WriteStream
        {
            get { return stream; }
        }
    }
}
