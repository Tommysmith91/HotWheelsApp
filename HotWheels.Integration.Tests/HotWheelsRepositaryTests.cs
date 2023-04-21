

using NUnit.Framework.Internal.Commands;

namespace HotWheelsApp.Tests.Integration
{
    [TestFixture]
    public class HotWheelsRepositaryTests
    {
        private HotWheelsCollectionDbContext _dbContext;
        private HotWheelsRepositary _repositary;
        private Fixture _fixture;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<HotWheelsCollectionDbContext>()
                .UseInMemoryDatabase(databaseName: "HotWheelsDb")
                .Options;
            _dbContext = new HotWheelsCollectionDbContext(options);            
            await _dbContext.Database.EnsureCreatedAsync();

            _repositary = new HotWheelsRepositary(_dbContext);
            _fixture = new Fixture();
            
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            _dbContext.Dispose();
        }

        [Test]
        public async Task Add_ShouldAddHotWheelToDatabase()
        {
            HotWheel hotWheel = BuildHotWheelForTest();

            // Act
            var result = await _repositary.Add(hotWheel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(hotWheel.ModelName == result.ModelName);
            Assert.That(0 != result.Id);
            var hotWheelFromDb = await _dbContext.HotWheel.FindAsync(result.Id);
            Assert.IsNotNull(hotWheelFromDb);
            Assert.That(hotWheel.ModelName == hotWheelFromDb.ModelName);
        }

        private HotWheel BuildHotWheelForTest()
        {
            // Arrange            
            return _fixture.Build<HotWheel>().With(x => x.Id, 0).Create();
        }
        private IEnumerable<HotWheel> BuildManyHotWheelsForTest()
        {
            return _fixture.Build<HotWheel>().With(x => x.Id, 0).CreateMany();
        }
        [Test]
        public async Task Delete_ShouldDeleteHotWheelFromDatabase()
        {
            // Arrange
            var hotWheel = BuildHotWheelForTest();
            await _repositary.Add(hotWheel);

            // Act
            await _repositary.Delete(hotWheel);

            // Assert
            var hotWheelFromDb = await _dbContext.HotWheel.FindAsync(hotWheel.Id);
            Assert.IsNull(hotWheelFromDb);
        }

        [Test]
        public async Task Get_ShouldReturnHotWheelFromDatabase()
        {
            // Arrange
            var hotWheel = BuildHotWheelForTest();
            await _repositary.Add(hotWheel);

            // Act
            var result = await _repositary.Get(hotWheel.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(hotWheel.ModelName == result.ModelName);
            Assert.That(hotWheel.Id == result.Id);
        }

        [Test]
        public async Task GetAll_ShouldReturnAllHotWheelsFromDatabase()
        {
            // Arrange
            var hotWheels = BuildManyHotWheelsForTest().ToList();


            await _dbContext.HotWheel.AddRangeAsync(hotWheels);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repositary.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(hotWheels.Count == result.Count());
            Assert.IsTrue(hotWheels.All(h => result.Any(r => r.ModelName == h.ModelName)));
        }

        [Test]
        public async Task Put_ShouldUpdateExistingDatabaseEntrys()
        {
            // Arrange
            var hotWheel = BuildHotWheelForTest();         
            
            await _dbContext.HotWheel.AddAsync(hotWheel);
            await _dbContext.SaveChangesAsync();

            var IdAfterAdd = hotWheel.Id;

            hotWheel.ModelName = "Test Hot Wheel After Put";

            // Act
            await _repositary.Put(hotWheel);
            // Assert            
            Assert.That(hotWheel.ModelName == "Test Hot Wheel After Put");
            Assert.That(IdAfterAdd == hotWheel.Id);
            
        }
    }
}