using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    List<SpawnData> spawnData;

    float max;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomObject", 0f, 0.5f);

        max = spawnData.Sum(sd => sd.Probability);

        StartCoroutine(SpawnRandomObjects());
    }

    IEnumerator SpawnRandomObjects() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            SpawnRandomObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject(GameObject go) {
        var g = Instantiate(go, GetRandomPosition(), Quaternion.identity, transform);
        Destroy(g, 4f);

        var rb = g.GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 7;
        // pøidáme rychlost smìrem dolù
    }

    private Vector3 GetRandomPosition() {
        return new Vector3(
            Random.Range(-3,3),
            transform.position.y,
            transform.position.z
            );
    }

    GameObject GetRandomPrefab() {
        float rnd = Random.Range(0, max);
        float sum = 0;

        for(int i = 0; i < spawnData.Count; i++) {
            sum += spawnData[i].Probability;
            if (rnd <= sum)
                return spawnData[i].Prefab;
        }

        return spawnData[0].Prefab;
    }

    void SpawnRandomObject() {
        SpawnObject(GetRandomPrefab());
    }
}

[System.Serializable]
public class SpawnData
{
    public GameObject Prefab;
    public float Probability;
}