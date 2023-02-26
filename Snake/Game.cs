//
// This is the game event logic that you can customize and cannibalize
// as needed. You should try to write your game in a modular way, avoid
// making one huge Game class.
//

class Game
{
    ScheduleTimer? _timer;
    public Map map = new Map();
    public bool Paused { get; private set; }
    public bool GameOver { get; private set; }

    public void Start()
    {
        map.Board();
        ScheduleNextTick();
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
        Paused = true;
        _timer!.Pause();
    }

    public void Resume()
    {
        Console.WriteLine("Resume");
        Paused = false;
        _timer!.Resume();
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
        GameOver = true;
    }

    public void Input(ConsoleKey key)
    {
        map.MoveDirection(key.ToString());
    }

    void Tick()
    {
        map.Move();
        if (map.collision())
        {
            GameOver = true;
        }
        ScheduleNextTick();
    }

    void ScheduleNextTick()
    {
        // the game will automatically update itself every half a second, adjust as needed
        _timer = new ScheduleTimer(100, Tick);
    }
}