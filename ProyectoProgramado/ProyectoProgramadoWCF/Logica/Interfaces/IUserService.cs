using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFproyecto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<Usuario> buscarUsuarios();

        [OperationContract]
        Usuario buscarUsuario(int IdUser);

    }
}
