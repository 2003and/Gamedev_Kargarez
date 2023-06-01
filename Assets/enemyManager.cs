using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static enemyManager instance { get; private set; }
    Transform[] allChildren;
    // Start is called before the first frame update
    void Awake(){
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    void Start()
    {
        allChildren = new Transform[transform.childCount];
        int i = 0;
        while (i < transform.childCount){
            allChildren[i] = transform.GetChild(i);
            i++;
        }
        Debug.Log("я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума я нормальный я не схожу с ума ");
    }

    public void stunAll() {
        foreach (var i in allChildren)
        {
            if (i ?? false) {
                i.gameObject.GetComponent<Karga_1>().Stun(100);
            }
        }
    }
}
