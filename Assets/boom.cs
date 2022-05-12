using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : Rod
{
    public void Bang(Vector3 pos,bool flag=false)
    {
        var hits = Physics2D.CircleCastAll(pos,1,Vector2.zero);
        foreach(var hit in hits)
        {
            if (hit.transform.tag == "gold")
            {
                Destroy(hit.transform.gameObject); 
            }
            else
            {
                if (hit.transform.tag == "boom")
                {
              hit.transform.GetComponent<boom>().   Bang(hit.point, true);
                }
            }
        }
        if (flag)
            Destroy(gameObject);
    }
}
