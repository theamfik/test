using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMovement : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Vector3 NewPos;
    Vector3 landingScale;
    Vector3 takeOffScale;
    bool iMove = false;
    float speed = 10f;
    float rotationSpeed = 6f;
    public bool landed = false;
    float landingSpeed = 10f;
    Vector3 dir;
    IEnumerator moveCoroutine;
    SpriteRenderer spriteRenderer;
    List<Transform> objects;
    Vector3 target;
    Transform curTarget;




    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        objects = GameObject.FindGameObjectWithTag("System1").GetComponent<SystemData>().objects;
    }


    void Update()
    {
        if (curTarget != null) return;


        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] != transform)
            {
                curTarget = objects[i];
                break;
            }

        }

        //StartCoroutine(FollowTo());
    }

    IEnumerator Move(Vector3 target)
    {

        iMove = true;
        while (true)
        {

            //TAKEOFF

            if (landed)
            {
                takeOffScale = new Vector3(0.5f, 0.4f, 0);
                spriteRenderer.enabled = true;
                transform.localScale = Vector3.Lerp(transform.localScale, takeOffScale, Time.deltaTime * landingSpeed);
                speed = Mathf.Lerp(speed, 10f, Time.deltaTime * 3);
                landed = false;
            }

            //MOVEMENT

            dir = target - transform.position;
            if (dir.magnitude <= 1.2f)
                break;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            transform.position += transform.right * Time.deltaTime * speed;
            

            //LANDING

           /* if ((dir.magnitude <= 4f) & (hit.collider.tag == "Planet") & (!landed))
            {
                landingScale = new Vector3(0.2f, 0.2f, 0);
                transform.localScale = Vector3.Lerp(transform.localScale, landingScale, Time.deltaTime * landingSpeed);
                speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 3);
                if (transform.localScale == landingScale)
                {
                    spriteRenderer.enabled = false;
                    landed = true;
                    break;
                }
            }*/
            yield return null;
        }
        iMove = false;


        
    }

    IEnumerator FollowTo()
    {
        //MOVEMENT
        while (true)
        {   
            dir = curTarget.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            transform.position += transform.right * Time.deltaTime * speed;
            
            yield return null;
        }

    }
}
