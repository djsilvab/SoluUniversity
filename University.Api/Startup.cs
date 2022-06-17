using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using University.Logic.Data;

namespace University.Api
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance per request
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}
