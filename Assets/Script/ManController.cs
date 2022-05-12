using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManController : MonoBehaviour
{
    public enum PosState
    {
        ROTATION,SHOOT,REWIND
    }
    [SerializeField]
    private float rotateSpeed = 0.001f;
    [SerializeField]
    private float speed;

    PosState posState = PosState.ROTATION;
    private float angle;
    private int slowDown;
    private int dolar;
    private Vector3 origin;
    private Transform rod;
    private bool flagRod;
    private Text score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flagRod) return;
        flagRod = true;
        rod = collision.transform;
        rod.SetParent(transform);

        rod.tag = this.tag;
       
        slowDown = rod.GetComponent<Rod>().slowDown;
        dolar += rod.GetComponent<Rod>().dollar;
        Destroy(rod.GetComponent<Rod>());
        posState = PosState.REWIND;
    }
    private void Awake()
    {
        origin = transform.position;
        score = Camera.main.GetComponent<Text>();
    }
    void Update()
    {
       switch (posState)
        {
            case PosState.ROTATION:
                if (Input.GetKeyDown(KeyCode.Space)) posState = PosState.SHOOT;
                angle += rotateSpeed;
                if (angle > 70 || angle < -70)
                    rotateSpeed *= -1;
              
                transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
                break;
            case PosState.SHOOT:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (Mathf.Abs(transform.position.x) > 16 || transform.position.y <- 6)
                    posState = PosState.REWIND;
                break;
            case PosState.REWIND:
                transform.Translate(Vector3.up * (speed-slowDown) * Time.deltaTime);
                if (Mathf.Floor(transform.position.x) ==Mathf.Floor(origin.x) && Mathf.Floor(transform.position.y) == Mathf.Floor(origin.y))
                {
                    if(rod!= null)
                    {
                        Destroy(rod.gameObject);
                        slowDown = 0;
                        setDollar(dolar);
                        flagRod = false;
                        Score.instance.AddPoints();
                    }
                    transform.position = origin;
                    posState = PosState.ROTATION;
                }
                   
                break;
        }
   }
    private void setDollar(int dollar)
    {
        score.text = string.Format("$ {0}", dolar);
    }
 }
