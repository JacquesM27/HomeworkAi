using HomeworkAi.Core.Services;
using HomeworkAi.OpenAi;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiKey = builder.Configuration["gptApiKey"];
builder.Services.AddScoped<IOpenAIAPI>(serviceProvider =>
{
    return new OpenAIAPI(apiKey);
});
builder.Services.AddScoped<IOpenAiService, OpenAiService>();
builder.Services.AddScoped<IObjectSamplerProvider, ObjectSamplerProvider>();
builder.Services.AddScoped<IExercisePromptFormatter, ExercisePromptFormatter>();
builder.Services.AddScoped<IExerciseFormatProvider, ExerciseFormatProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();