using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GrapplingHook : MonoBehaviour {

    DistanceJoint2D Joint;
    Vector3 Target;
    RaycastHit2D Hit;
    public float Distance = 10f;
    public LayerMask Mask;
    public float Step = 0.02f;
    public EquipmentChange equipmentchange;
    public float HookCooldown = 3;
    public bool HookOnCooldown = false;

    // Use this for initialization
    void Start()
    {
        Joint = GetComponent<DistanceJoint2D>();
        Joint.enabled = false;
        equipmentchange = FindObjectOfType<EquipmentChange>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Joint.distance >= 0.5f)
        {
            Joint.distance -= Step;
        }
        else
        {
            Joint.distance = Step;
        }


        if (Input.GetMouseButton(0) && equipmentchange.HookActive == true && HookOnCooldown == false)
        {
            Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Target.z = 0;

            Hit = Physics2D.Raycast(transform.position, Target - transform.position, Distance, Mask);

            if (Hit.collider != null && Hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                print("Hit" + Hit.collider.gameObject.name);
                Joint.enabled = true;
                Vector2 connectPoint = Hit.point - new Vector2(Hit.collider.transform.position.x, Hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / Hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / Hit.collider.transform.localScale.y;
                Joint.connectedAnchor = connectPoint;

                Joint.connectedBody = Hit.collider.gameObject.GetComponent<Rigidbody2D>();
                Joint.distance = Vector2.Distance(transform.position, Hit.point);
            }

        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            HookOnCooldown = true;
            Joint.enabled = false;
        }

        if (HookOnCooldown == true && HookCooldown > 0)
        {
            HookCooldown -= Time.deltaTime;
        }

        else if (HookOnCooldown == true && HookCooldown < 0)
        {
            HookCooldown = 3;
            HookOnCooldown = false;
        }
    }
}
