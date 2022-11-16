using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggieController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        /* //Destry piggie, simple Method
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<FloorController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else if (collision.gameObject.GetComponent<BirdieController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }*/

        //Destroy piggie based on force applied
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 1.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
