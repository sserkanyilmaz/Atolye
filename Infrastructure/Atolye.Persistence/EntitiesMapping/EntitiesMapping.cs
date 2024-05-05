using Atolye.Application.Features.Base.DTOs;
using Mapster;
using Atolye.Domain.Entities;
using Atolye.Application.Features.Team.DTOs;

public static class EntitiesMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<Report, ReportDTO>.NewConfig().Map(dest => dest.ReportId, src => src.Id.ToString());
        TypeAdapterConfig<ConsumableInventory, ConsumableInventoryDTO>.NewConfig().Map(dest => dest.InventoryId, src => src.Id.ToString());
        TypeAdapterConfig<FixtureInventory, FixtureInventoryDTO>.NewConfig().Map(dest => dest.InventoryId, src => src.Id.ToString());
        TypeAdapterConfig<FixtureInformation, FixtureInformationDTO>.NewConfig().Map(dest => dest.FixtureInformationId, src => src.Id.ToString());
        TypeAdapterConfig<Image, BaseImageDTO>.NewConfig().Map(dest => dest.ImageId, src => src.Id.ToString());
        TypeAdapterConfig<BaseNew, BaseNewDTO>.NewConfig().Map(dest => dest.BaseNewId, src => src.Id.ToString());
        TypeAdapterConfig<Project, ProjectDTO>.NewConfig().Map(dest => dest.ProjectId, src => src.Id.ToString());
        TypeAdapterConfig<ActivityLog, ActivityLogDTO>.NewConfig().Map(dest => dest.ActivityLogId, src => src.Id.ToString());


    }
}