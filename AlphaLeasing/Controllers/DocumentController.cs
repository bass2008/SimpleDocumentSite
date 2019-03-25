using AlphaLeasing.Mapping;
using AlphaLeasing.Common.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using AlphaLeasing.DataAccess.Repository;
using AlphaLeasing.DataAccess.UnitOfWork;
using System;
using AlphaLeasing.ViewModels;
using AlphaLeasing.Common.Validation;

namespace AlphaLeasing.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {        
        private readonly IDocumentMapper _documentMapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentController(
            IDocumentMapper documentMapper,
            IDocumentRepository documentRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _documentRepository = documentRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _documentMapper = documentMapper;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        private const string userDirPath = "~/Files/";

        [HttpPost]
        public ActionResult Upload(DocumentViewModel upload)
        {
            if (upload != null)
            {
                if (string.IsNullOrEmpty(upload.Name) == false && upload.Name.Length >= DocumentValidation.NameLength)
                {
                    ModelState.AddModelError("Name", "Name is required");
                    return View("Add", upload);
                }

                // Сохранение файла на диск
                var ext = upload.Name.Contains(".") == false ?
                    System.IO.Path.GetExtension(upload.Files[0].FileName) :
                    string.Empty;

                var dirPath = Server.MapPath(userDirPath);
                var saveTo = dirPath + upload.Name + ext;
                var saveToRelative = userDirPath + upload.Name + ext;

                var dirExist = System.IO.Directory.Exists(dirPath);
                if (dirExist == false)
                {
                    System.IO.Directory.CreateDirectory(dirPath);
                }

                upload.Files[0].SaveAs(saveTo);

                // Сохранение файла в db
                var document = new Document
                {
                    Name = upload.Name + ext,
                    User = _userRepository.GetByLogin(User.Identity.Name),
                    Date = DateTime.Now.ToShortDateString(),
                    Link = saveToRelative
                };

                _documentRepository.Add(document);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public FileResult Get(int id)
        {
            var upload = _documentRepository.Get(id);

            var mapped = _documentMapper.MapDocument(upload);

            // Сохранение файла на диск
            var dirPath = Server.MapPath(userDirPath);
            var saveTo = dirPath + upload.Name;
            
            var fileBytes = System.IO.File.ReadAllBytes(saveTo);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, upload.Name);
        }

        public ActionResult Index()
        {
            var list = _documentRepository.GetAll();
            
            var mapped = _documentMapper.MapDocuments(list);

            return Content(JsonConvert.SerializeObject(new { data = mapped }));
        }

    }
}
