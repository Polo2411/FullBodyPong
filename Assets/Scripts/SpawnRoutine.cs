using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class SpawnRoutine : MonoBehaviour
{
    public bool canSpawn = true; // 1
    public List<GameObject> PowerUpPrefabs; // 2
    public Transform PUSpawnPosition; // 3
    public float timeBetweenSpawns;
    private List<GameObject> ActivePUlist = new List<GameObject>(); // 5
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPURoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnPU()
    {
        Vector3 randomPosition = PUSpawnPosition.position; // 1
        int index = Random.Range(0, PowerUpPrefabs.Count);
        GameObject newPU = Instantiate(PowerUpPrefabs.ElementAt(index), randomPosition, PowerUpPrefabs.ElementAt(index).transform.rotation); // 2
        ActivePUlist.Add(newPU);
        if (randomPosition.z < 50)
        {
            Vector3 Axis = new Vector3(0, 1, 0);
            newPU.transform.Rotate(Axis, 180);
        }
        newPU.GetComponentInChildren<killPU>().SetSpawner(this);
    }
    private IEnumerator SpawnPURoutine()
    {
        while (canSpawn)
        {
            SpawnPU();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    public void DeactivatePU(GameObject PU)
    {
        ActivePUlist.Remove(PU);
    }
}
