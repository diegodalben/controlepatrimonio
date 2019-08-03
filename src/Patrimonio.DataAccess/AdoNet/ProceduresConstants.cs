namespace Patrimonio.DataAccess.AdoNet
{
    public static class ProceduresConstants
    {
        // Marcas
        public const string Prc_Marca_Insert = "dbo.[prc_Marca_Insert]";
        public const string Prc_Marca_Update = "dbo.[prc_Marca_Update]";
        public const string Prc_Marca_Delete = "dbo.[prc_Marca_Delete]";
        public const string Prc_Marca_GetAll = "dbo.[prc_Marca_GetAll]";
        public const string Prc_Marca_GetById = "dbo.[prc_Marca_GetById]";

        // Patrimônio
        public const string Prc_Patrimonio_Insert = "dbo.[prc_Patrimonio_Insert]";
        public const string Prc_Patrimonio_Update = "dbo.[prc_Patrimonio_Update]";
        public const string Prc_Patrimonio_Delete = "dbo.[prc_Patrimonio_Delete]";
        public const string Prc_Patrimonio_GetAll = "dbo.[prc_Patrimonio_GetAll]";
        public const string Prc_Patrimonio_GetById = "dbo.[prc_Patrimonio_GetById]";
        public const string Prc_Patrimonio_GetByMarca = "dbo.[prc_Patrimonio_GetByMarca]";
    }
}