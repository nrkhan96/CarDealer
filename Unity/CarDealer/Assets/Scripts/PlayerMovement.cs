using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2000f;

    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] float swerveSpeed = 0.5f;
    [SerializeField] float maxSwerveAmount = 1f;

    [SerializeField] List<Transform> allCars;
    [SerializeField] float Smooth = 0.9f;
    [SerializeField] Vector3 offset = new Vector3(0,0,-1);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void FixedUpdate()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        rb.velocity = new Vector3(swerveAmount,0,speed*Time.deltaTime);
        SetfollowerXPosition();
    }

    private void SetfollowerXPosition()
    {
        var counter = 0;
        foreach (var car in allCars)
        {
            if (counter == 0)
            {
                counter++;
                continue;
            }

            var prevCar = allCars[counter - 1];

            //set car pos without x
            var carPosWithoutX = prevCar.position + offset;
            carPosWithoutX.x = car.position.x;
            car.position = carPosWithoutX;

            //create end pos & current pos
            var endPos = prevCar.position + offset;
            var currentPos = car.position;

            Vector3 smoothPosition = Vector3.Lerp(currentPos, endPos, Smooth);
            car.position = smoothPosition;

            counter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            allCars.Add(other.transform);
        }
    }
}
