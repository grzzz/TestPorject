using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public GameObject prefab;
    //保存预制体的引用，通过拖动赋值了
    public Stack<GameObject> s = new Stack<GameObject>();
    //实例化一个栈集合s

    public void Creat()
    {
        GameObject a = ObjectPool.instance.Creat(ObjectPool.dictionaryKey.类型1,prefab, Vector3.zero, Quaternion.identity);
        //通过ObjectPool类的静态字段instance访问Creat方法，传递参数生成预制体
        //通过类名直接访问公开的枚举类型，传递枚举信息
        a.transform.SetParent(gameObject.transform);
        //获得预制体的引用后，设置父物体为当前脚本绑定的对象
        s.Push(a);
        //将生成的对象入栈
    }

    public void Delete()
    {
        if (s.Count >0)
        {
            ObjectPool.instance.Delete(ObjectPool.dictionaryKey.类型1, s.Pop());
            //当执行这个删除方法时，将栈集合的对象出栈，并通过ObjectPool类中的静态字段instance访问Delete方法，将其出栈对象隐藏
        }

    }


}
