using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IUserRepository
{
    Task<StudentEntity?> GetStudent(Guid id);
    Task<TeacherEntity?> GetTeacher(Guid id);
}

internal sealed class UserRepository(HomeworkDbContext dbContext) : IUserRepository
{
    private readonly DbSet<StudentEntity> _students = dbContext.StudentEntities;
    private readonly DbSet<TeacherEntity> _teachers = dbContext.TeacherEntities;
    
    public Task<StudentEntity?> GetStudent(Guid id) 
        => _students.Where(stud => stud.Id == id).SingleOrDefaultAsync();

    public Task<TeacherEntity?> GetTeacher(Guid id)
        => _teachers.Where(teacher => teacher.Id == id).SingleOrDefaultAsync();
}