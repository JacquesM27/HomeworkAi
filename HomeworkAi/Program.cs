using HomeworkAi.Core.Services;
using HomeworkAi.Core.Services.OpenAi;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiKey = builder.Configuration["gptApiKey"];
builder.Services.AddScoped<IOpenAIAPI>(serviceProvider => new OpenAIAPI(apiKey));
builder.Services.AddScoped<IOpenAiService, OpenAiService>();
builder.Services.AddScoped<IObjectSamplerService, ObjectSamplerService>();
builder.Services.AddScoped<IPromptFormatter, PromptFormatter>();
builder.Services.AddScoped<IExerciseFormatService, ExerciseFormatService>();

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