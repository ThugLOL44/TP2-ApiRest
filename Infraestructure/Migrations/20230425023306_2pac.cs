using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class _2pac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "https://imagenes.montevideo.com.uy/imgnoticias/202208/_W640_H364_80/812451.jpeg", "2 Tostadas, 1 dip de mostaza y ciboulette", "Dip de mostaza y ciboulette", 600, "Mezcla crema agria, mostaza dijon y amarilla. Agrega ciboulette picada, sal y pimienta al gusto. Revuelve para obtener una mezcla homogénea.", 1 },
                    { 2, "https://assets.unileversolutions.com/recipes-v2/239857.jpg", "Carne, Cebolla, Huevo, Masa casera, Tomate", "Empanada de carne", 320, "Se saltea la cebolla, luego se agrega la carne junto al tomate y se cocina por 10 minutos, se agregan especias y el huevo. Se arma la empanada y se repulga. Luego se cocinan hasta estar bien doradas.", 1 },
                    { 3, "https://i.blogs.es/1cf6bd/milanesa-napolitana-min/1366_2000.jpeg", "Milanesa, queso muzzarela, salsa de tomate y oregano", "Milanesa a la napolitana", 1400, "La milanesa se cubre con salsa de tomate, queso y oregano, y se hornea para que el queso se derrita", 2 },
                    { 4, "https://www.laylita.com/recetas/wp-content/uploads/Receta-del-choripan.jpg", "Chorizo, pan y salsa a eleccion", "Choripan", 1000, "se debe asar una salchicha de chorizo en una parrilla o sartén. Luego, se coloca la salchicha en un pan tipo baguette y se le agrega chimichurri u otras salsas al gusto.", 2 },
                    { 5, "https://www.clarin.com/img/2018/06/19/HJS8-kvW7_1256x620__2.jpg", "Ñoquis de papa, salsa filetto", "Ñoquis de papa", 1200, "Se cocinan los ñoquis por alrededor de 3 o 4 minutos y luego se le agrega la salsa", 3 },
                    { 6, "https://media-cdn.tripadvisor.com/media/photo-s/1a/6b/34/b7/sorrentinos-de-jamon.jpg", "Jamon, queso y riccota, masa de sorrentinos", "Sorrentinos de jamón y queso", 1800, "Se rellena la masa con jamon, queso y ricotta. Luego se cocina por 8-10 minutos aprox ", 3 },
                    { 7, "https://www.gastrotradicional.com/wp-content/uploads/2018/09/como-preparar-asado-a-la-parilla.jpg", "Diferentes cortes de carne, como tira de asado, vacío, matambre, chorizo y morcilla", "Asado", 2000, "Sazonados con sal, los cortes de carne se cocinan a fuego lento en la parrilla", 4 },
                    { 8, "https://www.comedera.com/wp-content/uploads/2022/06/bife-de-chorizo.jpg", "Bife de chorizo", "Bife de Chorizo", 600, "El bife de chorizo se cocina a la parrilla, a fuego medio, para que quede jugoso y tierno", 4 },
                    { 9, "https://rankea.com.ar/wp-content/uploads/2019/05/pizza-muzzarella.jpg", "Harina, agua, sal, aceite, Salsa de tomate, Mozzarella", "Pizza de mozzarella", 1500, "Se prepara la masa de pizza. Se deje elevar. Se estira la masa en las pizzeras, luego se agrega la salsa, metemos al horno unos minutos. Luego se agrega la mozzarella y se cocina al horno a 220 °C durante 15 min", 5 },
                    { 10, "https://resizer.glanacion.com/resizer/TZzg6LYEvQpEof1TshBXqEspVYE=/768x0/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/X6FSNA3BJBF7XB36HEECQGYS7Y.jpg", "Harina, agua, sal, aceite, cebolla, jamon y mozzarella", "Fuggazzeta rellena", 3400, "Preparar la masa, armar la fugazzetta y hornear la fugazzetta", 5 },
                    { 11, "https://www.allrecipes.com/thmb/4tHUrnO9xe0CBPli8Tmjm4ydaq8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/8338654_Torta-de-Milanesa-de-Pollo-4x3-1-739b7387043144f6b848abcc872be181.jpg", "Milanesa de pollo, pan ", "Sandwich de milanesa de pollo", 1000, "Se cocina la milanesa y luego se le agrega el pan", 6 },
                    { 12, "https://d3ugyf2ht6aenh.cloudfront.net/stores/288/056/products/simples31-743189307744419c7d15119397744217-640-0.jpg", "Jamon, Queso, Capas de pan de miga blanco sin corteza", "Sandwich de miga de jamon y queso", 400, "Se rellena el pan con jamon y queso", 6 },
                    { 13, "https://www.cocinacaserayfacil.net/wp-content/uploads/2018/06/Ensalada-cesar.jpg", "Lechuga romana, pollo a la parrilla, crutones, queso parmesano rallado y aderezo César ", "Ensalada Caesar", 1200, "La ensalada Caesar se prepara mezclando lechuga romana fresca, croutones de pan tostado, queso parmesano rallado y una salsa especial hecha con aceite de oliva, yema de huevo, anchoas, ajo y mostaza.", 7 },
                    { 14, "https://www.hogarmania.com/archivos/201606/5800-2-ensalada-de-rucula-cherrys-y-queso-xl-1280x720x80xX.jpg", "Base de rúcula, tomates cherry, láminas de parmesano, aceite de oliva y aceto balsámico", "Ensalada de rúcula", 1200, "Para preparar una ensalada de rúcula, lava y seca la rúcula, añade aceite de oliva y vinagre balsámico al gusto, y decora con queso parmesano y piñones tostados.", 7 },
                    { 15, "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg/320px-15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg", "Coca-Cola", "Coca-Cola", 600, "La preparación de Coca-Cola implica mezclar agua carbonatada con jarabe de sabor y colorantes caramelo. Luego, se agrega ácido fosfórico y se embotella para su distribución.", 8 },
                    { 16, "https://www.distribuidoraniki.com.ar/database/articulos/fotos/346/Fanta%20Naranja%20Retornable%20350cc%20vidrio%20ret__1.jpg", "Fanta", "Fanta", 600, "La preparación de Fanta implica mezclar agua carbonatada con jarabe de sabores y colorantes. La proporción exacta de ingredientes puede variar según la receta y el sabor deseado. Luego, se embotella y se distribuye para su consumo.", 8 },
                    { 17, "https://www.clarin.com/img/2020/08/18/PY22-FZSu_1256x620__2.jpg#1628113269253", "Cerveza Artesanal IPA", "Pinta de IPA", 1000, " implica la molienda de granos de malta, la maceración en agua caliente para obtener azúcares fermentables, la adición de lúpulo durante la ebullición, la fermentación con levadura y el embotellado o barrilado para la carbonatación.", 9 },
                    { 18, "https://d3ugyf2ht6aenh.cloudfront.net/stores/001/246/405/products/a-0511-a33b3f8f516d7f17ec15940544201315-640-0.jpg", "Cerveza Artesanal Honey", "Pinta de Honey", 1000, "La cerveza artesanal honey se prepara agregando miel durante el proceso de elaboración. La miel se añade en el momento de la cocción del mosto y luego se fermenta con levadura y otros ingredientes como lúpulo y malta", 9 },
                    { 19, "https://cocinerosargentinos.com/content/recipes/500x500/recipes.14669.jpeg", "Huevos, leche y azucar", "Flan Casero", 1200, "Para preparar el flan, se baten los huevos y se mezclan con la leche y el azúcar, y se cuece esta mezcla en un molde con caramelo líquido en baño María. Una vez que se ha enfriado y se ha solidificado, se desmolda y se sirve.", 10 },
                    { 20, "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2018/09/14170007/chocotorta-destacada.jpg", "Galletas de chocolate, dulce de leche, queso crema, cafe fuerte", "Chocotorta", 1500, "Preparar la crema, luego armar las capas y por ultimo refrigerar y decorar", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
