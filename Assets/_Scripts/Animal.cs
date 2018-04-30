/* in this abstract class we are ruling
 * which properties and methods must be
 * implemented by the inheriting classes
 */

using UnityEngine;

public abstract class Animal
{
    // public variable, not recommended, a protected variable would be better
    public Color toothColor = Color.white;

    // public properties that must be implemented
    public abstract Color SkinColor { get; }
    public abstract Color NoseColor { get; }
    public abstract float NoseLength { get; }
    public abstract float Scale { get; set; }

    // public methods that must be implemented
    public abstract void Sleep();
    public abstract string Talk();
    public abstract GameObject GetEars();
}
