using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTrans;
    private float InitialZ;

    void Start()
    {
        InitialZ = this.transform.position.z;
    }

    void Update()
    {
        Vector3 target = PlayerTrans.position;
        target.z = InitialZ;
        this.transform.position = Vector3.Lerp(this.transform.position, target, 0.01f);
    }
}
