using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    int currentPage = -1;
    int pages;
    public GameObject letterPrefab;
    public Transform[] letterPos = new Transform[7];
    string[] alphabet = { "A", "B", "C", "D", "E","F","I","L", "M", "N", "O", "P", "Q", "R", "U", "X", "Y"};

    public GameObject handTrack;
    public Vector3 handTrackPos;
    public GameObject openBook, closedBook;
    float timer;
    public float timeLimit = 0.5f;
    public float handSpeed = 2f;

    BoxCollider[] colls;
    BoxCollider col1, col2;
    BoxCollider trigCol1, trigCol2;

    // Use this for initialization
    void Start()
    {
        colls = GetComponents<BoxCollider>();
        foreach(BoxCollider collider in colls)
        {
            if (!collider.isTrigger && col1 ==null)
            {
                col1 = collider;
            }
            if (!collider.isTrigger && col1 != null)
            {
                col2 = collider;
            }
            if (collider.isTrigger && trigCol1 == null)
            {
                trigCol1 = collider;
            }
            if (collider.isTrigger && trigCol1 != null)
            {
                trigCol2 = collider;
            }
        }
        timer = timeLimit;
        pages = alphabet.Length / 8;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentPage < pages)
        {
            turnToPage(currentPage + 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPage != 0)
        {
            turnToPage(currentPage - 1);
        }
    }

    void turnToPage(int page)
    {
        

        GameObject[] letters = GameObject.FindGameObjectsWithTag("bookLetter");

        foreach(GameObject letter in letters)
        {
            Destroy(letter);
        }


        if (page > -1)
        {
            if (currentPage < 0)
            {
                col2.enabled = false;
                col1.enabled = true;

                trigCol1.enabled = false;
                trigCol2.enabled = true;
            }

            closedBook.SetActive(false);
            openBook.SetActive(true);

            for (int i = page * 8; i < (page + 1) * 8 && i < alphabet.Length; i++)
            {
                GameObject newLetter = Instantiate(letterPrefab, letterPos[i % 8].position, letterPos[i % 8].rotation);
                newLetter.GetComponent<LetterSelect>().SetLetterValue(i);
                newLetter.transform.SetParent(letterPos[i % 8]);
                newLetter.tag = "bookLetter";
                newLetter.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                newLetter.GetComponent<Text>().text = alphabet[i];
            }
        } else
        {
            col2.enabled = true;
            col1.enabled = false;

            trigCol1.enabled = true;
            trigCol2.enabled = false;

            closedBook.SetActive(true);
            openBook.SetActive(false);
        }
        currentPage = page;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LPalm" || other.tag == "RPalm")
        {
            handTrack = other.gameObject;
            handTrackPos = other.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == handTrack)
        {
            Vector3 velocity = (other.transform.position - handTrackPos) / Time.deltaTime;
            handTrackPos = other.transform.position;
            
            float leftRight = Vector3.Dot(velocity, transform.forward);

            if (leftRight > handSpeed && currentPage != -1 && timer >= timeLimit)
            {
                turnToPage(currentPage - 1);
                timer = 0f;
            }

            if (leftRight < -handSpeed && currentPage < pages && timer >= timeLimit)
            {
                turnToPage(currentPage + 1);
                timer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == handTrack)
        {
            handTrack = null;
            handTrackPos = Vector3.zero;
        }
    }
}
