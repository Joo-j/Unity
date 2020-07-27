using UnityEngine;
using System.Collections;

public class BoxPush : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;
  
    // Update is called once per frame
    void Update()
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
        //raycast 선을 한번에 두개를 할 수 없을까

        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
        {
            box = hit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<BoxPull>().beingPushed = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                box.GetComponent<BoxPull>().beingPushed = false;
            }
        } 
    }


    void OnDrawGizmos() //위아래 양옆 4방향 다
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * transform.localScale.x * distance);

    }
}