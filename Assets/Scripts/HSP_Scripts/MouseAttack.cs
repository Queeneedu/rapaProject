using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    public GameObject spiralRocket;
    public Transform firePosition;
    public float coolTime = 5.0f;

    float elapsedTime = 0;

    void Start()
    {
        // 경과시간에 쿨타임을 넣고
        elapsedTime = coolTime;
    }

    void Update()
    {
        // 마우스 왼쪽 클릭을 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 레이를 생성하고
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 레이가 생성되었을 때 닿은 오브젝트의 정보를 담을 변수를 생성
            RaycastHit hitInfo;

            // 레이를 발사한다.
            if (Physics.Raycast(ray, out hitInfo))
            {
                print(hitInfo.transform.name);
            }
        }

        elapsedTime += Time.deltaTime;

        // 마우스 오른쪽 클릭을 하고, 경과시간이 쿨타임의 시간보다 커진다면
        if (Input.GetMouseButtonDown(1) && elapsedTime >= coolTime)
        {
            // 총알 프리팹을 생성한다.
            GameObject go = Instantiate(spiralRocket);

            // 총알을 firePosition으로 회전시킨다.
            go.transform.rotation = firePosition.transform.rotation;
            // 총알의 생성 위치를 firePosition으로 위치시킨다.
            go.transform.position = firePosition.transform.position;

            // 경과시간을 초기화한다.
            elapsedTime = 0;
        }
    }
}
