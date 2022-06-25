using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Bat bat;
    public TMP_Text text;
    private bool hasPitched = false;
    private Vector3 initialPosition;
    // private bool hit = false;
    private bool groundTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(bat.transform.position.x + 18.4404f, -3.22f, 0);
        transform.position = initialPosition;
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
        bat.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(Input.GetAxis("Fire1") > 0 & !hasPitched & !bat.HasSwung) {
            hasPitched = true;
            rigidbody.isKinematic = false;
            // rigidbody.AddForce(new Vector3(-250f, 19.7f, 0));
            rigidbody.AddForce(new Vector3(-170f, 32f, 0));
        }

        if(bat.HasSwung && !groundTouched) {
            text.text = "Hit Distance: " + ((transform.position.x - bat.InitPosition.x) * 3.281f);
        }

        if(Input.GetAxis("Reset") > 0 & hasPitched) {
            print("ball resetting");
            hasPitched = false;
            // hit = false;
            groundTouched = false;
            transform.position = initialPosition;
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector3.zero;
            text.text = "Hit Distance: --";
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        groundTouched = true;
    }

}
