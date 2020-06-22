/*  This script was created by:
 *  Umut Zenger
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Members

    #endregion

    #region Private Members
    [SerializeField]
    private float speed = 1;
    #endregion
    
    #region Public Functions
    
    #endregion
    
    #region Private Functions
    
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, Input.GetAxis("Horizontal")*Time.deltaTime * 90f);
        GetComponent<Rigidbody>().velocity = (transform.forward * Input.GetAxis("Vertical") * speed);
        //GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical"));
    }
    #endregion
}
