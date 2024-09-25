using MediatR;

namespace MMME.Common;

public interface IContract<out T> : IRequest<T>
{

}