using StoreManager.Domain;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "StoreManager.Domain";
        private const string ApplicationNamespace= "StoreManager.Application";
        private const string InfrastructureNamespace= "StoreManager.Infrastructure";
        private const string PresentationNamespace= "StoreManager.Presentation";
        private const string WebApiNamespace = "StoreManager.WebApi";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
        
        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(StoreManager.Application.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                DomainNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebApiNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
        
        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(StoreManager.Infrastructure.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                PresentationNamespace,
                WebApiNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
        
        [Fact]
        public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(StoreManager.Presentation.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                InfrastructureNamespace,
                WebApiNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
        
        [Fact]
        public void Controllers_Should_Not_HaveDependencyOnRepository()
        {
            // Arrange
            var assembly = typeof(StoreManager.Presentation.AssemblyReference).Assembly;

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .ShouldNot()
                .HaveDependencyOn("StoreManager.Infrastructure.Repositories")
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}