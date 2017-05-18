using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace cyoaCreator
{
    class OwinLogger : OwinMiddleware
    {

        public OwinLogger(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var msg = $"Received request ({context.Request.Uri})";
            Console.WriteLine(msg);
            await Next.Invoke(context);
        }
    }
}
