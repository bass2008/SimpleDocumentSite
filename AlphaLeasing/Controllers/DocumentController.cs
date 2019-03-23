using AlphaLeasing.Mapping;
using AlphaLeasing.Common.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using AlphaLeasing.DataAccess.Mappings;
using NHibernate.Tool.hbm2ddl;
using AlphaLeasing.DataAccess.Repository;
using AlphaLeasing.DataAccess.UnitOfWork;
using System;

namespace AlphaLeasing.Controllers
{
    public class DocumentController : Controller
    {        
        private readonly IDocumentMapper _documentMapper;

        private readonly IRepository<Document> _documentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DocumentController(
            IDocumentMapper documentMapper,
            IRepository<Document> documentRepository,
            IUnitOfWork unitOfWork)
        {
            _documentRepository = documentRepository;
            _unitOfWork = unitOfWork;
            _documentMapper = documentMapper;
        }

        public ActionResult Add()
        {
            var document = new Document
            {
                Name = "New document",
                Author = "Sergey",
                Date = DateTime.Now.ToShortDateString()
            };

            _documentRepository.SaveOrUpdate(document);
            _unitOfWork.SaveChanges();

            return Content("Success");
        }

        public ActionResult Index()
        {
            var list = _documentRepository.GetAll();
            
            var mapped = _documentMapper.MapDocuments(list);

            return Content(JsonConvert.SerializeObject(new { data = mapped }));
        }

    }
}
