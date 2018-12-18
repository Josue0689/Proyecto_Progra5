using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFproyecto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UserService.svc o UserService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserService : IUserService
    {
        private UsuariosEntities dboUser = new UsuariosEntities();
        Usuario IUserService.buscarUsuario(int IdUser)
        {
            return dboUser.Usuario.Single(p => p.IdUser == IdUser);
        }

        List<Usuario> IUserService.buscarUsuarios()
        {
            return dboUser.Usuario.ToList();
        }
    }
}
