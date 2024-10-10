﻿using Exam.Application.Features.Commands.Exam.GetAllLesson;
using Exam.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.CreateExam
{
    public class GetAllLessonCommandRequest : IRequest<GetAllLessonCommandResponse>
    {
       
    }
}
