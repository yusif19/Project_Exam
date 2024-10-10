using Azure.Core;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Exam.DeleteExam;
using Exam.Application.Features.Commands.Exam.GetAllExam;
using Exam.Application.Features.Commands.Exam.GetByIdExam;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Application.Features.Commands.Student.CreateStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Exam.MVC.Controllers
{
    public class ExamController : Controller
    {
        readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(GetAllExamCommandRequest request)
        {
            GetAllExamCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Create()
        {
            var LessonsAndStudents = await _mediator.Send(new GetAllLessonAndStudentCommandRequest());
            ViewBag.Lessons = LessonsAndStudents.Lessons;
            ViewBag.Students = LessonsAndStudents.Students;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                var LessonsAndStudents = await _mediator.Send(new GetAllLessonAndStudentCommandRequest());
                ViewBag.Lessons = LessonsAndStudents.Lessons;
                ViewBag.Students = LessonsAndStudents.Students;
                return View(request);
            }
            CreateExamCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "exam");
            }

            return View(request);
        }
        public async Task<IActionResult> Update(int id)
        {
            var examData = await _mediator.Send(new GetByIdExamCommandRequest { Id = id });

            if (examData == null)
            {
                return NotFound();
            }

            
            ViewBag.Lessons = examData.Lessons;
            ViewBag.Students = examData.Students;

            return View(examData.Exam);


        }
        [HttpPost]
        public async Task<IActionResult> Update(ExamDTOv2 dto)
        {
         

            UpdateExamCommandRequest request = new();
            request.Exam = dto;
            UpdateExamCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "exam");
            }

            return View(request);
        }
        public async Task<IActionResult> Details(GetByIdExamCommandRequest request)
        {
            GetByIdExamCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Delete(DeleteExamCommandRequest request)
        {
            DeleteExamCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("index");
        }
    }
}
