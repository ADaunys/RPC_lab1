namespace Servers;

using Services;


/// <summary>
/// Service
/// </summary>
public class Service : IService
{
    /// <summary>
    /// Access lock.
    /// </summary>
    private readonly Object accessLock = new Object();

    /// <summary>
    /// Service logic implementation.
    /// </summary>
    private ServiceLogic logic = new ServiceLogic();

    /// <summary>
    /// Add to capacity
    /// </summary>
    /// <param name="amount">Amount to add</param>
    /// <returns>New capacity</returns>
    public int AddLiquid()
    {
        lock (accessLock)
        {
            return logic.AddLiquid();
        }
    }

    /// <summary>
    /// Remove from capacity
    /// </summary>
    /// <param name="amount">Amount to remove</param>
    /// <returns>New capacity</returns>
    public int SubtractLiquid()
    {
        lock (accessLock)
        {
            return logic.SubtractLiquid();
        }
    }

    /// <summary>
    /// Get bounds
    /// </summary>
    /// <param name="structure">Structure to fill.</param>
    /// <returns>Structure with bounds.</returns>
    public WaterContainer GetBounds(WaterContainer structure)
    {
        lock (accessLock)
        {
            return logic.GetBounds(structure);
        }
    }
}