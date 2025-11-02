using AutoMapper;
using Squares.Application.Features.PointSetFeatures.GetSquares;
using Squares.Application.Models;

namespace Squares.Application.Mappings;

public class SquareMappings : Profile
{
    public SquareMappings()
    {
        CreateMap<Square, GetSquaresResponse>()
            .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.Points));
    }
}