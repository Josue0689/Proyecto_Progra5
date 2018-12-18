using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProyectoProgramadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProyectoProgramandoWCF
    {
        [OperationContract]
        string GetData(int value);
        List<Usuario> GetUsuarios();
        Usuario GetUsuarioPorID(int id);
        void DeleteUsuario(int id);
        void AgregarUsuario(string Nombre, string Apellido, string email, string telefono, string usua, string contrasena, int IdTipoUsuario);
        void ActualizarUsuario(int id, string Nombre, string Apellido, string email, string telefono, string usua, string contrasena, int IdTipoUsuario);
             
        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "ProyectoProgramadoWCF.ContractType".
    [DataContract]
    public class Usuarios
    {
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Usuario1 { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public string IdTipoUsuario { get; set; }
    }
}
