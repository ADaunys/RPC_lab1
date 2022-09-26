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
            log.Info($"Before pumping, capacity is {Server.capacity}");
            Server.capacity = Server.upperBound;
            log.Info($"After pumping, capacity is {Server.capacity}");
            return Server.capacity;
        }
        else
        {
            return 0;
        }
    }
    public int AddLiquid()
    {
        if (Server.capacity < Server.lowerBound)
        {
            log.Info($"Before filling, capacity is {Server.capacity}");
            Server.capacity = Server.lowerBound;
            log.Info($"After filling, capacity is {Server.capacity}");
            return Server.capacity;
        }
        else
        {
            return 0;
        }
    }
    public WaterContainer GetBounds(WaterContainer structure)
    {
        log.Info($"GetBounds()");
        structure.Capacity = Server.capacity;
        structure.UpperBound = Server.upperBound;
        structure.LowerBound = Server.lowerBound;
        return structure;
    }
}