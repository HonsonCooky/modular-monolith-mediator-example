using MediatR;

namespace MMME.Common;

public interface IContractHandler<in T, TV> : IRequestHandler<T, TV> where T : IRequest<TV>
{

}