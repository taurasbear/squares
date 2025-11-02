using AutoMapper;
using Squares.Application.Features.PointFeatures.CreatePoint;
using Squares.Application.Features.PointSetFeatures.CreatePointSet;
using Squares.Application.Models;
using Squares.Domain.Entities;

namespace Squares.Application.Mappings;

public class PointMappings : Profile
{
    public PointMappings()
    {
        CreateMap<CreatePointCommand, Point>();

        CreateMap<CreatePointSetCommand.Point, Point>();

        CreateMap<Point, PointValue>();
    }
}