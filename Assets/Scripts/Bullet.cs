using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_fBulletSpeed;
    
    float m_fDeltaTime = 0f;

    uint m_uiKey = 0;
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_fDeltaTime < 5f)
        {
            this.transform.Translate(Vector3.forward * m_fBulletSpeed * Time.deltaTime);
            m_fDeltaTime += Time.deltaTime;
        }
        else
        {            
            Destroy(this.gameObject);
            GameObjectRemoveSystem.Instance.RemoveGameObj(m_uiKey);
            //Debug.Log(GameObjectRemoveSystem.Instance.m_DicRemoveObj.Count);
        }
    }

    public void SetKey(uint uiKey)
    {
        m_uiKey = uiKey;
    }
}
