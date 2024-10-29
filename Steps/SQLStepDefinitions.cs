using DotNet.Testcontainers.Builders;
using FluentAssertions;
using MySqlConnector;
using System.ComponentModel;
using TechTalk.SpecFlow;
using Testcontainers.MySql;

namespace IntroductionCSharp.Steps
{
    [Binding]
    public class SQLStepDefinitions
    {
        [Given(@"I have a running MySQL Container")]
        public void GivenIHaveARunningMySQLContainer()
        {
            var mySqlContainer = new MySqlBuilder()
              .WithImage("mysql:8.0")
              .WithUsername("standard_user")
              .WithPassword("secret_sauce")
              .WithExposedPort(3306)
              .WithPortBinding(3306, 3306)
              .WithDatabase("testing")
              .WithWaitStrategy(Wait.ForWindowsContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(3306)))
              .Build();

            Task.Run(() => mySqlContainer.StartAsync());
            Task.WaitAll();

        }

        [Then(@"the database should be accessible")]
        public void ThenTheDatabaseShouldBeAccessible()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "standard_user",
                Password = "secret_sauce",
                Database = "testing",
                Port = 3306
            };
            var connection = new MySqlConnection(builder.ConnectionString);
            Task.Run(() => connection.OpenAsync());
            connection.Database.Should().Be("testing");
        }
    }
}
