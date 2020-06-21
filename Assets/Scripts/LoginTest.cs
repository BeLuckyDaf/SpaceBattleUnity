using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

public class LoginTest : MonoBehaviour
{
    [SerializeField] private Managers.ManagerContainer _managers;

    private void Start()
    {
        _managers.EventManager.OnSessionManagerReady.AddListener(() =>
        {
            _managers.SessionManager.LoginWithPassword("beluckydaf@yandex.ru", "12121212");
        });
    }
}
