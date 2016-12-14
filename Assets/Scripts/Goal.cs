using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public AudioSource goal;

    void OnTriggerEnter(Collider c)
    {
        goal.Play(); // I don't think I'm forgetting anything...
        // Oh yeah... remove the ball!
        GameObject.Destroy(c.gameObject);
    }
}
