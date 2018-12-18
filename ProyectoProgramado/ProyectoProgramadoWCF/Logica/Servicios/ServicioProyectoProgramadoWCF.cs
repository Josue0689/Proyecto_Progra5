using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProyectoProgramadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioProyectoProgramadoWCF : IProyectoProgramandoWCF
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            ObjetosPerdidosEntities objPedidos = new ObjetosPerdidosEntities();
            var lista = from k in objPedidos.Usuario select k;
            foreach (var item in lista)
            {
                Usuario user = new Usuario();
                user.IdUser = item.IdUser;
                user.Nombre = item.Nombre;
                user.Apellido = item.Apellido;
                user.Email = item.Email;
                user.Telefono = item.Telefono;
                user.Usuario1 = item.Usuario1;
                user.Contraseña = item.Contraseña;
                user.IdTipoUsuario = item.IdTipoUsuario;
                listaUsuarios.Add(user);
            }
            return listaUsuarios;
        }

        public Usuario GetUsuarioPorID(int id)
        {
            ObjetosPerdidosEntities objPedidos = new ObjetosPerdidosEntities();
            var lista = from k in objPedidos.Usuario where k.IdUser==id select k;
            Usuario user = new Usuario();
            foreach (var item in lista)
            {
                user.IdUser = item.IdUser;
                user.Nombre = item.Nombre;
                user.Apellido = item.Apellido;
            }
            return user;
        }

        public void DeleteUsuario(int id)
        {
            ObjetosPerdidosEntities objPedidos = new ObjetosPerdidosEntities();
            Usuario user = new Usuario();
            user.IdUser = id;
            objPedidos.Entry(user).State = EntityState.delected;
            objPedidos.SaveChanges();
         }

        public void AgregarUsuario(string Nombre, string Apellido, string email, string telefono, string usua, string contrasena, int IdTipoUsuario)
        {
            ObjetosPerdidosEntities objetosPerdidos = new ObjetosPerdidosEntities();
            Usuario user = new Usuario();
            user.Nombre = Nombre;
            user.Apellido = Apellido;
            user.Email = email;
            user.Telefono = telefono;
            user.Usuario1 = usua;
            user.Contraseña = contrasena;
            user.IdTipoUsuario = IdTipoUsuario;
            objetosPerdidos.SaveChanges();
        }

        public void ActualizarUsuario(int id, string Nombre, string Apellido, string email, string telefono, string usua, string contrasena, int IdTipoUsuario)
        {
            ObjetosPerdidosEntities objetosPerdidos = new ObjetosPerdidosEntities();
            Usuario user = new Usuario();
            user.Nombre = Nombre;
            user.Apellido = Apellido;
            user.Email = email;
            user.Telefono = telefono;
            user.Usuario1 = usua;
            user.Contraseña = contrasena;
            user.IdTipoUsuario = IdTipoUsuario;
            objetosPerdidos.Entry(user).State = EntityState.Modified;
            objetosPerdidos.SaveChanges();
        }
    }
}
