using System;
namespace TestJournal.Lib
{
    public static class RequestExtensions
    {
        public static HttpItemsWrapper ToItemsWrapper(this HttpContextBase context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), $"RequestContext is null when trying to access through request base");
            }

            return new HttpItemsWrapper(context);
        }
    }
}
