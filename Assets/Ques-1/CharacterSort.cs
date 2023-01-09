using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSort : MonoBehaviour
{
    List<char> sortedAlphabets = new List<char>();
    List<char> randomAlphabets = new List<char>();

    private void Start()
    {
        for(int i = 0; i < 26; i++)
        {
            sortedAlphabets.Add((char)(i + 65));
        }
        while(sortedAlphabets.Count > 0)
        {
            int index = Random.Range(0, sortedAlphabets.Count);
            char alphabet = sortedAlphabets[index];
            sortedAlphabets.RemoveAt(index);
            randomAlphabets.Add(alphabet);
        }

        string chars = "";
        for (int i = 0; i < randomAlphabets.Count; i++)
            chars += randomAlphabets[i] + " ";
        Debug.Log(chars);

        int charRemovedIndex = Random.Range(0, randomAlphabets.Count);
        char removedAlphabet = randomAlphabets[charRemovedIndex];
        randomAlphabets.RemoveAt(charRemovedIndex);
        randomAlphabets.Sort();

        chars = "";
        for (int i = 0; i < randomAlphabets.Count; i++)
            chars += randomAlphabets[i] + " ";
        Debug.Log(chars);

        int indexToBeSearched = Mathf.CeilToInt(randomAlphabets.Count / 2.0f);
        int previousIndex = randomAlphabets.Count;

        while (previousIndex != indexToBeSearched)
        {
            char expectedChar = (char)(65 + indexToBeSearched);
            char arrayChar = randomAlphabets[indexToBeSearched];
            if (arrayChar == expectedChar)
            {
                indexToBeSearched += Mathf.CeilToInt((previousIndex - indexToBeSearched) / 2.0f);
            }
            else
            {
                previousIndex = indexToBeSearched;
                indexToBeSearched = Mathf.CeilToInt(indexToBeSearched / 2.0f);
            }
        }

        Debug.Log("Missing Character is : " + (char)(indexToBeSearched + 65));

    }

}
