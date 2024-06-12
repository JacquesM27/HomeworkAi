﻿using System.Collections.Concurrent;

namespace HomeworkAi.Core.DTO.Exercises;

public abstract class Exercise
{
    public ExerciseHeader Header { get; set; }
    
    public class ExerciseHeader
    {
        public string Title { get; set; }
        public string TaskDescription  { get; set; }
        public string Instruction { get; set; }
        public string Example { get; set; }
        public string SupportMaterial { get; set; }
    }
}