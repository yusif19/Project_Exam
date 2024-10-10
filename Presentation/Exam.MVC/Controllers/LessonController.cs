using Azure.Core;
using Lesson.Application.Features.Commands.Lesson.UpdateLesson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.Application.Features.Commands.Lesson.CreateLesson;
using Exam.Application.Features.Commands.Exam.GetAllExam;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Lesson.UpdateLesson;
using Exam.Application.Features.Commands.Lesson.DeleteLesson;
using Exam.Application.Features.Commands.Exam.GetByIdExam;
using Exam.Application.Features.Commands.Exam.GetAllLesson;

namespace Lesson.MVC.Controllers
{
    public class LessonController : Controller
    {
        readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(GetAllLessonCommandRequest request)
        {
            GetAllLessonCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLessonCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            CreateLessonCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "lesson");
            }

            return View(request);
        }
        public async Task<IActionResult> Update(int id)
        {
            var LessonData = await _mediator.Send(new GetByIdLessonCommandRequest { Id = id });

            if (LessonData == null)
            {
                return NotFound();
            }
            return View(LessonData.Lesson);


        }
        [HttpPost]
        public async Task<IActionResult> Update(LessonDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            UpdateLessonCommandRequest request = new();
            request.Lesson = dto;
            UpdateLessonCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "lesson");
            }

            return View(request);
        }
        public async Task<IActionResult> Details(GetByIdLessonCommandRequest request)
        {
            GetByIdLessonCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Delete(DeleteLessonCommandRequest request)
        {
            DeleteLessonCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("index");
        }
    }
}
