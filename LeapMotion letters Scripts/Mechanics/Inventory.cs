using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    Stack<GameObject> bottomlessBag = new Stack<GameObject>();
    public GameObject spawn_FX;
    private GameObject spawnPoint;
    public AudioClip pop, suck;
    private AudioSource Audio;
    private ParticleSystem smoke;
    float timer;
    FixedJoint handLeft, handRight;

    private void Start()
    {
    
        spawnPoint = transform.GetChild(0).gameObject;
        Audio = GetComponent<AudioSource>();
        smoke = spawnPoint.GetComponent<ParticleSystem>();
    }

    void Update () {
        if (/*(transform.parent.tag == "LeftHand" || transform.parent.tag == "RightHand") &&*/ Vector3.Dot(transform.up, Vector3.down) > .8 && bottomlessBag.Count > 0)
        {
            if (timer < 0.2f)
            {
                timer += Time.deltaTime;
            }
            else
            {                
                Audio.pitch = Random.Range(0.5f, 1.4f);
                Audio.PlayOneShot(pop, 0.8f);
                smoke.Play();
                bottomlessBag.Peek().transform.parent = null;
                bottomlessBag.Peek().SetActive(true);
                bottomlessBag.Peek().GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(2f, -2f), Random.Range(2f, -2f), Random.Range(2f, -2f)));
                StartCoroutine(IncreaseSize(bottomlessBag.Peek()));
                bottomlessBag.Pop();
                timer = 0f;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            bottomlessBag.Push(other.gameObject);
            other.gameObject.SetActive(false);
            Audio.pitch = Random.Range(0.8f, 1.2f);
            Audio.PlayOneShot(suck, 1f);
            other.transform.SetParent(spawnPoint.transform);
            other.gameObject.transform.localPosition = new Vector3(0,.2f,0) ;
        }
    }

    IEnumerator IncreaseSize(GameObject item)
    {
        float count = 0f;
        Vector3 scale = item.transform.localScale;
        float scalingx = scale.x;
        float scalingy = scale.y;
        float scalingz = scale.z;

        while (count < 1f)
        {
            item.transform.localScale = new Vector3(scalingx * count, scalingy * count, scalingz * count);
            count += Time.deltaTime;
        } 

        if (count >= 1f)
        {
            item.transform.localScale = scale;
            yield return true;
        }
        yield return false;
    }
}
