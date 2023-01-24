using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PiggieController : MonoBehaviour
{

    public delegate void OnPiggieDestroyAction();
    public OnPiggieDestroyAction OnPiggieDestroyed;

    public ScoreManager ScoreManager;

    public int PointValue = 150;

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

        //Destroy piggie based on force applied
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 0.8f)
        {
            ScoreManager.pointsScored = PointValue;
            GameObject.Destroy(this.gameObject);

            if (OnPiggieDestroyed != null)
            {
                OnPiggieDestroyed();
            }
        }
    }
}
