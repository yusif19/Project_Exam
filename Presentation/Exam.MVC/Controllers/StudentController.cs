using Azure.Core;
using Student.Application.Features.Commands.Student.UpdateStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.Application.Features.Commands.Student.CreateStudent;
using Exam.Application.Features.Commands.Exam.GetAllExam;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Student.UpdateStudent;
using Exam.Application.Features.Commands.Student.DeleteStudent;
using Exam.Application.Features.Commands.Exam.GetByIdExam;

namespace Student.MVC.Controllers
{
    public class StudentController : Controller
    {
        readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(GetAllStudentCommandRequest request)
        {
            GetAllStudentCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            CreateStudentCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "student");
            }

            return View(request);
        }
        public async Task<IActionResult> Update(int id)
        {
            var StudentData = await _mediator.Send(new GetByIdStudentCommandRequest { Id = id });

            if (StudentData == null)
            {
                return NotFound();
            }
            return View(StudentData.Student);


        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            UpdateStudentCommandRequest request = new();
            request.Student = dto;
            UpdateStudentCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return RedirectToAction("Index", "student");
            }

            return View(request);
        }
        public async Task<IActionResult> Details(GetByIdStudentCommandRequest request)
        {
            GetByIdStudentCommandResponse response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Delete(DeleteStudentCommandRequest request)
        {
            DeleteStudentCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("index");
        }
    }
}
