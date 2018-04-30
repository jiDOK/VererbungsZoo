/* The DwarfElephant inherits from Elephant and only overwrites
 * some of its methods and properties. The rest is used as is
 */

public class DwarfElephant : Elephant
{
    private float scale = 1f;
    public override float Scale
    {
        get { return scale; }
        // Properties can check values, raise events etc. in their getter and setter "methods"
        set
        {
            if (value < 0.5f)
            {
                value = 0.5f;
            }
            else if (value > 1.2f)
            {
                value = 1.2f;
            }
            scale = value;
        }
    }

    public override string Talk()
    {
        return base.Talk() + "\nIch bin sehr klein!!";
    }
}
