using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Aseguradora.BL.Data;

namespace AseguradoraAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configura el db context para usar una sola instancia por cada request -- patron singleton
            app.CreatePerOwinContext(AseguradoraContext.Create);
        }
    }
}
