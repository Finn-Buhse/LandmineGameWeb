using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using LandmineGameClasses;

namespace MineGameAPI.Controllers
{
    // Global singleton game storage class
    public class GameStorage
    {
        private static GameStorage? sInstance = null;

        public static void createInstance()
        {
            if (sInstance == null)
            {
                sInstance = new GameStorage();
            }
        }

        public static GameStorage instance()
        {
            return sInstance!;
        }

        public LandmineGame? landmineGame = null;
        public bool gameInitialised = false;
    };

    [ApiController]
    [Route("[controller]")]
    public class MineGameInitialiseController : ControllerBase
    {
        private readonly ILogger<MineGameInitialiseController> _logger;

        GameStorage gs;

        public MineGameInitialiseController(ILogger<MineGameInitialiseController> logger)
        {
            _logger = logger;

            // Create game storage
            GameStorage.createInstance();
            gs = GameStorage.instance();

            // Create game within storage
            gs.landmineGame = new LandmineGame();
            gs.gameInitialised = true;
        }

        [HttpPut(Name = "Initialise")]
        public void PutInitialise(int width = 8, int height = 8)
        {
            gs!.landmineGame!.setBoardWidthHeightInitialiseHints(width, height);
            gs!.landmineGame!.initialise();
        }

        // TODO: Look at whether this is needed
        [HttpGet(Name = "GetInitialised")]
        public bool GetInitialised()
        {
            return gs!.gameInitialised;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class MineGamePlayerController : ControllerBase
    {
        private readonly ILogger<MineGameInitialiseController> _logger;

        GameStorage gs;

        public MineGamePlayerController(ILogger<MineGameInitialiseController> logger)
        {
            _logger = logger;

            // Get game storage instance
            gs = GameStorage.instance();
        }

        // 0 : Up, 1 : Down, 2 : Left, 3 : Right
        [HttpPut(Name = "MovePlayer")]
        public void PutPlayerMovementDirection(int movementDirection)
        {
            if(gs != null)
            {
                if (gs.landmineGame != null)
                {
                    gs.landmineGame.movePlayer((Player.MovementDirection)movementDirection);
                }
                else
                {
                    Console.WriteLine("[ERROR] Invoked MovePlayer, but the game needs to be initialised");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Invoked MovePlayer, but the game needs to be initialised");
            }
        }
    };

    [ApiController]
    [Route("[controller]")]
    public class MineGameFrameController : ControllerBase
    {
        private readonly ILogger<MineGameInitialiseController> _logger;

        GameStorage gs;

        public MineGameFrameController(ILogger<MineGameInitialiseController> logger)
        {
            _logger = logger;

            // Get game storage instance
            gs = GameStorage.instance();
        }

        [HttpPut(Name = "ProcessFrame")]
        public void PutProcessFrame()
        {
            if (gs != null)
            {
                if(gs.landmineGame != null)
                {
                    gs.landmineGame.processFrame();
                }
                else
                {
                    Console.WriteLine("[ERROR] Invoked ProcessFrame, but the game needs to be initialised");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Invoked ProcessFrame, but the game needs to be initialised");
            }
        }

        [HttpGet(Name = "GetFrame")]
        public string GetFrame()
        {
            if (gs != null)
            {
                if (gs.landmineGame != null)
                {
                    return gs.landmineGame.getFrameJSON();
                }
                else
                {
                    Console.WriteLine("[ERROR] Invoked GetFrame, but the game needs to be initialised");
                    return "Empty frame";
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Invoked GetFrame, but the game needs to be initialised");
                return "Empty frame";
            }
        }
    };
}
