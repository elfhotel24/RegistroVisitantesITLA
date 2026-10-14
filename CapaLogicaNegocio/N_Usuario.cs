using CapaDatos;
using System.Collections.Generic;

public class N_Usuario
{
    private D_Usuarios d_Usuarios = new D_Usuarios();

    // Insertar usuario
    public void insertUsuarioN(E_Usuarios e_Usuario)
    {
        d_Usuarios.InsertUsuario(e_Usuario);
    }

    // Actualizar usuario
    public void updateUsuarioN(E_Usuarios e_Usuario)
    {
        d_Usuarios.UpdateUsuario(e_Usuario);
    }

    // Eliminar Usuario
    public void deleteusuarioN(E_Usuarios e_Usuario)
    {
        d_Usuarios.DeleteUsuario(e_Usuario.CodUsuario); // Aquí pasas solo el código del usuario
    }

    // Listar usuarios por nombre
    public List<E_Usuarios> listarUsPornombreN(string buscar)
    {
        return d_Usuarios.ListarUsPorNombre(buscar);
    }

    // Listar usuarios por código
    public List<E_Usuarios> listarUsPorcodigoN(string buscar)
    {
        return d_Usuarios.ListarUsPorCodigo(buscar);
    }

    // Confirmar si el usuario está en la base de datos y autenticarlo
    public E_Usuarios usuarioLoginN(string codigoUsuario, string userPassword)
    {
        return d_Usuarios.UsuarioLogin(codigoUsuario, userPassword);
    }
}
