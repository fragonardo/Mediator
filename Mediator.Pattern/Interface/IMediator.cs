namespace Mediator.Pattern.Interface
{
    public interface IMediator
    {
        void Register<TArg, TResult>(IHandler<TArg, TResult> handler) where TArg : IArgument<TResult> ;

        void Register<TArg>(IHandler<TArg> handler) where TArg : IArgument;


        TResult Dispatch<TArg, TResult>(TArg arg) where TArg : IArgument<TResult>;

        void Dispatch<TArg>(TArg arg) where TArg : IArgument;
    }
}
