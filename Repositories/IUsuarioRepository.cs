namespace TaskWeb.Repositories;

using TaskWeb.Models;

public interface IUsuarioRepository
{
    Usuario Login(LoginViewModel model);
}