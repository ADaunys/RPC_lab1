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
    /// Check if liquid can be added to the capacity
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanAddLiquid()
    {
        lock (accessLock)
        {
            return logic.CanAddLiquid();
        }
    }

    /// <summary>
    /// Check if liquid can be subtracted from the capacity
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanSubtractLiquid()
    {
        lock (accessLock)
        {
            return logic.CanSubtractLiquid();
        }
    }

    /// <summary>
    /// Add liquid to the capacity
    /// </summary>
    /// <param name="amount">Amount of liquid to add</param>
    /// <returns>Amount of liquid to be added</returns>
    public int AddLiquid(int amount)
    {
        lock (accessLock)
        {
            return logic.AddLiquid(amount);
        }
    }

    /// <summary>
    /// Subtract liquid from the capacity
    /// </summary>
    /// <param name="amount">Amount of liquid to subtract</param>
    /// <returns>Amount of liquid to be subtracted</returns>
    public int SubtractLiquid(int amount)
    {
        lock (accessLock)
        {
            return logic.SubtractLiquid(amount);
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