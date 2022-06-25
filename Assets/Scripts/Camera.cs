using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject tree;
    private Ball ball;
    private Bat bat;
    private Vector3 initPosition;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        bat = FindObjectOfType<Bat>();
        initPosition = transform.position;

        InstantiateTrees();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if(bat.HasSwung) {
            Vector3 ballPosition = ball.transform.position;
            position.x = ballPosition.x;
            // position.y = ballPosition.y;
            transform.position = position;
        }

        if(Input.GetAxis("Reset") > 0) {
            reset();
        }
    }

    void InstantiateTrees() {
        for(int i = 0; i < 1000; i++) {
            float x = Random.Range(125, 1000);
            float y = -4.8f;
            GameObject t = Instantiate(tree, new Vector3(x, y, 0), Quaternion.identity);
            float scaleFactor = Random.Range(3f, 9f);
            Vector3 scale = new Vector3(1, scaleFactor, 1);
            t.transform.localScale = scale;
        }
    }

    void reset() {
        transform.position = initPosition;
    }
}
