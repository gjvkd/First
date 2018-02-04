using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public float m_fMoveSpeed;
    public float m_fTerm;
    
    // 총구 오브젝트
    public GameObject m_objBulletPoint = null;

    // 총알 오브젝트
    Bullet m_objBullet = null;    
    float m_fDeltaTime = 0f;
    Vector3 m_vLookdirection;
    uint m_uiObjCount = 0;

    // 이동 제한
    Vector3 m_vecLeft = new Vector3(-4f, 0f, 0f);
    Vector3 m_vecRight = new Vector3(4f, 0f, 0f);
    Vector3 m_vecForward = new Vector3(0f, 0f, -3f);
    Vector3 m_vecBack = new Vector3(0f, 0f, -5f);


    ///////////////////////////////////////////////
    public float fX = 0f;
    public float fZ = 0f;
    ///////////////////////////////////////////////

    void Awake()
    {
        // 총알 프리팹 가져오기
        m_objBullet = Resources.Load<Bullet>("Prefabs/BasicBullet");
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_objBulletPoint)
        {
            // 총알 발사
            Fire();

            // 캐릭터 이동
            Move();
        }
    }

    void Fire()
    {
        if (m_fTerm < m_fDeltaTime)
        {               
            Bullet obj = Instantiate(m_objBullet, m_objBulletPoint.transform.position + new Vector3(0, 0, 0.5f), m_objBulletPoint.transform.rotation);
            obj.SetKey(m_uiObjCount);
            GameObjectRemoveSystem.Instance.AddGameObj(m_uiObjCount++, obj);
            
            m_fDeltaTime = 0f;            
        }
        else
            m_fDeltaTime += Time.deltaTime;
    }

    void Move()
    {
        // 
        fX = Input.GetAxisRaw("Vertical");
        fZ = Input.GetAxisRaw("Horizontal");

        Vector3 vecDir = Vector3.zero;
        float fDirPOS = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vecDir = Vector3.left * m_fMoveSpeed * Time.deltaTime;
            fDirPOS = this.transform.position.x + vecDir.x;

            if (m_vecLeft.x < fDirPOS)
                this.transform.Translate(vecDir);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vecDir = Vector3.right * m_fMoveSpeed * Time.deltaTime;
            fDirPOS = this.transform.position.x + vecDir.x;

            if (fDirPOS < m_vecRight.x)
                this.transform.Translate(vecDir);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vecDir = Vector3.forward * m_fMoveSpeed * Time.deltaTime;
            fDirPOS = this.transform.position.z + vecDir.z;

            if (fDirPOS < m_vecForward.z)
            {
                this.transform.Translate(vecDir);
                m_objBulletPoint.transform.Rotate(new Vector3(-fX / 2f, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vecDir = Vector3.back * m_fMoveSpeed * Time.deltaTime;
            fDirPOS = this.transform.position.z + vecDir.z;

            if (m_vecBack.z < fDirPOS)
            {
                this.transform.Translate(vecDir);
                m_objBulletPoint.transform.Rotate(new Vector3(-fX / 2f, 0, 0));
            }
        }
    }
}
