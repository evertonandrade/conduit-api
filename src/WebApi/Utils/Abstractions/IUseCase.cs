namespace Conduit.Utils.Abstractions;

public interface IUseCase<TInput, TOutput>
{
    TOutput Execute(TInput input);
}

public interface IUseCaseAsync<TInput, TOutput>
{
    Task<TOutput> ExecuteAsync(TInput input);
}
