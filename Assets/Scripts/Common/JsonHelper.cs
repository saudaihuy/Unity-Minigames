﻿using System;
using System.Linq.Expressions;
using UnityEngine;

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

    public static string FixArrayJson(string jsonString, string arrayItemName )
    {
        jsonString = "{\""+arrayItemName+"\":" + jsonString + "}";
        return jsonString;
    }

    public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
    {
        return ((MemberExpression)memberAccess.Body).Member.Name;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
