/* Elephant inherits from Animal and must implement its abstract members, 
 * this is to guarantee that they are there if we deal with the broad category of Animals
 * instead of specific Animal species like Cats or Elephants.
 * Still, the specific Animals can vary the actual values and behaviours making it possible 
 * to have variations per species as well as per individual instance.
 */

using UnityEngine;

public class Elephant : Animal
{
    // private backing variable
    private Color skinColor = Color.gray;
    // and the corresponding public property; must be implemented, because we inherit from Animal
    public override Color SkinColor
    {
        get { return skinColor; }
    }

    private Color noseColor = new Color(0.2f, 0.2f, 0.2f);
    public override Color NoseColor
    {
        get { return noseColor; }
    }

    private float noseLength = 3f;
    public override float NoseLength
    {
        get { return noseLength; }
    }

    private float scale = 5f;
    public override float Scale
    {
        get { return scale; }
        // Properties can check values, raise events etc. in their getter and setter "methods"
        set
        {
            if (value < 2f)
            {
                value = 2f;
            }
            else if (value > 8f)
            {
                value = 8f;
            }
            scale = value;
        }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // The override keyword is used to implement abstract members or overwrite virtual ones
    public override string Talk()
    {
        return "Törööö!";
    }

    public override void Sleep()
    {
        Debug.Log("ZZZZZ");
    }

    public override GameObject GetEars()
    {
        GameObject ears = Resources.Load("ElephantEars") as GameObject;
        return ears;
    }

}
