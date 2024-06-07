using Autofac;
using Autofac.Extensions.DependencyInjection;
using FootBall.Repository.Common;
using FootBall.Repository;
using FootBall.Service.Common;
using FootBall.Service;
using FootBall.API.NewFolder2;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Use Autofac as the DI container
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<FootBallService>().As<IFootBallService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<FootBallRepository>().As<IFootballRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
});
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