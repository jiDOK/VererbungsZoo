using UnityEngine;

public class Jumbo : MonoBehaviour
{
    // Instead of public variables we use the SerializeField attribute
    // to make the variables accessible in the editor
    [SerializeField]
    KeyCode animalKey;
    [SerializeField]
    Renderer bodyRend;
    [SerializeField]
    Renderer teethRend;
    [SerializeField]
    Renderer noseRend;
    [SerializeField]
    Transform pivot;
    [SerializeField]
    Transform nosePivot;

    GameObject ears;
    Elephant ele;
    Cat cat;
    // because of polymorphism, we can put a DwarfElephant into an Elephant variable:
    Elephant smallEle;
    string noise = "";
    int animalIndex = 0;

    void Start()
    {
        ele = new Elephant();
        cat = new Cat();
        // polymorphism
        smallEle = new DwarfElephant();
        BecomeAnimal(ele);
        animalIndex++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(animalKey))
        {
            // A switch statement is similar to an if statement.
            // When there are only certain values (0, 1, 2 in this case) 
            // it is a convenient way to code the different possible outcomes
            switch (animalIndex)
            {
                // if animalIndex is 0...
                case 0:
                    BecomeAnimal(ele);
                    animalIndex++;
                    break;
                case 1:
                    BecomeAnimal(cat);
                    animalIndex++;
                    break;
                case 2:
                    BecomeAnimal(smallEle);
                    animalIndex = 0;
                    break;
                default:
                    break;
            }
        }
    }

    void BecomeAnimal(Animal animal)
    {
        // make sure there are no ears left from our last incarnation
        if (ears != null)
        {
            Destroy(ears);
        }
        // the animal that was passed as an argument gives us the correct ear prefab
        // than this prefab is instantiated and put as a child into the pivot
        ears = Instantiate<GameObject>(animal.GetEars(), pivot);
        // now we can scale the pivot according to the scale value
        // provided by the Animal C# object.
        pivot.localScale = Vector3.one * animal.Scale;
        // nose pivot works slightly differently because only its length is affected
        // over all scale comes from scaling the pivot (nose pivot is a child of pivot in the hierarchy)
        nosePivot.localScale = new Vector3(1f, 1f, animal.NoseLength);
        // set the first two children of the ears object to the correct skin color
        ears.transform.GetChild(0).GetComponent<Renderer>().material.color = animal.SkinColor;
        ears.transform.GetChild(1).GetComponent<Renderer>().material.color = animal.SkinColor;
        // also set the rest of the colors according to the animal's values
        bodyRend.material.color = animal.SkinColor;
        teethRend.material.color = animal.toothColor;
        noseRend.material.color = animal.NoseColor;
        // get a string from the animal. The OnGUI will render it.
        noise = animal.Talk();
    }

    // Using the old GUI to quickly display the animal noises:
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.label);
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.red;
        // a Rect is a 2D rectangle on the screen
        // the Label is set up to show what is currently in the noise variable
        GUI.Label(new Rect(20f, 20f, 400f, 200f), noise, myStyle);
    }
}
