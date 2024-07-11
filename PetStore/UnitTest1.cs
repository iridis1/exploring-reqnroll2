namespace PetStore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task AddPetTest()
        {
            // Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://petstore.swagger.io/");
            var client = new PetStore.swaggerClient(httpClient);
            var pet = new Pet
            {
                Id = 1111119,
                Name = "Oliver",
                Status = PetStatus.Available,
                Tags = [new Tag { Name = "Cat" }, new Tag { Name = "Black" }]
            };

            // Act
            await client.AddPetAsync(pet);

            // Assert
            var createdPet = await client.GetPetByIdAsync(pet.Id.Value);

            Assert.IsNotNull(createdPet);
            Assert.AreEqual(createdPet.Name, pet.Name);
            Assert.AreEqual(createdPet.Status, pet.Status);
            Assert.AreEqual(createdPet.Tags.Count, pet.Tags.Count);
            Assert.AreEqual(createdPet.Tags.First().Name, pet.Tags.First().Name);
        }
    }
}