using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
 
        // 왼쪽 화살표
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(0, 1.4f, 0);

        }

        // 오른쪽 화살표
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(0, -1.4f, 0);

        }

        //y 이동제한
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);  //위 아래 넘어가지 않도록
        transform.position = pos;

    }
}
