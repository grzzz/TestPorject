using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public enum dictionaryKey //定义一个枚举类型，供访问创建对象池字典时使用，避免字典索引混乱
    {
        类型1,
        类型2
    }

    public static ObjectPool instance;//创建静态变量
    Dictionary<dictionaryKey, Stack<GameObject>> pools = new Dictionary<dictionaryKey, Stack<GameObject>>();
    //实例化一个字典集合，字典索引枚举，字典内容为stark集合
    //Stack<GameObject> pool = new Stack<GameObject>();//实例化一个栈集合

    void Start()
    {
        instance = this;
        //instance保存该脚本的引用
    }

    /// <summary>
    /// 供instance访问的伪删除方法，需要传递一个对象进来
    /// </summary>
    public void Delete(dictionaryKey key,GameObject g)
    {
        g.SetActive(false);
        //将传递的对象设置隐藏
        pools[key].Push(g);//pools[角标]的stack集合push推入对象
        
    }
    
    /// <summary>
    /// 供instance访问的伪创建方法，需要传递一个对象进来
    /// </summary>
    public GameObject Creat(dictionaryKey key,GameObject prefabs, Vector3 pos, Quaternion qua)
    {
        GameObject g = null;
        if (pools.ContainsKey(key))
        {
            //每次调用此方法时，将g重置为null。
            if (pools[key].Count > 0)//如果栈集合中有对象
            {
                g = pools[key].Pop();
                //将栈集合执行出栈，并将出栈的对象赋值给g
                g.SetActive(true);
                //设置该对象显示
                g.transform.position = pos;
                //设置该对象位置为传递进来的pos
                g.transform.rotation = qua;
                //设置该对象角度为传递进来的qua
            }
            else//如果栈集合中没有对象
            {
                g = Instantiate(prefabs, pos, qua);
                //用传递进来的参数生成一个对象 
            }
        }
        else
        {
            pools.Add(key,new Stack<GameObject>());
            g = Instantiate(prefabs, pos, qua);
        }
       
        return g;//最终返回g
    }

}
