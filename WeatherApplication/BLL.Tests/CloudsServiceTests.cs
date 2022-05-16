using Moq;
using Xunit;
using DAL.UOW;
using BLL.IServices;
using BLL.Services;
using ObjectLayer;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace BLL.Tests
{
    public class CloudsServiceTests
    {
        //Check GetAll
        [Fact]
        public async Task IsGetAllCloudsReturnsEverything()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow => uow.Clouds.GetAllAsync()).Returns(GetTestClouds());
            ICloudsService service = new CloudsService(mock.Object);

            //Act
            var result = await service.GetAllClouds();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Clouds>>(result);
            Assert.Equal(4, model.Count());
        }

        //Check FindCloudById
        [Fact]
        public async Task IsFindCloudByIdReturnsCurrentCloud()
        {
            //Arrange
            var list = await GetTestClouds();
            var expectedCloud = list.ToList().FirstOrDefault();
            var asd = Task.Run(() => list.AsEnumerable().FirstOrDefault());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow => uow.Clouds.FindByIdAsync(expectedCloud.CloudsId)).Returns(asd);
            ICloudsService service = new CloudsService(mock.Object);


            //Act
            var result = service.GetCloudById(expectedCloud.CloudsId);

            // Assert
            var viewResult = Assert.IsType<Clouds>(result.Result);
            var model = Assert.IsAssignableFrom<Clouds>(
                viewResult);
            Assert.Equal(expectedCloud.All, model.All);
            Assert.Equal(expectedCloud.CloudsId, model.CloudsId);
        }

        //Check AddCloud
        [Fact]
        public void IsAddCloudReturnsModelAndAddsCloud()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            Guid id = Guid.NewGuid();
            var cloud = new Clouds()
            {
                CloudsId = id,
                All = 10
            };
            var cl = Task.Run(() => cloud);
            mock.Setup(uow => uow.Clouds.CreateAsync(cloud)).Returns(cl);
            ICloudsService service = new CloudsService(mock.Object);

            //Act
            var result = service.CreateCloud(cloud);

            // Assert
            var viewResult = Assert.IsType<Clouds>(result.Result);
            var model = Assert.IsAssignableFrom<Clouds>(viewResult);
            Assert.NotNull(model.All);
            Assert.Equal(cloud.CloudsId, model.CloudsId);
        }

        //Check UpdateCloud
        [Fact]
        public async Task IsUpdateCityReturnsNewModel()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            var list = await GetTestClouds();
            var clouds = list.ToList().FirstOrDefault();
            var previousAll = clouds.All;
            clouds.All = 303;
            mock.Setup(uow => uow.Clouds.Update(clouds));
            ICloudsService service = new CloudsService(mock.Object);

            //Act
            service.UpdateCloud(clouds);
            var result = list.ToList().FirstOrDefault();

            // Assert
            var viewResult = Assert.IsType<Clouds>(result);
            var model = Assert.IsAssignableFrom<Clouds>(viewResult);
            Assert.NotNull(model.All);
            Assert.NotEqual(model.All, previousAll);
        }


        //Check DeleteSkill
        [Fact]
        public async Task IsDeleteCityRemovesModel()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            var list = await GetTestClouds();
            var cloud = list.ToList().FirstOrDefault();
            var id = cloud.CloudsId;
            mock.Setup(uow => uow.Clouds.Delete(id));
            ICloudsService service = new CloudsService(mock.Object);

            //Act

            var result = service.DeleteCloud(id);

            // Assert
            var viewResult = Assert.IsType<bool>(result);
            var model = Assert.IsAssignableFrom<bool>(viewResult);
            Assert.True(model);
        }

        private async Task<IEnumerable<Clouds>> GetTestClouds()
        {
            var clouds = new List<Clouds>
            {
                new Clouds { CloudsId = Guid.NewGuid(), All = 123},
                new Clouds { CloudsId = Guid.NewGuid(), All = 120},
                new Clouds { CloudsId = Guid.NewGuid(), All = 220},
                new Clouds { CloudsId = Guid.NewGuid(), All = 150},
            };

            return clouds;
        }
    }
}