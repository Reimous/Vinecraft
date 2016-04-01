using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

    public GameObject Cube;

	// Use this for initialization
	void Start () {
	    
	}

    

    // Update is called once per frame
    void Update () {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        RaycastHit rh = new RaycastHit();

        
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rh);
        CheckRayCastForHit(rh);

    }


private void CheckRayCastForHit(RaycastHit raycastHit)
    {
        
            Collider collision = raycastHit.collider;
              

        if (collision != null && collision.transform.tag.Equals("Cube") && (collision.isTrigger))
            {
            if (collision.GetComponent<Renderer>() != null)
            {
                collision.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }


            if (Input.GetButtonDown("Fire"))
            {
                Debug.Log(collision.gameObject.name + " detected");
                GameObject newCube = Instantiate(Cube);
                newCube.transform.position = GetNewCubePosition(collision.transform);
                        
            }
              
            //targets.Add(collision.gameObject);
        }
    }

    private Vector3 GetNewCubePosition(Transform faceCube)
    {
        
        Transform oldCube = faceCube.parent.transform;
        Vector3 positionCube = oldCube.position;

        switch (faceCube.gameObject.name)
        {
            case "X+":
                positionCube.x = oldCube.position.x + oldCube.localScale.x;
                break;
            case "X-":
                positionCube.x = oldCube.position.x - oldCube.localScale.x;
                break;
            case "Y+":
                positionCube.y = oldCube.position.y + oldCube.localScale.y;
                break;
            case "Y-":
                positionCube.y = oldCube.position.y - oldCube.localScale.y;
                break;
            case "Z+":
                positionCube.z = oldCube.position.z + oldCube.localScale.z;
                break;
            case "Z-":
                positionCube.z = oldCube.position.z - oldCube.localScale.z;
                break;

            default:
                break;
        }         
            
        return positionCube;
    }


    private Vector3 GetNewCubePositionRelativeToPlayer(Transform oldCube)
    {
        Vector3 positionCube = transform.position - oldCube.position;

        positionCube.x = Mathf.Floor(positionCube.x);
        positionCube.y = Mathf.Floor(positionCube.y);
        positionCube.z = Mathf.Floor(positionCube.z);

        if (positionCube.x > 0)
        {
            positionCube.x = oldCube.position.x + oldCube.localScale.x;
        }
        else if (positionCube.x < 0)
        {
            positionCube.x = oldCube.position.x - oldCube.localScale.x;
        }
        else
        {
            positionCube.x = oldCube.position.x;
        }

        if (positionCube.y > 0)
        {
            positionCube.y = oldCube.position.y + oldCube.localScale.y;
        }
        else if (positionCube.y < 0)
        {
            positionCube.y = oldCube.position.y - oldCube.localScale.y;
        }
        else
        {
            positionCube.y = oldCube.position.y;
        }

        if (positionCube.z > 0)
        {
            positionCube.z = oldCube.position.z + oldCube.localScale.z;
        }
        else if (positionCube.z < 0)
        {
            positionCube.z = oldCube.position.z - oldCube.localScale.z;
        }
        else
        {
            positionCube.z = oldCube.position.z;
        }


        return positionCube;
    }

}
