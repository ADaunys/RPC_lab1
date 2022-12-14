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

    public bool CanSubtractLiquid()
    {
        if (Server.capacity > Server.upperBound)
        {
            return true;
        }
        return false;
    }
    public bool CanAddLiquid()
    {
        if (Server.capacity < Server.lowerBound)
        {
            return true;
        }
        return false;
    }

    public int SubtractLiquid(int amount)
    {
        if (Server.capacity - amount < Server.upperBound)
        {
            var startingCapacity = Server.capacity;
            log.Info($"Capacity before subtracting: {startingCapacity}");
            int overpumped = Server.upperBound - (startingCapacity - amount);
            Server.capacity = Server.upperBound;
            log.Info($"Capacity after subtracting: {Server.capacity}");
            log.Info($"Amount of liquid thrown away: {overpumped}");
            log.Info("\n");
            return startingCapacity - Server.upperBound;
        }
        else
        {
            log.Info("Capacity before subtracting: " + Server.capacity);
            Server.capacity -= amount;
            log.Info($"Capacity after subtracting: {Server.capacity}");
            log.Info("\n");
            return amount;
        }
    }

    public int AddLiquid(int amount)
    {
        if (Server.capacity + amount > Server.lowerBound)
        {
            var startingCapacity = Server.capacity;
            log.Info($"Capacity before adding: {startingCapacity}");
            int overfilled = (startingCapacity + amount) - Server.lowerBound;
            Server.capacity = Server.lowerBound;
            log.Info($"Capacity after adding: {Server.capacity}");
            log.Info($"Amount of liquid thrown away: {overfilled}");
            return Server.lowerBound - startingCapacity;
        }
        else
        {
            log.Info("Capacity before adding: " + Server.capacity);
            Server.capacity += amount;
            log.Info($"Capacity after adding: {Server.capacity}");
            return amount;
        }
    }

    public WaterContainer GetBounds(WaterContainer structure)
    {
        log.Info($"--- Sending info to client");
        structure.Capacity = Server.capacity;
        structure.UpperBound = Server.upperBound;
        structure.LowerBound = Server.lowerBound;
        return structure;
    }
}