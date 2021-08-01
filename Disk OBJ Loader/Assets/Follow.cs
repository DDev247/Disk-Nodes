using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject FollowObject;
    public void Child()
    {
        this.transform.parent = FollowObject.transform;
    }
}
