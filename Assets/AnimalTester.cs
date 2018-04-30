/* This test class instantiates some Animal objects and then 
 * uses these instances. The instances are not GameObjects, 
 * or MonoBehaviours but regular C#-objects.
 */
using UnityEngine;

public class AnimalTester : MonoBehaviour
{
    Animal[] animals = new Animal[4];

    void Start()
    {
        MakeAnimals();
        MakeMoreAnimals();
        FillPolymorphicAnimalArray();
    }

    void MakeAnimals()
    {
        Elephant jumbo = new Elephant();
        Cat kitty = new Cat();
        jumbo.Talk();
        jumbo.Sleep();
        kitty.Talk();
        kitty.Sleep();
    }

    void MakeMoreAnimals()
    {
        Animal dumbo = new Elephant();
        Animal carlo = new Cat();
        carlo.Talk();
        // Not possible because we made the Animal class abstract:
        //Animal unknownAnimal = new Animal();
        //unknownAnimal.Talk();
    }

    void FillPolymorphicAnimalArray()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            // every second Animal is a Cat instead of an Elephant
            if (i % 2 == 0)
            {
                animals[i] = new Elephant();
            }
            else
            {
                animals[i] = new Cat();
            }
        }

        for (int i = 0; i < animals.Length; i++)
        {
            // because the abstract Animal class guarantees implementation of the Talk() method,
            // we can just call it on every animal without worry
            animals[i].Talk();
        }
    }
}
