using UnityEngine;

public class GoGo : MonoBehaviour
{
    [SerializeField]
    float goSpeed, go;
    [SerializeField]
    float Rotating, rotate;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    bool loaded;



    void Start()
    {

    }

    void Update()
    {
        rotate = Input.GetAxis("Horizontal") * Rotating;
        go = Input.GetAxis("Vertical") * goSpeed;

        transform.Translate(0, go, 0);
        transform.Rotate(0, 0, -rotate);

        
    }

    private void LateUpdate()
    {
        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -5);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("present") && !loaded) 
        {
            loaded = true;  
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ablage"))
        {
            if (loaded)
            {
                spawn();
            }

            loaded = false;
        }

        if (other.CompareTag("SpeedUp"))
        {
            goSpeed += 0.015f;
            Destroy(other.gameObject);
        }

    }

    void spawn()
    {

    }




}
