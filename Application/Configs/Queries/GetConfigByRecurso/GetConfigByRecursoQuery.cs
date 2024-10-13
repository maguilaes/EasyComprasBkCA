using Application.Configs.Queries.GetConfigs;
using MediatR;

namespace Application.Configs.Queries.GetConfigByRecurso
{
    public class GetConfigByRecursoQuery : IRequest<ConfigVM>
    {
        public string strRecursto { get; set; }
    }
}
