using SMS.DTOS.EnrollmentDtos;
using SMS.Models;
using SMS.Repositorys;
using StudentManagementSystem.Services.Interfaces;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repository;

    public EnrollmentService(
        IEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateEnrollmentAsync(
        CreateEnrollmentRequestDTO dto)
    {
        var enrollment = new Enrollment
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId,
            AcademicYear = dto.AcademicYear,
            Semester = dto.Semester
        };

        await _repository.CreateAsync(enrollment);
    }

    public async Task<List<EnrollmentResponseDTO>>
    GetStudentEnrollmentsAsync(int studentId)
    {
        var enrollments =
            await _repository.GetStudentEnrollmentsAsync(studentId);

        return enrollments.Select(x => new EnrollmentResponseDTO
        {
            EnrollmentId = x.EnrollmentId,
            StudentId = x.StudentId,
            CourseId = x.CourseId,
            AcademicYear = x.AcademicYear,
            Semester = x.Semester,
            Status = x.Status
        }).ToList();
    }

    public async Task<List<EnrollmentResponseDTO>>
        GetCourseEnrollmentsAsync(int courseId)
    {
        var enrollments =
            await _repository.GetCourseEnrollmentsAsync(courseId);

        return enrollments.Select(x => new EnrollmentResponseDTO
        {
            EnrollmentId = x.EnrollmentId,
            StudentId = x.StudentId,
            CourseId = x.CourseId,
            AcademicYear = x.AcademicYear,
            Semester = x.Semester,
            Status = x.Status
        }).ToList();
    }
}
