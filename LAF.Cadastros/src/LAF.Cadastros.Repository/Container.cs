using Dapper.FluentMap;
using LAF.Cadastros.Repository.Mappings;

namespace LAF.Cadastros.Repository
{
    public static class Container        
    {
        public static void RegistrarMapeamentosDapper()
        {
            FluentMapper.Initialize(configurar =>
            {
                configurar.AddMap(new FornecedorMap());
            });
        }
    }
}
