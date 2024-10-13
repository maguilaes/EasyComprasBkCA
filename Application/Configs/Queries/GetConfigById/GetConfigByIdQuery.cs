using Application.Configs.Queries.GetConfigs;
using MediatR;

namespace Application.Configs.Queries.GetConfigById
{
    public class GetConfigByIdQuery : IRequest<ConfigVM>
    {
        public int ConfigId { get; set; }
    }
}
