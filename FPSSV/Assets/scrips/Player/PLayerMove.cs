using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMove : MonoBehaviour
{

    [Header("Inputs")]
    [HideInInspector]
    public float Horizontal;
    [HideInInspector]
    public float Vertical;
    [HideInInspector]
    public bool jump;
    [HideInInspector]
    public bool Kjump;
    [Header("Stats")]
    public float speed;
    public float airSpeed;
    public float jumpForce;
    public float fallmulty;
    public float lowfallmulty;
    [SerializeField]
    private bool onGround;
    [Header("Config")]
    public LayerMask layer;
    public float toGround;


    private float currentspeed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        onGround = onGroud();
        jumping();

        if (Horizontal != 0 || Vertical != 0)
            move();

       
    }


    void move()
    {

        transform.position += transform.forward * currentspeed * Time.deltaTime * Vertical;
        transform.position += transform.right * currentspeed * Time.deltaTime * Horizontal;

    }

    void jumping()
    {
        if (jump)
        {
            rb.velocity = Vector3.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallmulty - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Kjump)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowfallmulty - 1) * Time.deltaTime;
        }
    }

    bool onGroud()
    {
        bool r = false;

        Vector3 origin = transform.position + (Vector3.up);

        Vector3 dir = -Vector3.up;
        float dis = toGround + 0.3f;
        RaycastHit hit;
        if (Physics.Raycast(origin, dir, out hit, dis, layer))
        {
            currentspeed = speed;
            r = true;
        }
        else
        {
            currentspeed = airSpeed;

        }

        return r;
    }

}
