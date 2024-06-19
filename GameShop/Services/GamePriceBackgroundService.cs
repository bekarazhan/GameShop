using System.Diagnostics;
using System.IO.Pipelines;
using GameShop.Interfaces;
using GameShop.Models.ViewModels;
using GameShop.Services;

namespace GameShop.Services
{
    public class GamePriceBackgroundService : BackgroundService
    {
        //public readonly IGamesService _gamesService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public GamePriceBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            //_gamesService = gamesService;
            _serviceScopeFactory = serviceScopeFactory;
        }
        private readonly int interval = 10; // Set the interval as required


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            { //throw new NotImplementedException();
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _gamesService = scope.ServiceProvider.GetRequiredService<IGamesService>();
                        var games = await _gamesService.GetAllGames();
                        int? maxIdOfGames = games.OrderByDescending(x => x.Id).ToList().FirstOrDefault()?.Id;
                        Random random = new Random();
                        if (maxIdOfGames is null && maxIdOfGames < 0)
                        {
                            throw new ArgumentException();
                        }
                        int randomId = random.Next(0, (int)maxIdOfGames + 1);

                        var game = games.FirstOrDefault(x => x.Id == randomId);
                        if (game == null)
                        {
                            throw new ArgumentException();
                        }

                        GameVm gameVm = new GameVm()
                        {
                            Id = randomId,
                            Price = game.Price * 0.8,
                            Name = game.Name
                        };
                        Debug.WriteLine(game.Name, "oldPrice:", game.Price, "newPrice:", gameVm.Price);
                        await _gamesService.UpdateGame(gameVm);
                        Debug.WriteLine("Success");
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }


                await Task.Delay(TimeSpan.FromSeconds(interval), stoppingToken);
            }
        }
    }
}
