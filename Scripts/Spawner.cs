using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BlockPrefab;
    public GameObject spawnP;
    public float spawnDelay;
    public Transform[] Spawners;
    private bool mouseDown = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mouseDown)
        {
            mouseDown = true;
            StartCoroutine(Spawner1());
        }
    }

    IEnumerator Spawner1()
    {
        int rand0 = Random.Range(1, Spawners.Length);
        for (int i = 0; i < rand0; i++)
        {
            int rand = Random.Range(0, Spawners.Length);
            Instantiate(BlockPrefab, Spawners[rand].position, Quaternion.identity);
            Instantiate(spawnP, Spawners[rand].position, Quaternion.identity);
            i++;
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner2());
    }
    IEnumerator Spawner2()
    {
        int rand0 = Random.Range(1, Spawners.Length);
        for (int i = 0; i < rand0; i++)
        {
            int rand = Random.Range(0, Spawners.Length);
            Instantiate(BlockPrefab, Spawners[rand].position, Quaternion.identity);
            Instantiate(spawnP, Spawners[rand].position, Quaternion.identity);
            i++;
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner1());
    }
}
