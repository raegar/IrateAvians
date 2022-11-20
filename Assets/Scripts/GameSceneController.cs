using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSceneController : MonoBehaviour
{

    public TextMeshProUGUI GameText;
    public TextMeshProUGUI PowerMeterText;
    public GameObject PiggieContanier;

    public LauncherController Launcher;

    PiggieController[] piggies;
    int piggiesToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        piggies = PiggieContanier.GetComponentsInChildren<PiggieController>();
        piggiesToDestroy = piggies.Length;
        foreach (PiggieController piggie in piggies)
        {
            piggie.OnPiggieDestroyed += PiggieDestroyed;
        }
    }

    void PiggieDestroyed()
    {
        piggiesToDestroy--;

        if (piggiesToDestroy == 0)
        {
            GameText.text = "You did it!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PowerMeterText.text = "Cannon Power: " + Launcher.LauncherForce;
    }
}
