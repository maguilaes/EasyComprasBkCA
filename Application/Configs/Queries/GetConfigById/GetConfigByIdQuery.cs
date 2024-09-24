using Application.Ciudades.Queries.GetCiudades;
using MediatR;

namespace Application.Configs.Queries.GetConfigById
{
    public class GetConfigByIdQuery : IRequest<ConfigVM>
    {
        public int ConfigId { get; set; }
    }
}
