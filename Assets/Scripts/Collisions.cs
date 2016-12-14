using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

    public AudioSource catbatnoise;
    public AudioSource othernoise;
	
	void OnCollisionEnter (Collision c) {
        if (c.gameObject.name.Equals("Bat"))
            catbatnoise.Play();
        else
            othernoise.Play();

        GameObject.Destroy(gameObject);
	}
}
