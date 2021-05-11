using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveSphere : MonoBehaviour
{
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
    [System.Serializable]
    public class transformData
    {
        public Vector3 position;
        public Vector3 rotation;
        public float time;
    }
    transformData[] temp_data_arr;
    // Start is called before the first frame update
    void Start()
    {
        string json_string = File.ReadAllText("D:/360_collab_data/data-3.json");
        //Debug.Log(json_string);
        temp_data_arr = JsonHelper.FromJson<transformData>(json_string);
        Debug.Log(temp_data_arr[0].position.x);
        //List<transformData> complete_data = temp_data_arr.OfType<transformData>().ToList();
        //Debug.Log(complete_data[0].position);
    }

    
    public bool update_transform = false;
    public void Update_trandform_bool(bool val)
    {
        update_transform = val;
    }
    int i = 0;
    void FixedUpdate()
    {
        if (update_transform)
        {
            transform.position = new Vector3(temp_data_arr[i].position.x, temp_data_arr[i].position.y, temp_data_arr[i].position.z);
            transform.eulerAngles = new Vector3(temp_data_arr[i].rotation.x, temp_data_arr[i].rotation.y, temp_data_arr[i].rotation.z);
            i++;
        }   
    }
}
