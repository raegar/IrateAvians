using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameSceneController : MonoBehaviour
{
    public TextMeshProUGUI GameText;
    public TextMeshProUGUI PowerMeterText;
    public TextMeshProUGUI ScoreText;
    public GameObject PiggieContanier;
    public LauncherController Launcher;
    PiggieController[] piggies;
    public ScoreManager ScoreManager;
    int piggiesToDestroy;
    int score = 0;


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

        score += ScoreManager.pointsScored;

        ScoreText.text = $"Score: {score}";

        if (piggiesToDestroy == 0)
        {
            GameText.text = "You did it!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PowerMeterText.text = "Cannon Power: " + Launcher.LauncherForce;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

    }
}
