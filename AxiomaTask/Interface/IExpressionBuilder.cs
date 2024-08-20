using AxiomaTask.ValueObjects;

namespace AxiomaTask.Interface
{
    public interface IExpressionBuilder
    {
        public Func<T, bool> GetExpression<T>(IList<ParseResult> filters);
    }
}
