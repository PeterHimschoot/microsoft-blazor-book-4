internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        builder =>
                  builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
    });

    builder.Services
      .AddAuthentication("Bearer")
      .AddJwtBearer("Bearer", opt =>
      {
        // for development purposes, disable in production!
        opt.RequireHttpsMetadata = false; 
        opt.Authority = "https://localhost:5011";
        opt.Audience = "u2uApi";
      });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("CorsPolicy");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
  }
}