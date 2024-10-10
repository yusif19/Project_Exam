using AutoMapper;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Domain.Entities;

namespace Exam.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Domain.Entities.Lesson, LessonDTO>().ReverseMap();
            CreateMap<Exam.Domain.Entities.Exam, ExamDTO>().ReverseMap();
            CreateMap<Exam.Domain.Entities.Exam, ExamDTOv2>().ReverseMap();
            CreateMap<Domain.Entities.Student, StudentDTO>().ReverseMap();
            CreateMap<CreateExamCommandRequest, Exam.Domain.Entities.Exam>().ReverseMap();
            CreateMap<UpdateExamCommandRequest, Exam.Domain.Entities.Exam>().ReverseMap();
            CreateMap<Domain.Entities.Student, StudentDTO>().ReverseMap();
            CreateMap<Domain.Entities.Lesson, LessonDTO>().ReverseMap();
        }
    }
}
