using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingLetters : MonoBehaviour {

    public GameObject letterPrefab, letterPrefab2;
    public Transform spawnPoint;
    Vector3 startPos;

    ChangeLetterNumberCast letterColor;

    SequenceMechanim SQ;

    float letterDistance = .05f;
    string word;
    List<RemoveLetter> Letters = new List<RemoveLetter>();

    private void Start()
    {
        letterColor = FindObjectOfType<ChangeLetterNumberCast>();
        SQ = FindObjectOfType<SequenceMechanim>();
    }

    public void Update()
    {
        startPos = spawnPoint.position - transform.forward * ((Letters.Count - 1) * letterDistance / 2);

        for (int i = 0; i < Letters.Count; i++)
        {
            Vector3 letterpos = startPos + transform.forward * i * letterDistance;
            Letters[i].SetPosition(letterpos);
        }
    }

    public void AddLetter(string letter)
    {
        word += letter;
        GameObject newLetter;
        if (letterColor.number == true)
        {
            newLetter = Instantiate(letterPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            newLetter = Instantiate(letterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        newLetter.transform.SetParent(spawnPoint);
        Letters.Add(newLetter.GetComponent<RemoveLetter>());
        newLetter.GetComponent<Text>().text = letter;
        
    }

    public void RemoveLetter(RemoveLetter letter)
    {
        Letters.Remove(letter);
        string newString = "";
        for (int i = 0; i < Letters.Count; i++)
        {
            newString += Letters[i].gameObject.GetComponent<Text>().text;
        }
        SQ.UpdateSequence(newString);
    }
}
