using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class DestroyFood : MonoBehaviour
{
    float secondsInScene = 1.5f;


    private void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(secondsInScene);
        Destroy(gameObject);
    }
}
