using UnityEngine;

public class NPCs : MonoBehaviour
{
    [SerializeField] GameObject fooditeats;
    [SerializeField] float animalSpeed;
    private float lowerBoundl = 15.0f;
    private bool isOutofScene;
    private bool notHungry;


    private void Start()
    {

    }

    private void Update()
    {
        DeleteOutOfScene();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * animalSpeed * Time.deltaTime);
    }

    private void DeleteOutOfScene()
    {
        if (transform.position.z < 15.0f)
        {
            MoveForward();
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private bool IsFoodItEats(string foodTriggered)
    {
        string foodItEatsName = fooditeats.name;
        // Remove "(Clone)" if it exists
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
            foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
        }
        // Compare the cleaned names
        return foodTriggered.Equals(foodItEatsName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") && !notHungry)
        {

            if (IsFoodItEats(other.name))
            {
                Scoreboard.Instance.UpdateScore(10);
            }
            else
            {
                Scoreboard.Instance.UpdateScore(-10);
                Destroy(gameObject);
            }
        }

    }
}


