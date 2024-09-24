using MediatR;

namespace Application.Configs.Queries.GetConfigs
{
    public class GetConfigQuery : IRequest<List<ConfigVM>>
    {
    }
}
