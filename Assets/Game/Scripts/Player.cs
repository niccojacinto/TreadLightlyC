using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    FPSPistol gun;
    private bool m_Interact;
    private bool m_Shoot;
    private bool m_aim;
    public bool hasGun;
    private int ammo;
    public float firingDelay;

	// Use this for initialization
	void Start () {
        gun = GameObject.Find("/FPSController/FirstPersonCharacter/FPSPistol").GetComponent<FPSPistol>();

    }
	
	// Update is called once per frame
	void Update () {
        CheckInput();
    }

    void FixedUpdate() {
        if ((m_aim && gun.currentState == FPSPistol.PistolState.NORMAL) || (m_aim && gun.currentState == FPSPistol.PistolState.AIMING))  {
            Aim();
        } else if (m_aim && gun.currentState == FPSPistol.PistolState.AIMED ) {
            Aim();
        } else if (!m_aim && gun.currentState == FPSPistol.PistolState.AIMED) {
            Release();
        }
    }

    void CheckInput() {
        m_Interact = CrossPlatformInputManager.GetButtonDown("Interact");

            
        m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire1");

        m_aim = CrossPlatformInputManager.GetAxis("Fire2") > 0; ;
        

        
    }


    public Collider CheckRay() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10)) {
            return hit.collider;
        }
        return null;
    }

    public void Shoot() {
        gun.Shoot();
    }

    public void Aim() {
        gun.Aim();
        if (m_Shoot && gun.currentState == FPSPistol.PistolState.AIMED) Shoot();
    }
    public void Release() {
        gun.Release();
    }

}
