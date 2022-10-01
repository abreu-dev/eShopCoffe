using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Domain.Repositories.Interfaces;

namespace eShopCoffe.Catalog.Infra.Data.Seed
{
    public static class ProductSeed
    {
        public static readonly IEnumerable<Guid> ProductIdList = new List<Guid>()
        {
            Guid.Parse("d985e1c9-cd07-4fcc-b380-f11acb64adec"),
            Guid.Parse("1be16118-0ea7-4097-bfc6-fe3425e8c69b"),
            Guid.Parse("c2ce9ab4-b111-4b9f-9969-95670e69baa4"),
            Guid.Parse("a0e3420c-2e8a-4dd5-ac31-d7da372c71bd"),
            Guid.Parse("08822b8a-97f9-44df-b86e-2df98163092b"),
            Guid.Parse("f4a5b6f9-5f23-4bd1-913f-cafc8cc73306"),
            Guid.Parse("20d94e36-ea2f-4dfe-bf20-df3e7f0ba776"),
            Guid.Parse("2632cd9a-fd37-44c6-8b3f-e47f5d67d17c"),
            Guid.Parse("be7d4cbd-d167-46c9-b55f-7fe1357f39f7"),
            Guid.Parse("886d2923-1409-4f08-9e29-7500337c063b"),
        };
        public static readonly IEnumerable<string> ProductNameList = new List<string>()
        {
            "Café, Torrado em Grãos, Espresso Gourmet, Profissional, 1kg, 3 Corações",
            "Café em cápsulas América Gourmet",
            "Café Gourmet Espresso Baggio 250g",
            "Café Torrado e Moído, Starbucks, Pike Place Roast, 250g",
            "Baggio Café Bourbon Espresso Grão 500g",
            "Café Moído Clássico Orfeu 250g",
            "Café Santa Monica Premium Moído 500G",
            "Café Expresso Especial em Grãos - 1kg",
            "Café Torrado e Moído, Starbucks, Caffè Verona, 250g",
            "Moedor de café, Perfect coffee, 160W, Preto, 220v, Philco",
        };
        public static readonly IEnumerable<string> ProductDescriptionList = new List<string>()
        {
            "Café torrado em grão 3 Corações Espresso Gourmet Linha Profissional 1kg",
            "O Café em Cápsulas América Gourmet é uma combinação de grãos refinados 100% arábica; desenvolvido para atender aos paladares mais exigentes, é um café encorpado, com notas achocolatadas e aroma envolvente.",
            "O baggio café gourmet espresso é um café especialmente desenvolvido para paladares mais exigentes. Levemente adocicado, com aroma florado e traços frutados, possui um sabor único pronunciado, em um nível muito baixo de amargor. A embalagem pode variar.",
            "O pike place roast é, ao mesmo tempo, uma celebração da nossa orgulhosa história no mercado e uma sincera homenagem aos nossos exigentes clientes. Criamos este blend para satisfazer uma ampla variedade de gostos. Quer você o prefira puro ou complementado com leite e açúcar, nós prometemos um café ousado e gratificante que é rico em sabor, mas é balanceado o suficiente para se tomar todos os s.",
            "O Baggio Café Gourmet Bourbon é um café gourmet artesanal especial. Torrado artesanalmente, possui um paladar definido, com acidez sutil, para apreciadores desta variedade. Apresenta notas gustativas marcantes, corpo e doçura muito presente.",
            "Orfeu Clássico é um café equilibrado de aroma complexo, com notas florais, frutadas e de caramelo. Apresenta doçura elevada, corpo aveludado e acidez equilibrada com finalização persistente e prazerosa.",
            "Um café de categoria superior com a mais alta qualidade do mercado. Café Moído. Café Superior. Baixo Acidez",
            "Café Expresso Especial em Grãos - 1kg",
            "O café Verona é um sedutor blend de grãos da américa latina e da indonésia, com um toque suave de italian. roast conferindo intensidade, alma e doçura. Esta mistura deliciosa combina tão bem com chocolate que se tornou um favorito no dos namorados – para nós, é o café que mais tem a ver com romance. Bella, bella. P.s.: quem gosta de literatura deve conhecer Verona como a cidade onde Shakespeare ambientou romeu e julieta. Embora a peça acabe em tragé, pode ter certeza de que todo copo deste café tem um final feliz. A embalagem pode variar",
            "Muito mais aroma e sabor: Prepare cafés muito mais saborosos triturando grãos selecionados, obtendo mais pureza e qualidade",
        };
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "<Pending>")]
        public static readonly IEnumerable<string> ProductImageUrlList = new List<string>()
        {
            "https://m.media-amazon.com/images/I/61Y+CdkhZOL._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/5188FPMo29L._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/41FaNJshqUL._AC_SX425_.jpg",
            "https://m.media-amazon.com/images/I/714lqCq3YzL._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/61AxNk5geZL._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/51Z6mz0LmSL._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/51E6MDe6VDS._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/51A0pKR3xKL._AC_SX679_.jpg",
            "https://m.media-amazon.com/images/I/71eW3o126ZL._AC_SY679_.jpg",
            "https://m.media-amazon.com/images/I/71uyuXboGeL._AC_SX679_.jpg",

        };
        public static readonly IEnumerable<int> ProductQuantityAvailableList = new List<int>()
        {
            100,
            76,
            43,
            5,
            187,
            23,
            89,
            0,
            56,
            1
        };
        public static readonly IEnumerable<decimal> ProductCurrencyValueList = new List<decimal>()
        {
            57.14M,
            19.71M,
            30.23M,
            29.39M,
            44.82M,
            22.76M,
            36.26M,
            67.00M,
            27.23M,
            149.99M
        };
        public static string ProductCurrencyCode => "BRL";

        public static void SeedData(IRepository repository)
        {
            var existingProducts = repository.Query<ProductData>()
                .Where(x => ProductIdList.Contains(x.Id));

            if (existingProducts.Count() == ProductIdList.Count()) return;

            for (var index = 0; index < ProductIdList.Count(); index++)
            {
                if (existingProducts.Any(x => x.Id == ProductIdList.ElementAt(index))) continue;

                repository.Add(new ProductData()
                {
                    Id = ProductIdList.ElementAt(index),
                    Name = ProductNameList.ElementAt(index),
                    Description = ProductDescriptionList.ElementAt(index),
                    ImageUrl = ProductImageUrlList.ElementAt(index),
                    QuantityAvailable = ProductQuantityAvailableList.ElementAt(index),
                    CurrencyValue = ProductCurrencyValueList.ElementAt(index),
                    CurrencyCode = ProductCurrencyCode
                });
            }

            repository.UnitOfWork.Complete();
        }
    }
}
