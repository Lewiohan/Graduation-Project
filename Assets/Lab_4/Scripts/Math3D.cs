using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Класс для рассширения
public static class Math3D {
    public static float MassGrus2 = 0.07f;//Масса первого грузика 7г 0.007кг
    public static float MassGruz1 = 0.1f;//Масса второго грузика 10г 0.01кг
    public static Vector3 Speed1 = new Vector3();
    public static Vector3 Speed2 = new Vector3();
    public static bool OnTime = false;

    public static Vector3 Minus(this Vector3 element1, Quaternion element)
    {
        element1.x -= element.x;
        element1.y -= element.y;
        element1.z -= element.z;
        return element1;
    }
    /// <summary>
    /// Разница векторов
    /// </summary>
    /// <param name="element1"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public static Vector3 Minus(this Vector3 element1, Vector3 element)
    {
        element1.x -= element.x;
        element1.y -= element.y;
        element1.z -= element.z;
        return element1;
    }
    /// <summary>
    /// Сумма векторов
    /// </summary>
    /// <param name="element1"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public static Vector3 Plus(this Vector3 element1, Vector3 element)
    {
        element1.x += element.x;
        element1.y += element.y;
        element1.z += element.z;
        return element1;
    }
    /// <summary>
    /// Получения части угла
    /// </summary>
    /// <param name="element1"></param>
    /// <param name="delta">Какая часть угла</param>
    /// <returns></returns>
    public static Vector3 DeltaAngel(this Vector3 element1, float delta)
    {
        element1.x /= delta;
        element1.y /= delta;
        element1.z /= delta;
        return element1;
    }
    /// <summary>
    /// Преобразования из Quartion в Vector3
    /// </summary>
    /// <param name="elem">Vector3</param>
    /// <param name="Angle">Позиция угла которые будут преообразованы в Vector3</param>
    /// <returns>Vector3</returns>
    public static Vector3 Load(this Vector3 elem, Quaternion Angle)
    {
        elem.x = Angle.x;
        elem.y = Angle.y;
        elem.z = Angle.z;
        return elem;
    }
    public static Vector3 Load(this Vector3 elem, Vector3 Angle)//Перегрузка 1
    {
        elem.x = Angle.x;
        elem.y = Angle.y;
        elem.z = Angle.z;
        return elem;
    }
    public static Quaternion OnLoad(this Vector3 vec)
    {
        Quaternion elem = new Quaternion();
        elem.x = vec.x;
        elem.y = vec.y;
        elem.z = vec.z;
        return elem;
    }
    /// <summary>
    /// Умножения вектора на число
    /// </summary>
    /// <param name="elem">Вектор</param>
    /// <param name="value">Число</param>
    /// <returns>Будет вектор</returns>
    public static Vector3 Charp(this Vector3 elem, float value)
    {
        elem.x *= value;
        elem.y *= value;
        elem.z *= value;
        return elem;
    }
}
#endregion