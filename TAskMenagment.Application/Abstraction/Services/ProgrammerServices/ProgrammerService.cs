
using System.Linq.Expressions;

using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;



namespace TaskMenagment.Application.Abstraction.Services.ProgrammerServices
{
    public class ProgrammerService : IProgrammerService
    {
        private readonly IProgrammerRepository _repository;

        public ProgrammerService(IProgrammerRepository programmerRepository)
        {
            _repository = programmerRepository;
        }
        public async Task<Programmer> Create(ProgrammerDTO entity)
        {
            var programmer = new Programmer()
            {
                FullName = entity.FullName,
                About = entity.About,
                Password = entity.Password,
                Username = entity.Username,
                Field = entity.Field,
            };
            var res = await _repository.Create(programmer);
            return res;
        }

        public async Task<bool> Delete(Expression<Func<Programmer, bool>> expression)
        {
            var result = await _repository.Delete(expression);
            return result;
        }

        public async Task<IEnumerable<Programmer>> GetAll()
        {
            var res = await _repository.GetAll();
            return res;
        }

        public async Task<Programmer> GetById(int id)
        {
            var res = await _repository.GetById(x => x.Id == id);
            return res;
        }

        public async Task<string> GetPdfPath()
        {

            var text = "";

            var getall = await _repository.GetAll();
            foreach (var user in getall.ToList())
            {
                text = text + $"{user.Username} | {user.About}\n";
            }

            DirectoryInfo projectDirectoryInfo =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;

            var file = Guid.NewGuid().ToString();

            string pdfsFolder = Directory.CreateDirectory(
                 Path.Combine(projectDirectoryInfo.FullName, "pdfs")).FullName;

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                      .Text("Library Users")
                      .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                      .PaddingVertical(1, Unit.Centimetre)
                      .Column(x =>
                      {
                          x.Spacing(20);

                          x.Item().Text(text);
                      });

                    page.Footer()
                      .AlignCenter()
                      .Text(x =>
                      {
                          x.Span("Page ");
                          x.CurrentPageNumber();
                      });
                });
            })
            .GeneratePdf(Path.Combine(pdfsFolder, $"{file}.pdf"));
            return Path.Combine(pdfsFolder, $"{file}.pdf");
        }

        public async Task<Programmer> Update(ProgrammerDTO entity, int id)
        {
            var temp = await _repository.GetById(x => x.Id == id);

            if (temp != null)
            {
                temp.FullName = entity.FullName;
                temp.About = entity.About;
                temp.Password = entity.Password;
                temp.Username = entity.Username;
                temp.Field = entity.Field;
                var res = await _repository.Update(temp);
                return res;
            }
            return null;
        }
    }
}