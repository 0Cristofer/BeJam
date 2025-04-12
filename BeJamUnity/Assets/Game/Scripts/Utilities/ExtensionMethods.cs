using UnityEngine;
public static class ExtensionMethods
{

    public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return ((value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin);
    }

    public static int Remap(int value, int fromMin, int fromMax, int toMin, int toMax)
    {
        return (int)((value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin);
    }

}
