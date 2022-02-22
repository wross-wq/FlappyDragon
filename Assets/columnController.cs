using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeScale == 1)
        {
            GameObject g = Instantiate(gameObject);//
            int y = Random.Range(0, 10);
            float x = transform.position.x;
            x = x + 40;
            g.transform.position = new Vector3(x, y, 0);
        }
    }
}
