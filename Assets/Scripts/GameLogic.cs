using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    Vector2 characterVelocityInPercent;
    Vector2 characterPositionInPercent;
    const float CharacterSpeed = 0.25f;
    private float HalfCharacterSpeed = Mathf.Sqrt(CharacterSpeed * CharacterSpeed + CharacterSpeed * CharacterSpeed) /2f;
    void Start()
    {
        NetworkedServerProcessing.SetGameLogic(this);
    }

    void Update()
    {
                
    }

    public void UpdateInput(int d, int clientID)
    {
         characterVelocityInPercent = Vector2.zero;
         
         if (d == InputDirections.UpRight)
         {
             characterVelocityInPercent.x = HalfCharacterSpeed;
             characterVelocityInPercent.y = HalfCharacterSpeed;
         }
         else if (d == InputDirections.UpLeft)
         {
             characterVelocityInPercent.x = -HalfCharacterSpeed;
             characterVelocityInPercent.y = HalfCharacterSpeed;
         }
         else if (d == InputDirections.DownRight)
         {
             characterVelocityInPercent.x = HalfCharacterSpeed;
             characterVelocityInPercent.y = -HalfCharacterSpeed;
         }
         else if (d == InputDirections.DownLeft)
         {
             characterVelocityInPercent.x = -HalfCharacterSpeed;
             characterVelocityInPercent.y = -HalfCharacterSpeed;
         }
         else if (d == InputDirections.Right)
         {
             characterVelocityInPercent.x = HalfCharacterSpeed;
         }
         else if (d == InputDirections.Left)
         {
             characterVelocityInPercent.x = -HalfCharacterSpeed;
         }
         else if (d == InputDirections.Up)
         {
             characterVelocityInPercent.y = HalfCharacterSpeed;
         }
         else if (d == InputDirections.Down)
         {
             characterVelocityInPercent.y = -HalfCharacterSpeed;
         }
         else if (d == InputDirections.NoInput)
            characterVelocityInPercent = Vector2.zero;
         
         NetworkedServerProcessing.SendMessageToClient(ServerToClientSignifiers.VelocityAndPosition + ","
         + characterVelocityInPercent.x + "," 
         + characterVelocityInPercent.y + ","
         + characterPositionInPercent.x + ","
         + characterPositionInPercent.y, clientID);
    }
}