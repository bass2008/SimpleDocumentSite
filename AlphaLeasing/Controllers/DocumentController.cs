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
        protected static ISessionFactory _sessionFactory = CreateSessionFactory();
        

        private readonly DocumentMapper _documentMapper;

        private readonly IRepository<Document> _documentRepository;

        private readonly IUnitOfWork _unitOfWork;

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString
                         (@"Server=localhost\SQLEXPRESS;Database=testDb;Trusted_Connection=True"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentsMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false))
                .BuildSessionFactory();
        }

        public DocumentController()
        {
            var session = _sessionFactory.OpenSession();
            var transaction = session.BeginTransaction();

            _documentRepository = new GenericRepository<Document>(session);

            _unitOfWork = new UnitOfWork(transaction);

            _documentMapper = new DocumentMapper();
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
