using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

GameManager gameManager = new GameManager(new EfGameDal());

foreach(Game game in gameManager.GetAll().Data)
{
    Console.WriteLine(game.Name);
}