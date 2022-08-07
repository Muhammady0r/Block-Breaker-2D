using System.Collections;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public GameObject particleDestroy;
    public GameObject diedUi;
    int score;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI ScoreUI1;
    public TextMeshProUGUI BestScoreUI;
    Scenemanager sm;
    public AudioSource jumpS;
    public AudioSource dieS;

    public Transform paddle;
    public Vector3 startPos;
    [HideInInspector]public bool attach = true;

    private void Start()
    {
        Time.timeScale = 1;
        sm = FindObjectOfType<Scenemanager>();
        diedUi.SetActive(false);
        startPos = transform.position - paddle.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) if (diedUi.activeInHierarchy) sm.Restarter();
        if (Input.GetKeyDown(KeyCode.Q)) sm.Quit();
        if (Input.GetKeyDown(KeyCode.M)) sm.loadSceneId(0);
        if (attach)
            transform.position = paddle.position + startPos;
    }
    private void FixedUpdate()
    {
        ScoreUI.text = "Your Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            diedUi.SetActive(true);
            Instantiate(particleDestroy, transform.position, Quaternion.identity);
            ScoreUI1.text = "Your Score: " + score;
            GetComponent<SpriteRenderer>().enabled = false;
            dieS.Play();
            int bestScore = PlayerPrefs.GetInt("BestScore");
            if (score > bestScore) PlayerPrefs.SetInt("BestScore", score);
            BestScoreUI.text = "Best Score: " + PlayerPrefs.GetInt("BestScore");
            StartCoroutine(stopTime());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Cube col = collision.gameObject.GetComponent<Cube>();
            if (col.health <= 1)
            {
                if (!col.upgraded) score++;
                else score += 6;
            }
            col.Damage();
        }
        jumpS.Play();
    }

    IEnumerator stopTime()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.9f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.8f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.6f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
    }
}
