using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인게임에서 생성되는 모든 오브젝트의 파괴는 여기서 한다.
// 총알, 적, 장애물 등..

public class GameObjectRemoveSystem : MonoBehaviour
{
    // 싱글턴 변수
    public static GameObjectRemoveSystem Instance = null;

    public Dictionary<uint, Bullet> m_DicRemoveObj = new Dictionary<uint, Bullet>();

    float m_fDeltaTime = 0f;    

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void AddGameObj(uint uiKey, Bullet obj)
    {
        m_DicRemoveObj.Add(uiKey, obj);
    }

    public void RemoveGameObj(uint uiKey)
    {
        Bullet bullet = m_DicRemoveObj[uiKey];
        Destroy(bullet.gameObject);
        m_DicRemoveObj.Remove(uiKey);
    }

    public void RemoveGameObjAll()
    {
        m_DicRemoveObj.Clear();
    }
}
