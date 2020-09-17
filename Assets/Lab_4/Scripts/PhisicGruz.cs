using UnityEngine;
using System;

#region Физика
public class PhisicGruz : MonoBehaviour {

    //Поля
    private float mass;//Масса шара
    private bool MagniteObject;// объект примагничен
    private double deltaForce;//измениени силы действующей на шар
    private double time;// Изменине во времени
    private Vector3 Location;//Позиция шара в начале
    private GameObject Gruz;// Шар
    private Vector3 Angle;// Угол - (фи)
    private Vector3 Force;// Сила взаимодействия
    //================================================================
    //Методы
    public void HitTest()
    {
        Force *= -1;
    }//Удар
    public void SetLocation(Quaternion newLocation)
    {
        Angle = Angle.Load(newLocation);
        Force = GetForce();
    }//Действие внешней силы
    public Vector3 NewCoord()
    {
        if (!MagniteObject)
        {
            if (Check())
            {

                time += deltaForce;
            }
            else
            {
                time -= deltaForce;
            }
            return Force.Charp((int)time);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }//движения шара
    private Vector3 GetForce()
    {

        return Angle.Minus(Location);

    }//Получения силы действия
    private bool Check()
    {
        if (Gruz.transform.rotation.x > 0)
        {
            return true;
        }
        return false;
    }//Колебательный контур
    public float AngleFi()//Получает макимальное изменинеия в координате колебания
    {
        return Math.Abs(Force.x * (float)((deltaForce) + time) / mass);
    }
    /// <summary>
    /// Если обеъект примагничен , то он будет размагничен, и наооброт.
    /// </summary>
    public void SetMagnite(bool value)
    {
        MagniteObject = value;
    }
    public void PayOnForce()//Погашение силы
    {
        Force = Force.DeltaAngel(1.01f);
    }
    //================================================================
    //Конструкторы
    public void SetSpeed(Vector3 speed, float Mass, bool Fly)//Устонвока новой скорости по формуле u=(m1-m2)u1/m1+m2 и для второго шарика u2=2m1v1/m1+m2
    {
        if (Fly)//Если груз находился в движения тогда он u1 , если нет то u2
        {
            Force = speed.Charp(((mass - Mass) / (mass + Mass)));
        }
        else
        {
            Force = speed.Charp(((2 * mass) / (mass + Mass)));
        }
    }
    public void Restart()
    {
        Force = new Vector3(0, 0, 0);
        time = 0;
    }
    //======================================================================
    //Constructor
    public PhisicGruz(GameObject obj, float Mass)
    {
        mass = Mass;
        Location = new Vector3();
        Gruz = obj;
        Angle = new Vector3();
        time = 1;
        deltaForce = 0.2;
        MagniteObject = false;
    }

    //================================================================
}
#endregion
