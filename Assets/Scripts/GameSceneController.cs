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
    public TextMeshProUGUI TimeText;
    public GameObject PiggieContanier;
    public LauncherController Launcher;
    PiggieController[] piggies;
    public ScoreManager ScoreManager;
    int piggiesToDestroy;
    int score = 0;
    private bool gameOver;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        piggies = PiggieContanier.GetComponentsInChildren<PiggieController>();
        piggiesToDestroy = piggies.Length;
        this.timer = ScoreManager.bestTime;
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
            if (this.timer <= ScoreManager.bestTime)
            {
                GameText.text = "You did it!\nPress R to restart";
            }
            else
            {
                ScoreManager.bestTime = this.timer;
                GameText.text = $"You did it!\nNew Best Time: {ScoreManager.bestTime}! \nPress R to restart";
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimeText.text = $"Time: {timer.ToString("0.00")}";
        PowerMeterText.text = "Cannon Power: " + Launcher.LauncherForce;

        if (Input.GetKeyDown("r"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

    }

}
