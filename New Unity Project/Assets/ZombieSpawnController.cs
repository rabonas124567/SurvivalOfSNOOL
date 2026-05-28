/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawnController : MonoBehaviour
{
    public int initialZombiePerWave = 5;
    public int currentZombiePerWave;
    public float spawnDelay = 0.5f;

    public int currentWave = 0;
    public float waveCooldown = 10.0f;
    public bool inCooldown;

    public float cooldownCounter = 0;

    public List<Zombie> currentZombiesAlive = new List<Zombie>();
    public GameObject zombiePrefab;

    public TextMeshProUGUI TileWaveOver;

    private void Start()
    {
        currentZombiePerWave = initialZombiePerWave;
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentZombiesAlive.Clear();
        currentWave++;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentZombiePerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var zombieGO = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            Zombie zombieScript = zombieGO.GetComponent<Zombie>();
            currentZombiesAlive.Add(zombieScript);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        List<Zombie> zombiesToRemove = new List<Zombie>();

        foreach (Zombie zombie in currentZombiesAlive)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }

        foreach (Zombie zombie in zombiesToRemove)
        {
            currentZombiesAlive.Remove(zombie);
        }

        zombiesToRemove.Clear();

        if (currentZombiesAlive.Count == 0 && inCooldown == false)
        {
            StartCoroutine(WaveCooldown());
        }

        if (inCooldown)
        {
            cooldownCounter -= Time.deltaTime;
        }
        else
        {
            cooldownCounter = waveCooldown;
        }

    }

    private IEnumerator WaveCooldown()
    {
        inCooldown = true;
        TileWaveOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(waveCooldown);

        inCooldown = false;
        TileWaveOver.gameObject.SetActive(false);
        currentZombiePerWave *= 2;
        StartNextWave();
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawnController : MonoBehaviour
{
    public int initialZombiePerWave = 5;
    public int currentZombiePerWave;
    public float spawnDelay = 0.5f;

    public int currentWave = 0;
    public float waveCooldown = 10.0f;
    public bool inCooldown;

    public float cooldownCounter = 0;

    public List<Zombie> currentZombiesAlive = new List<Zombie>();
    public GameObject zombiePrefab;

    public TextMeshProUGUI TileWaveOver;
    public TextMeshProUGUI winText;

    private void Start()
    {
        currentZombiePerWave = initialZombiePerWave;
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentZombiesAlive.Clear();
        currentWave++;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentZombiePerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var zombieGO = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            Zombie zombieScript = zombieGO.GetComponent<Zombie>();
            currentZombiesAlive.Add(zombieScript);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        List<Zombie> zombiesToRemove = new List<Zombie>();

        foreach (Zombie zombie in currentZombiesAlive)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }

        foreach (Zombie zombie in zombiesToRemove)
        {
            currentZombiesAlive.Remove(zombie);
        }

        zombiesToRemove.Clear();

        if (currentZombiesAlive.Count == 0 && inCooldown == false)
        {
            StartCoroutine(WaveCooldown());
        }

        if (inCooldown)
        {
            cooldownCounter -= Time.deltaTime;
        }
        else
        {
            cooldownCounter = waveCooldown;
        }
    }

    private IEnumerator WaveCooldown()
    {
        inCooldown = true;

        if (currentWave == 2)
        {
            winText.gameObject.SetActive(true);
            yield break;
        }

        TileWaveOver.gameObject.SetActive(true);

        yield return new WaitForSeconds(waveCooldown);

        TileWaveOver.gameObject.SetActive(false);
        inCooldown = false;

        currentZombiePerWave *= 2;
        StartNextWave();
    }
}

