using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

GameManager gameManager = new GameManager(new EfGameDal());

//gameManager.Add(new Game()
//{
//    Name = "Snake Game",
//    UnitPrice = 0
//});

foreach(Game game in gameManager.GetAll().Data)
{
    Console.WriteLine(game.Name);
}