
using System.Linq.Expressions;

using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using TaskMenagment.Domain.Entities.ViewModels;



namespace TaskMenagment.Application.Abstraction.Services.ProgrammerServices
{
    public class ProgrammerService : IProgrammerService
    {
        private readonly IProgrammerRepository _repository;

        public ProgrammerService(IProgrammerRepository programmerRepository)
        {
            _repository = programmerRepository;
        }
        public async Task<ProgrammerViewModel> Create(ProgrammerDTO entity)
        {
            var programmer = new Programmer()
            {
                FullName = entity.FullName,
                About = entity.About,
                Password = entity.Password,
                Username = entity.Username,
                Field = entity.Field,
            };

            var viewModel = new ProgrammerViewModel()
            {
                FullName = programmer.FullName,
                Description = programmer.About,
                Field = programmer.Field,
            };
            var res = await _repository.Create(programmer);
            return viewModel;
        }

        public async Task<bool> Delete(Expression<Func<Programmer, bool>> expression)
        {
            var result = await _repository.Delete(expression);
            return result;
        }

        public async Task<List<ProgrammerViewModel>> GetAll()
        {
            var res = await _repository.GetAll();

            List<ProgrammerViewModel> temp = new List<ProgrammerViewModel>();
            foreach (var item in res)
            {
                var viewModel = new ProgrammerViewModel()
                {
                    FullName = item.FullName,
                    Description = item.About,
                    Field = item.Field,
                };
                temp.Add(viewModel);
            }
            return temp;
        }

        public async Task<ProgrammerViewModel> GetById(int id)
        {
            var res = await _repository.GetById(x => x.Id == id);
            var viewModel = new ProgrammerViewModel()
            {
                FullName = res.FullName,
                Description = res.About,
                Field = res.Field,
            };
            return viewModel;
        }

        public async Task<string> GetPdfPath()
        {

            var text = "";

            var getall = await _repository.GetAll();
            foreach (var user in getall.ToList())
            {
                text = text + $"{user.Id} | {user.FullName} | {user.About}\n";
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
                      .Text("All Programmers")
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

        public async Task<ProgrammerViewModel> Update(ProgrammerDTO entity, int id)
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
                var viewModel = new ProgrammerViewModel()
                {
                    FullName = temp.FullName,
                    Description = temp.About,
                    Field = temp.Field,
                };

                return viewModel;
            }
            return null;
        }

        
    }
}