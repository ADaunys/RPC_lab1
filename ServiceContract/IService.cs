namespace Services;


/// <summary>
/// Structure for testing pass-by-value calls.
/// </summary>
public class ByValStruct
{
    /// <summary>
    /// Left number.
    /// </summary>
    public int Left { get; set; }

    /// <summary>
    /// Right number.
    /// </summary>
    /// <value></value>
    public int Right { get; set; }

    /// <summary>
    /// Left + Right
    /// </summary>
    public int Sum { get; set; }

    /// <summary>
    /// Capacity
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Upper bound
    /// </summary>
    public int UpperBound { get; set; }

    /// <summary>
    /// Lower bound
    /// </summary>
    public int LowerBound { get; set; }
}

/// <summary>
/// Service contract.
/// </summary>
public interface IService
{
    /// <summary>
    /// Remove liquid from the capacity
    /// </summary>
    /// <param name="amount">Liquid to remove.</param>
    /// <returns>New capacity</returns>
    int SubtractLiquid();

    /// <summary>
    /// Add liquid to the capacity
    /// </summary>
    /// <param name="amount">Liquid to add.</param>
    /// <returns>New capacity</returns>
	int AddLiquid();

    /// <summary>
    /// Get bounds
    /// </summary>
    /// <param name="structure">Structure to fill.</param>
    /// <returns>Structure with bounds.</returns>
    ByValStruct GetBounds(ByValStruct structure);
}