using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using leave_management.LeaveRequestProject.Persistence.Contracts;
using leave_management.LeaveRequestProject.Persistence.Repositories;
using leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveRequestProject.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LeaveManagementDbContext>(options => 
        {
            var connectionString = configuration.GetValue<string>("SqlServer2017ConnectionString");
            var userID = configuration.GetValue<string>("SqlServer2017UserID");
            var dbPassword = configuration.GetValue<string>("SqlServer2017Password");

            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.UserID = userID;
            builder.Password = dbPassword; // dotnet user-secrets set "DbPassword" "***value***"
            options.UseSqlServer(builder.ConnectionString);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}