using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BibliotecaGames.Site
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void SessionStart(object sender, EventArgs e)
		{
			//TODO -> Método que faz a verificação se o usuário está autenticado e redireciona para a tela de Login
		}
    }
}