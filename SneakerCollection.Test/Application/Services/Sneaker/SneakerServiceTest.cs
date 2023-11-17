using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Services.Sneaker;
using Entities = SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using NUnit.Framework;

namespace SneakerCollection.Test.Application.Services.Sneaker
{
	public class SneakerServiceTest
    {
        private Mock<ISneakerRepository> _sneakerRepository;
        private SneakerService _sneakerService;

        [SetUp]
        public void SetUp()
        {
            _sneakerRepository = new Mock<ISneakerRepository>();
            _sneakerService = new SneakerService(_sneakerRepository.Object);
        }

        [Test]
        public async Task GetSneakerById_ShouldReturnSneaker_WhenFoundAnExistingSneaker()
        {
            //Given
            var sneakerId = SneakerId.Create(Guid.NewGuid());
            var userId = UserId.Create(Guid.NewGuid());


            //When
            var sneaker = Entities.Sneaker.Create(
                "Air Jordan",
                "Nike",
                250,
                40,
                2018,
                4,
                userId);
            _sneakerRepository.Setup(x => x.GetSneakerById(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(sneaker);

            //Then
            var result = await _sneakerService.GetSneakerById(sneakerId, userId);
            Assert.That(sneaker.Name, Is.EqualTo(result.Name));
        }

        [Test]
        public async Task GetSneakerByUserId_ShouldReturnSneakerCollection_WhenFoundAnExistingSneaker()
        {
            //Given
            var userId = UserId.Create(Guid.NewGuid());
            var sneakerId = Guid.NewGuid();
            var sneakerCollection = new List<Entities.Sneaker>
            {
                Entities.Sneaker.Create(
                    "Air Jordan",
                    "Nike",
                    250,
                    40,
                    2018,
                    4,
                    userId)
            };

            //When
            _sneakerRepository.Setup(x => x.GetSneakerByUserId(It.IsAny<UserId>())).ReturnsAsync(sneakerCollection);

            //Then
            var result = await _sneakerService.GetSneakerByUserId(userId);
            Assert.That(sneakerCollection[0].Name, Is.EqualTo(result.sneakers[0].Name));
        }

        [Test]
        public async Task UpdateSneaker_ShouldReturnSuccess_WhenUpdateAnExistingSneaker()
        {
            //Given
            var userId = UserId.Create(Guid.NewGuid());
            var sneaker = Entities.Sneaker.Create(
                "Air Jordan",
                "Nike",
                250,
                40,
                2018,
                4,
                userId);

            //When
            _sneakerRepository.Setup(x => x.GetSneakerById(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(sneaker);
            _sneakerRepository.Setup(x => x.Update(It.IsAny<Entities.Sneaker>())).Callback(() =>
            {
                sneaker.Update(
                    "UPDATED",
                    "Nike",
                    250,
                    40,
                    2018,
                    4);
            });

            //Then
            await _sneakerService.UpdateSneaker(sneaker);
            Assert.That(sneaker.Name, Is.EqualTo("UPDATED"));
        }

        [Test]
        public async Task RemoveSneaker_ShouldReturnSuccess_WhenDeleteAnExistingSneaker()
        {
            //Given
            var sneakerId = SneakerId.CreateUnique();
            var userId = UserId.CreateUnique();

            //When
            _sneakerRepository.Setup(x => x.Delete(It.IsAny<SneakerId>(),It.IsAny<UserId>())).ReturnsAsync(true);

            //Then
            var response =  await _sneakerService.RemoveSneaker(sneakerId, userId   );
            Assert.True(response);
        }
    }
}

