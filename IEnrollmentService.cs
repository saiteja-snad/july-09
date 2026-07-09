using SMS.DTOS.EnrollmentDtos;

namespace StudentManagementSystem.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task CreateEnrollmentAsync(
            CreateEnrollmentRequestDTO dto);

        Task<List<EnrollmentResponseDTO>>
            GetStudentEnrollmentsAsync(
            int studentId);

        Task<List<EnrollmentResponseDTO>>
            GetCourseEnrollmentsAsync(
            int courseId);
    }
}