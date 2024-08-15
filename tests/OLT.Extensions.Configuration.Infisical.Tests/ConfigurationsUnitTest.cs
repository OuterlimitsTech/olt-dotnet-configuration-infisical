using Microsoft.Extensions.Configuration;
using Moq;

namespace OLT.Extensions.Configuration.Infisical.Tests
{
    public class ConfigurationsUnitTest
    {
        [Fact]
        public void TestOptions()
        {
            var configRoot = BuildMockOptions();

            var builder = new Mock<IConfigurationBuilder>();
            builder.Setup(b => b.Build()).Returns(configRoot);

            var options = BuildOptions(builder.Object);
            builder.Object.AddInfisical(options);

            var configSection = builder.Object.Build().GetSection("Infisical");
            Assert.Multiple(() =>
            {                
                Assert.Equal(options.ClientId, configSection["ClientId"]);
                Assert.Equal(options.ClientSecret, configSection["ClientSecret"]);
                Assert.Equal(options.SiteUrl, configSection["SiteUrl"]);
                Assert.Equal(options.ProjectId, configSection["ProjectId"]);
                Assert.Equal(options.Environment, configSection["Environment"]);
            });

        }

        private static InfisicalOptions BuildOptions(IConfigurationBuilder builder)
        {
            var config = builder.Build().GetRequiredSection("Infisical");


            return new InfisicalOptions
            {
                ClientId = config["ClientId"] ?? string.Empty,
                ClientSecret = config["ClientSecret"] ?? string.Empty,
                SiteUrl = config["SiteUrl"] ?? string.Empty,
                ProjectId = config["ProjectId"] ?? string.Empty,
                Environment = config["Environment"] ?? string.Empty,
            };
        }

        private static IConfigurationRoot BuildMockOptions()
        {
            var dict = new Dictionary<string, string?>
            {
                { "Infisical:ClientId", Faker.Identification.UkNhsNumber() },
                { "Infisical:ClientSecret", Faker.Identification.UsPassportNumber() },
                { "Infisical:SiteUrl", Faker.Internet.Url() },
                { "Infisical:ProjectId", Faker.Internet.UserName() },
                { "Infisical:Environment", Faker.Lorem.GetFirstWord() },
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(dict)
                .Build();
        }

    }
}