using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Life;
    public int Level;
    public int Score;
    public bool IsgameOver;
    public GameObject RestartButton;
    public Text LifeTxt;
    public Text LevelTxt;
    public Text ScoreTxt;

    public AudioSource BackgroundAudio;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Life = 3;
        Level = 0;
        Score = 0;
        IsgameOver = false;

        StartCoroutine("DestroyBalls");
    }

    private void Update()
    {
        LifeTxt.text = "Life: " + Life.ToString();
        LevelTxt.text = "Level: " + Level.ToString();
        ScoreTxt.text = "Score: " + Score.ToString();

        if (Life <= 0)
        {
            IsgameOver = true;
        }
        if (IsgameOver == true)
        {
            RestartButton.SetActive(true);
            BackgroundAudio.Stop();
        }
    }

    IEnumerator DestroyBalls()
    {
        yield return new WaitForSeconds(25);
        Destroy(GameObject.FindGameObjectWithTag("BigBubble"));
        Destroy(GameObject.FindGameObjectWithTag("MediumBubble"));
        Destroy(GameObject.FindGameObjectWithTag("SmallBubbleHitPoint"));
        Destroy(GameObject.FindGameObjectWithTag("Health"));
        Destroy(GameObject.FindGameObjectWithTag("TimeStoper"));
        Destroy(GameObject.FindGameObjectWithTag("Explosion"));
    }

}
