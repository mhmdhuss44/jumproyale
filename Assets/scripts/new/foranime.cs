using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foranime : MonoBehaviour
{

    Animator mhmd;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        mhmd = transform.GetChild(3).GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                mhmd.SetBool("iswalking", true);
            }
            else
            {
                mhmd.SetBool("iswalking", false);
            }

        }
    }
}
