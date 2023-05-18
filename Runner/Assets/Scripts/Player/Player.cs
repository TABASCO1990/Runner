using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged; // событие оповещает о изменении жизней 
    public event UnityAction Died; //событие оповещает о смерти игрока

    private void Start()
    {
        HealthChanged?.Invoke(_health); //Чтобы на страрте отображалось начальное количество жизней
    }

    //метод, принять урон себе
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    //метод логики смерти
    public void Die()
    {
        Died?.Invoke();
    }
}
