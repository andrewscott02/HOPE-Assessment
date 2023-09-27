using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Vector2Int numberMinMax;
    public int numChoices;
    int currentNumber;
    int[] currentChoices;
    List<int> allChoices;

    // Start is called before the first frame update
    void Start()
    {
        currentChoices = new int[numChoices];

        allChoices = new List<int>();
        for (int i = numberMinMax.x; i < numberMinMax.y; i++)
        {
            allChoices.Add(i);
        }
    }

    [ContextMenu("Generate number")]
    public void GenerateNumber()
    {
        currentNumber = Random.Range(numberMinMax.x, numberMinMax.y + 1);

        //Generate a set of random numbers that will not include dupicates
        allChoices.Sort((a, b) => 1 - 2 * Random.Range(0, allChoices.Count));

        bool alreadyContains = false;

        for (int i = 0; i < numChoices; i++)
        {
            currentChoices[i] = allChoices[i];
            if (currentChoices[i] == currentNumber)
                alreadyContains = true;
        }

        if (!alreadyContains)
        {
            int choiceIndex = Random.Range(0, numChoices);
            currentChoices[choiceIndex] = currentNumber;
        }

        //TODO:Spawn number in world
    }
}
