using Business.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Business.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        Mock<IGameDal> _mockGameDal;
        List<Game> _dbGames;

        [TestInitialize]
        public void Start()
        {
            _mockGameDal = new Mock<IGameDal>();
            _dbGames = new List<Game>(){
                new Game()
                {
                Id = 1,
                Name = "Mario",
                UnitPrice = 20
                },
                new Game()
                {
                Id = 2,
                Name = "Minecraft",
                UnitPrice = 50
                }
            };
            _mockGameDal.Setup(g => g.GetAll(null)).Returns(_dbGames);
        }

        [TestMethod]
        public void Must_be_listable()
        {
            GameManager gameManager = new GameManager(_mockGameDal.Object);
            var data = gameManager.GetAll();
            Assert.AreEqual(2, data.Data.Count);
        }
    }
}