using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed; // 인스펙터 창에서 설정할 수 있도록 public 변수 추가
    float hAxis;
    float vAxis;
    bool walkDown;

    Vector3 moveVec;

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxisRow() : Axis 값을 정수로 반환하는 함수
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        walkDown = Input.GetButton("Walk");

        // normalized : 방향 값이 1로 보정된 벡터
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (walkDown ? 0.3f : 1f) * Time.deltaTime;

        animator.SetBool("isRun", moveVec != Vector3.zero);
        animator.SetBool("isWalk", walkDown);

        // 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);

        // #7. 카메라 이동

    }
}
