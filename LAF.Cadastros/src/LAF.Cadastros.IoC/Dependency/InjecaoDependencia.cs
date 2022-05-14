using LAF.Cadastros.Repository;

namespace LAF.Cadastros.IoC.Dependency
{
    public static class InjecaoDependencia
    {
        public static void Registra()
        {
            Container.RegistrarMapeamentosDapper();
        }
    }
}
