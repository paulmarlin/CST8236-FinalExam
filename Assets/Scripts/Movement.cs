using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public AudioSource catbatnoise;
    public AudioSource othernoise;
    public GameObject bullet;
    public Vector2 maxAngles;
    public float power;

    public float strafeRange;
    public float strafeRate;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        var screenSize = new Vector2(Screen.width, Screen.height);
        var screenCenter = screenSize / 2.0f;
        var delta = mousePosition - screenCenter;
        var percentage = new Vector2(delta.x / screenCenter.x, delta.y / screenCenter.y);

        var newAngle = new Vector2(percentage.x * maxAngles.x, percentage.y * maxAngles.y);
        transform.localRotation = Quaternion.Euler(newAngle.y, newAngle.x, 0.0f);

        if (Input.GetMouseButtonDown(0))
        {
            var bullet = GameObject.Instantiate(this.bullet, transform.localPosition, Quaternion.identity) as GameObject;
            bullet.GetComponent<Collisions>().catbatnoise = catbatnoise;
            bullet.GetComponent<Collisions>().othernoise = othernoise;
            var bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(transform.forward * power, ForceMode.Impulse);
        }

        // Strafing!
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(strafeRate * Time.deltaTime, 0.0f, 0.0f, Space.World);
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(-strafeRate * Time.deltaTime, 0.0f, 0.0f, Space.World);

        if (gameObject.transform.position.x > strafeRange)
            gameObject.transform.position = new Vector3(strafeRange, gameObject.transform.position.y, gameObject.transform.position.z);
        else if (gameObject.transform.position.x < -strafeRange)
            gameObject.transform.position = new Vector3(-strafeRange, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
