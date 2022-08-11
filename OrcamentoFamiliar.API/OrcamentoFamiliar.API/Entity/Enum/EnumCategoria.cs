using System.ComponentModel;

namespace OrcamentoFamiliar.API.Entity.Enum
{
    public enum EnumCategoria
    {
        [Description("Alimentacao")]
        Alimentacao,
        [Description("Saude")]
        Saude,
        [Description("Moradia")]
        Moradia,
        [Description("Transporte")]
        Transporte,
        [Description("Educacao")]
        Educacao,
        [Description("Lazer")]
        Lazer,
        [Description("Imprevistos")]
        Imprevistos,
        [Description("Outras")]
        Outras
    }
}
