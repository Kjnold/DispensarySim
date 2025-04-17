using UnityEngine;

public class Coputer : MonoBehaviour
{
    private bool FanPower = true;
    private bool ComputerPower = true;

    void Update()
    {
        if(CheckFanPower()){  SpinFans();  }
    }
    private void SpinFans(){
        // find all objects within the object with the name "FanPole" and slowly rotate them on the Y axis
        foreach(Transform fan in transform.Find("FanPole")){
            fan.Rotate(0, 1, 0); // Rotate the fan on the Y axis
        }
    }

    private bool CheckFanPower(){
        if(FanPower && ComputerPower){
            return true;
        }
        return false;
    }
}




/* 
* This script will control all the computer related functions
* such as the fans and the power state of the computer.
* The script will be attached to the computer object
* this script will also control the RGB lights on the RAM and soon the fans
*/