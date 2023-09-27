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

    public GameObject choiceContainer;
    public Object numberButtonPrefab;
    List<NumberButton> numberButtons = new List<NumberButton>();

    // Start is called before the first frame update
    void Start()
    {
        currentChoices = new int[numChoices];

        allChoices = new List<int>();
        for (int i = numberMinMax.x; i < numberMinMax.y; i++)
        {
            allChoices.Add(i);
        }

        for (int i = 0; i < numChoices; i++)
        {
            GameObject button = Instantiate(numberButtonPrefab, choiceContainer.transform) as GameObject;

            numberButtons.Add(button.GetComponent<NumberButton>());
        }

        GenerateNumber();
    }

    [ContextMenu("Generate number")]
    public void GenerateNumber()
    {
        currentNumber = Random.Range(numberMinMax.x, numberMinMax.y + 1);

        //Generate a set of random numbers that will not include dupicates
        allChoices.Sort((a, b) => 1 - 2 * Random.Range(0, allChoices.Count));
        
        GenerateChoices();

        //TODO:Spawn number in world
    }

    private void GenerateChoices()
    {
        bool alreadyContains = false;

        for (int i = 0; i < numChoices; i++)
        {
            currentChoices[i] = allChoices[i];
            numberButtons[i].SetNumber(currentChoices[i]);
            if (currentChoices[i] == currentNumber)
                alreadyContains = true;
        }

        if (!alreadyContains)
        {
            int choiceIndex = Random.Range(0, numChoices);
            currentChoices[choiceIndex] = currentNumber;
            numberButtons[choiceIndex].SetNumber(currentNumber);
        }
    }
}
