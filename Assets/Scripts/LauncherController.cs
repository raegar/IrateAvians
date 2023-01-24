using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject LauncherBase;
    public GameObject BirdiePrefab;
    public float MaxBirdieForce = 1000f;

    public float LauncherForce = 100f;

    public int birdsRemaining;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 worldPosition = MainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - MainCamera.transform.position.z));

        if (worldPosition.x > LauncherBase.transform.position.x + 1) //Only when the mouse is to the Right of the Launcher
        {
            LauncherBase.transform.localEulerAngles = new Vector3(
                LauncherBase.transform.localEulerAngles.x,
                LauncherBase.transform.localEulerAngles.y,
                Mathf.Atan2((worldPosition.y - LauncherBase.transform.position.y), (worldPosition.x - LauncherBase.transform.position.x)) * Mathf.Rad2Deg
            );
        }

        if (Input.GetMouseButton(0))
        {
            LauncherForce += 2f;
            LauncherForce = Mathf.Clamp(LauncherForce, 100f, MaxBirdieForce);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject birdieInstance = Instantiate(BirdiePrefab);
            if (birdsRemaining >= 1) birdsRemaining -= 1;
            birdieInstance.transform.position = LauncherBase.transform.position + LauncherBase.transform.right * 1.5f;
            birdieInstance.GetComponent<Rigidbody>().AddForce(LauncherBase.transform.right * LauncherForce);
            LauncherForce = 100f;
        }


    }
}
