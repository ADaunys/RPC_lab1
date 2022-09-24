namespace Servers;

using NLog;

using Services;

/// <summary>
/// Service logic.
/// </summary>
class ServiceLogic : IService
{
    /// <summary>
    /// Logger for this class.
    /// </summary>
    private Logger log = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Add given numbers.
    /// </summary>
    /// <param name="leftAndRight">Numbers to add.</param>
    /// <returns>New capacity</returns>
    public int SubtractLiquid()
    {
        if (Server.capacity > Server.upperBound)
        {
            log.Info($"Before sucky sucky, capacity is {Server.capacity}");
            Server.capacity = Server.upperBound;
            log.Info($"After sucky sucky, capacity is {Server.capacity}");
            return Server.capacity;
        }
        else
        {
            return 0;
        }
    }
    public int AddLiquid()
    {
        return 0;
    }
    public ByValStruct GetBounds(ByValStruct structure)
    {
        var rnd = new Random();
        log.Info($"GetBounds()");
        structure.Capacity = Server.capacity;
        structure.UpperBound = Server.upperBound;
        structure.LowerBound = Server.lowerBound;
        return structure;
    }
}