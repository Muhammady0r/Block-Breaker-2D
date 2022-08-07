using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int health;
    public bool upgraded;
    public GameObject UP;
    public Sprite[] destroyLvlSt;
    public GameObject particleDestroy;
    SpriteRenderer strend;
    public AudioSource hitS;
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 50);
        if (rand == 25)
        {
            upgraded = true;
            health = destroyLvlSt.Length * 2;
            GameObject GUP = Instantiate(UP, transform.position, Quaternion.identity);
            GUP.transform.parent = gameObject.transform;
        }
        else if (rand != 25)
        {
            upgraded = false;
            health = destroyLvlSt.Length;
        }
        strend = GetComponent<SpriteRenderer>();
        strend.sprite = destroyLvlSt[destroyLvlSt.Length - 1];
        hitS.gameObject.SetActive(false);
        int colorId = Random.Range(0, colors.Length);
        strend.color = colors[colorId];
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Instantiate(particleDestroy, transform.position, Quaternion.identity);
            Camera.main.GetComponent<Animator>().SetTrigger("shake");
            hitS.gameObject.SetActive(true);
            hitS.transform.parent = null;
            hitS.Play();
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        health--;
        if (!upgraded)
            strend.sprite = destroyLvlSt[health - 1];
        else if (upgraded)
        {
            if (health <= 6 && health >= 5)
                strend.sprite = destroyLvlSt[2];
            else if (health <= 4 && health >= 3)
                strend.sprite = destroyLvlSt[1];
            else if (health <= 2 && health >= 1)
                strend.sprite = destroyLvlSt[0];
        }
    }
}
