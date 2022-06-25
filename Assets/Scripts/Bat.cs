using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private bool hasSwung = false;
    private Vector3 initPosition;
    public Vector3 InitPosition { get { return initPosition; } }
    public bool HasSwung { get { return hasSwung; } }
    private Ball ball;
    private float baseXForce = 500f;
    private float baseYForce = 75f;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        Vector3 ballPosition = ball.transform.position;
        Vector3 position = transform.position;

        if(Input.GetAxis("Swing") > 0 & !hasSwung) {
            

            float distance = Mathf.Abs(ballPosition.x - position.x);

            print("Distance: " + distance);

            float xForce, yForce;
            switch(distance) {
                default:
                    print("No swing");
                    break;
                case <.05f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.9f;
                    yForce = baseYForce * 1.9f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 0.05");
                    break;
                case <.1f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.8f;
                    yForce = baseYForce * 1.8f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 0.1");
                    break;
                case <.25f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.7f;
                    yForce = baseYForce * 1.7f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 0.25");
                    break;
                case <.5f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.6f;
                    yForce = baseYForce * 1.6f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 0.5");
                    break;
                case <1f:
                    StartCoroutine(Swing());
                    yForce = baseYForce * 1.5f;
                    xForce = baseXForce * 1.5f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 1");
                    break;
                case <2f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.4f;
                    yForce = baseYForce * 1.4f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 2");
                    break;
                case <3f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.3f;
                    yForce = baseYForce * 1.3f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 3");
                    break;
                case <4f:
                    StartCoroutine(Swing());
                    xForce = baseXForce * 1.1f;
                    yForce = baseYForce * 1.1f;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 4");
                    break;
                case <5f:
                    StartCoroutine(Swing());
                    xForce = baseXForce;
                    yForce = baseYForce;
                    ballRigidbody.AddForce(new Vector2(xForce, yForce));
                    print("within 5");
                    break;
            }
        }

        if(Input.GetAxis("Reset") > 0 & hasSwung) {
            reset();
        }
    }

    IEnumerator Swing() {
        hasSwung = true;
        Vector3 position = transform.position;
        position.x += .5f;
        transform.position = position;

        yield return new WaitForSeconds(.3f);

        position.x -= .5f;
        transform.position = position;        
    }

    public void reset() {
        // Vector3 position = transform.position;
        // position.x -= .5f;
        // transform.position = position;
        hasSwung = false;
    }

    // public bool getHasSwung() {
    //     return hasSwung;
    // }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}
