using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DpHomework.Data;
using NUnit.Framework;
using Moq;

namespace DpHomework.Business.UnitTests
{
    [TestFixture]
    public class IndividualServiceTests
    {
        private IIndividualService _individualServiceSut;

        [SetUp]
        public void SetUp()
        {

        }

        /// <summary>
        /// Basic example of a unit test.  This is not a great candidate though
        /// since there isn't much business logic yet to verify.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetIndividualsAsync_succeeds()
        {
            // Arrange
            var individuals = new List<Individual>()
            {
                new Individual()
                {
                    Id = 1,
                    FirstName = "Bob",
                    MiddleName = "Bob",
                    LastName = "Aran",
                    Email = "foo@bar.comx",
                    Address = new List<Address>()
                    {
                        new Address()
                        {
                            AddressLine1 = "123 easy st",
                            AddressLine2 = "Apt 5",
                            City = "Baltimore",
                            State = "MD",
                            Zip = "21250",
                            Id = 2,
                            IndividualId = 1
                        }
                    }

                }
            };

            var mockRepo = new Mock<IIndividualRepository>();
            mockRepo.Setup(x => x.GetIndividualsAsync()
            ).ReturnsAsync(individuals);
            _individualServiceSut = new IndividualService(mockRepo.Object);

            // Act
            var result = await _individualServiceSut.GetIndividualsAsync();

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
