    using UnityEngine;

public class SpawnManagers : MonoBehaviour
{
   [SerializeField] private GameObject[] animalPrefab;
    public int animalsFeed;
    private float zStart = 18f;
    private float xSpawnRange = 20.1f;
    private float startDelay = 2f;
    private float repeatRate = 1.5f;
   

    private void Start()
    {
        Scoreboard.Instance.UpdateRemaining(animalsFeed);
        InvokeRepeating("SpawnAnimal", startDelay, repeatRate);

    }
    private void SpawnAnimal()
    {
        // Choose a random index from the animalPrefab array
        // Random.Range(0, animalPrefab.Length) generates a random number between 0 and the length of the animalPrefab array (exclusive)
        int choice = Random.Range(0, animalPrefab.Length);

        // Generate a random spawn position on the X axis within the specified range (-xSpawnRange to xSpawnRange)
        float xPosition = Random.Range(-xSpawnRange, xSpawnRange);

        // Instantiate (create) a new animal object at the chosen position with the desired rotation
        // animalPrefab[choice] gets the animal prefab based on the random choice
        // new Vector3(position, 0, zStart) sets the spawn position in 3D space (X: random, Y: 0, Z: zStart)
        // Quaternion.Euler(0, 180, 0) sets the animal's rotation to 180 degrees on the Y axis (flipping it horizontally). Change if not facing correctly.
        Instantiate(animalPrefab[choice], new Vector3(xPosition, 0, 13f), Quaternion.Euler(0, 180, 0));
        animalsFeed--;
        Scoreboard.Instance.UpdateRemaining(animalsFeed);
        if (animalsFeed == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        CancelInvoke();
    }
}
