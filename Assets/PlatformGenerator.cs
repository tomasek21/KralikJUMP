using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public float ySpace = 1.5f;
    public GameObject platform;
    public float yStartPosition = -2.1f;
    public float xSpace;
    public float minXPos = -2.2f;
    public float maxXPos = 2.2f;
    public float lastXPos =0.2f;
    void Start()
    {
        StartCoroutine(generate());
    }

    // Update is called once per frame
    public IEnumerator generate()
    {
        while (true)
        {
            if(lastXPos <=0)
            {
                lastXPos = Random.Range(0, maxXPos);
            }
            else
            {
                lastXPos = Random.Range(minXPos, 0);
            }
            Instantiate(platform, new Vector3(lastXPos, yStartPosition + ySpace, 0), Quaternion.identity);
            yStartPosition += ySpace;
            yield return new WaitForSeconds(1f);
        }
    }
}
