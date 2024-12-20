using AutoMapper;
using LibraryDAL.Entities;
using LibraryServices.Models;
using System.Xml.Linq;
using static LibraryServices.Models.BookViewModel;

namespace LibraryServices
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>()
                        .ForMember(dest => dest.Content, opt => opt.ConvertUsing(new XmlToChapterListConverter(), src => src.Content)); 
            CreateMap<BookViewModel, Book>();
            CreateMap<Book, BookPreviewModel>();
            CreateMap<BookPreviewModel, Book>();

        }
        private class XmlToChapterListConverter : IValueConverter<string, List<Chapter>>
        {
            public List<Chapter> Convert(string source, ResolutionContext context)
            {
                var content = new List<Chapter>();
                var xDoc = XDocument.Parse(source);
                foreach (var element in xDoc.Descendants("Chapter"))
                {
                    var chapter = new Chapter
                    {
                        Number = int.Parse(element.Element("Number")?.Value),
                        Title = element.Element("Title")?.Value,
                        Page = int.Parse(element.Element("Page")?.Value),
                    };
                    content.Add(chapter);
                }
                return content;
            }
        }
    }
}
