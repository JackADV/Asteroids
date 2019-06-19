using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public float maxVelocity = 3f; // Max velocity of asteroids
    public float spawnRate = 1f; // The spawnrate
    public float spawnPadding = 2f; // padding to spawn

    public Color debugColor = Color.cyan;

    // Spawns an asteroid at a position specified
    public void Spawn(GameObject prefab, Vector3 position)
    {
        // Randomize a rotation for the asteroid
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Spawn random asteroid at random position and default Quaternion rotation
        GameObject asteroid = Instantiate(prefab, position, randomRot, transform);

        // get Rigidibody2D from asteroid
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

        // Apply random force to rigidbody
        Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse);

      
    }
    // Spawns a random asteroid in the array at a random position
    void SpawnLoop()
    {
        // generate random position inside sphere with spawn padding (radius)
        Vector3 randomPos = Random.insideUnitSphere * spawnPadding;

        // Generate random index into asteroid prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        // get random asteroid prefab from arrayt using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        // Spawn using random pos
        Spawn(randomAsteroid, randomPos);
    }

    // Use this for initialization
    void Start ()
    {
        // Invoke a funcion repeatedly with given rate
        InvokeRepeating("SpawnLoop", 0, spawnRate);
		
	}

    

    void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, spawnPadding);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
