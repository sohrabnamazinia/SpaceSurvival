using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPlacer : MonoBehaviour
{
    public GameObject[] PlanetPrefabs;
    public GameObject[] EarthPrefabs;
    public float minX;
    public float maxX;
    public float minScale = 0.5f;
    public float maxScale = 2f;
    public float PlanetPrefabRandomWeight = 0.8f;
    public float timerMaxTime;
    public float timerCurrentTime;
    public PlayerController playerController;

    void start()
    {
    }

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            GameObject newInstance = getRandomPrefab();
            float InstanceX = getRandomPrefabInitialX();
            Instantiate(newInstance);
            Debug.Log(newInstance.gameObject.name + ": " + newInstance.gameObject.transform.position.x + ", " + newInstance.gameObject.transform.position.y);
            newInstance.transform.position = new Vector3(InstanceX, transform.position.y, transform.position.z);
            timerCurrentTime = timerMaxTime;
        }
    }

    GameObject getRandomPrefab()
    {
        GameObject go;
        var ran = UnityEngine.Random.value;
        var random = new System.Random();
        if (ran <= PlanetPrefabRandomWeight)
        {
            int index = random.Next(0, PlanetPrefabs.Length);
            go = PlanetPrefabs[index];
        }
        else
        {
            int index = random.Next(0, EarthPrefabs.Length);
            go =  EarthPrefabs[index];
        }
        var scale = Random.Range(minScale, maxScale);
        go.transform.localScale = new Vector3(scale, scale, scale);
        var rb = go.GetComponent<Rigidbody2D>();
        rb.mass = scale;
        return go;
    }

    float getRandomPrefabInitialX()
    {
        return UnityEngine.Random.Range(minX, maxX);
    }
}
