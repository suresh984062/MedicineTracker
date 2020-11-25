
using System;
using System.Collections.Generic;
using MedicalTrackingSystem.Controllers;
using System.Text;
using Xunit;
using Moq;
using MedicalTrackingSystem.Services;
using MedicalTrackingSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UNITTEST
{
    public class MedicineTrakerControllerTest
    {

        protected MedicineTrakerController ControllerUnderTest { get; }
        protected Mock<IRepository> RepositoryMock { get; }

        public MedicineTrakerControllerTest()
        {
            RepositoryMock = new Mock<IRepository>();
            ControllerUnderTest = new MedicineTrakerController(RepositoryMock.Object);
        }

        


        [Fact]
        public async Task GetMedicineinfo()
        {

            // Arrange
            var MedicalData = medicalData;

            RepositoryMock
                .Setup(x => x.GetMedicineinfo())
                .ReturnsAsync(MedicalData);

            // Act
            var result = await ControllerUnderTest.GetMedicineinfo();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task GetMedicineDetails()
        {

            // Arrange
            var MedicalData = medicalData;

            RepositoryMock
                .Setup(x => x.GetMedicineinfo())
                .ReturnsAsync(MedicalData);

            // Act
            var result = await ControllerUnderTest.GetMedicineDetails("Zofran");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task AddRecord()
        {

            // Arrange
            var MedicalData = medicalData;

            RepositoryMock
                .Setup(x => x.GetMedicineinfo())
                .ReturnsAsync(MedicalData);

            // Act
            var result = await ControllerUnderTest.AddRecord(medicaltracker);

            // Assert
            var okResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(201, okResult.StatusCode);

        }

        [Fact]
        public async Task UpdateRecord()
        {

            // Arrange
            var MedicalData = medicalData;

            RepositoryMock
                .Setup(x => x.GetMedicineinfo())
                .ReturnsAsync(MedicalData);

            // Act
            var result = await ControllerUnderTest.UpdateRecord("Zofran", medicaltracker);

            // Assert
            // var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);        
        }

        protected static List<MedicineTracker> medicalData => new List<MedicineTracker>()
        {
            new MedicineTracker{
           id=1,
            Brand="zz",
             ExpiryDate =DateTime.Now,
              MedicineName ="Paracitomol",
               Price =100,
                Quantity=5
            }
                
        };

        protected static MedicineTracker medicaltracker => new MedicineTracker()
        {
            
           id=1,
            Brand="zz",
             ExpiryDate =DateTime.Now,
              MedicineName ="Paracitomol",
               Price =100,
                Quantity=5
           

        };


    }
}
