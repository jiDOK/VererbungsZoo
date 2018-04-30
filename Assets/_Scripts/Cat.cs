/* The Cat class has methods and properties that are similar to those of the
 * Elephant class but are implemented in a different way
 */

using UnityEngine;

public class Cat : Animal
{
    private Color skinColor = Color.magenta;
    public override Color SkinColor
    {
        get { return skinColor; }
    }

    private Color noseColor = new Color(0.2f, 0.7f, 0.9f);
    public override Color NoseColor
    {
        get { return noseColor; }
    }

    private float noseLength = 1f;
    public override float NoseLength
    {
        get { return noseLength; }
    }

    private float scale = 0.5f;
    public override float Scale
    {
        get
        {
            return scale;
        }
        set
        {
            if (value < 0.1f)
            {
                value = 0.1f;
            }
            else if (value > 1.5f)
            {
                value = 1.5f;
            }
            scale = value;
        }
    }

    public override void Sleep()
    {
        Debug.Log("Purr!");
    }

    public override string Talk()
    {
        return "Meow!";
    }

    public override GameObject GetEars()
    {
        GameObject ears = Resources.Load("CatEars") as GameObject;
        return ears;
    }
}
