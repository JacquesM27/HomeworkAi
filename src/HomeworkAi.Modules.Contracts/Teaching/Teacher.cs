﻿namespace HomeworkAi.Modules.Contracts.Teaching;

public sealed class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public IEnumerable<Student> IndividualStudents { get; set; }
}