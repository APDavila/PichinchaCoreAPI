using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PichinchaCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProcedimientosAlmacenados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                   CREATE PROCEDURE dbo.PersonasInsertar
                   @id int OUTPUT,
                   @nombre nvarchar(100),
                   @genero nvarchar(10),
                   @edad nvarchar(2),
                   @identificacion nvarchar(13),
                   @direccion nvarchar(100),
                   @telefono nvarchar(15),
                   @activo bit
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   INSERT INTO Personas(nombre, genero, edad, identificacion, direccion, telefono, activo)
                   VALUES(@nombre, @genero, @edad,
                   @identificacion,@direccion, @telefono, @activo)

                   SELECT @id = SCOPE_IDENTITY()
                   END
             ");
             migrationBuilder.Sql(@"
                   CREATE PROCEDURE dbo.PersonasObtenerPorId
                   @id int                  
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   SELECT id, nombre, genero, edad, identificacion,direccion, telefono, activo
                   FROM Personas
                   WHERE Id = @id;
                   END
             ");
             migrationBuilder.Sql(@"
                   CREATE PROCEDURE dbo.PersonasObtenerIds                   
                   AS
                   BEGIN                   
                   SELECT Id

                   FROM Personas                   
                   END
             ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.PersonasInsertar");
            migrationBuilder.Sql("DROP PROCEDURE dbo.PersonasObtenerPorId");
            migrationBuilder.Sql("DROP PROCEDURE dbo.PersonasObtenerIds");
        }
    }
}
