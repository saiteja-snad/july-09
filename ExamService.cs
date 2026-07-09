using SMS.DTOS.Exam_ResultDtos;
using SMS.Models;
using SMS.Repositorys;
using StudentManagementSystem.Services.Interfaces;

public class ExamService : IExamService
{
    private readonly IExamRepository _repository;

    public ExamService(IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateExamAsync(
        CreateExamRequestDTO dto)
    {
        var exam = new Exam
        {
            ExamName = dto.ExamName,
            CourseId = dto.CourseId,
            ExamDate = DateOnly.FromDateTime(dto.ExamDate),
            TotalMarks = dto.TotalMarks
        };

        await _repository.CreateAsync(exam);
    }
}