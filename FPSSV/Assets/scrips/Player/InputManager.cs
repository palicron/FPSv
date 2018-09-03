using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PLayerMove))]
public class InputManager : MonoBehaviour {

    [Header("Inputs")]
    [SerializeField]
    private float Horizontal;
    [SerializeField]
    private float Vertical;
    [SerializeField]
    private bool fire1;
    [SerializeField]
    private bool fire2;
    [SerializeField]
    private bool space;
    [SerializeField]
    private float mousex;
    [SerializeField]
    private float mousey;
    [SerializeField]
    private bool Jump;
    [SerializeField]
    private bool JumpConst;

    [Header("Controlers")]
    private PlayerLook look;
    private PLayerMove move;


    // Use this for initialization
    void Start () {
        look = this.GetComponentInChildren<PlayerLook>();
        move = this.GetComponent<PLayerMove>();
        

	}
	
	// Update is called once per frame
	void Update () {

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        mousex = Input.GetAxis("Mouse X");
        mousey = Input.GetAxis("Mouse Y");
        Jump = Input.GetButtonDown("Jump");
        JumpConst = Input.GetButton("Jump");
        UpdateInputs();
    }


    void UpdateInputs()
    {
        look.mouseX = mousex;
        look.mouseY = mousey;
        move.Horizontal = Horizontal;
        move.Vertical = Vertical;
        move.jump = Jump;
        move.Kjump = JumpConst;
    }
}
