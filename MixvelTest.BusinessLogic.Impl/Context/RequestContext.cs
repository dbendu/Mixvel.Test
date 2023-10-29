namespace MixvelTest.BusinessLogic.Impl.Context;

internal class RequestContext
{
    private readonly DateTimeOffset _now = DateTimeOffset.Now;

    public DateTimeOffset Now => _now;
}