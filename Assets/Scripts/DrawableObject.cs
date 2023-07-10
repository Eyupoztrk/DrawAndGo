using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawableObject : MonoBehaviour
{
   public Draw _draw;

   public bool canDraw = true;
   private bool canUp = false;

   private float drawTime;
   public float maxTime;

   public Slider timeSlider;
  


   public void OnDown()
   {
      Debug.Log("basıldı");
      GameManager.instance.PlayerPositions.Clear();
      GameManager.instance.players.Clear();
      _draw.DrawLine();
      canDraw = true;
      canUp = true;
   }

   private void Update()
   {
      timeSlider.value = drawTime;
   }

   public void OnDrag()
   {
      if (canDraw)
      {
         drawTime += Time.deltaTime;
         if (drawTime < maxTime)
         {
            Debug.Log("basılıyor");
            _draw.DrawLine();
         }
         else
         {
            //canDraw = false;
            canUp = true;
            OnUp();
         }
        
      }
     
   }

   public void OnUp()
   {
      if (canUp)
      {
         canDraw = false;
         canUp = false;
         GameManager.instance.SetPlayer();
         _draw._line.positionCount = 0;
         drawTime = 0;
      }
      
   }

   
}
