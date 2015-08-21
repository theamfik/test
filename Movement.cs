using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
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
    public GameObject planetPanel;




    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (iMove == true)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = Move(hit.point);
            StartCoroutine(moveCoroutine);

        }
    }

   public IEnumerator Move(Vector3 target)
    {

        iMove = true;
        while (true)
        {

            //TAKEOFF

            if (landed)
            {
                takeOffScale = new Vector3(0.5f, 0.4f, 0);
                spriteRenderer.enabled = true;
                transform.localScale = Vector3.Lerp(transform.localScale, takeOffScale, Time.deltaTime * 10f);
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
            dir = target - transform.position;

            //LANDING

            if ((dir.magnitude <= 4f) & (hit.collider.tag == "Planet") & (!landed))
            {
                landingScale = new Vector3(0.2f, 0.2f, 0);
                transform.localScale = Vector3.Lerp(transform.localScale, landingScale, Time.deltaTime * landingSpeed);
                speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 3);
                if (transform.localScale == landingScale)
                {
                    spriteRenderer.enabled = false;
                    landed = true;
                    planetPanel.SetActive(true);
                    planetPanel.GetComponent<PlanetUI>().Setup(hit.transform.GetComponent<Planet>());
                    break;
                }
            }
            yield return null;
        }
        iMove = false;
    }
}
