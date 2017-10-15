using System;
namespace TestJournal.Lib
{
    public class HttpItemsWrapper
    {
        private bool _isNew;

        private readonly HttpContextBase _context;

        private static object synclock = new object();


        public HttpItemsWrapper(HttpContextBase request)
        {
            _isNew = true;
            _context = request;
        }

        public bool IsNew => _isNew;

        public static HttpItemsWrapper FromContext(HttpContextBase context)
        {
            if (context.Items.ContainsKey(ItemsConstants.ItemsWrapper))
            {
                var instance = (HttpItemsWrapper)context.Items[ItemsConstants.ItemsWrapper];
                instance._isNew = false;

                return instance;
            }
            else
            {
                var wrapper = new HttpItemsWrapper(context);

                try
                {
                    //    
                }
                catch(ArgumentException)
                {
                    lock(synclock)
                    {
                        try
                        {
                            if(!context.Items.ContainsKey((ItemsConstants.ItemsWrapper)))
                            {
                                context.Items.Add(ItemsConstants.ItemsWrapper, wrapper);
                            }    
                        }
                        catch(ArgumentException)
                        {
                            //
                        }
                    }
                }

                return wrapper;
            }
        }
    }
}
