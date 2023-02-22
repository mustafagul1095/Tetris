using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
 public static int ToGrid(float val)
 {
  return Mathf.RoundToInt(val / 10);
 }
}
