using System.ComponentModel.DataAnnotations;

namespace Methods;
public static class ArrayMethodsLibrary
{
    public static double FindMinimum(double[] array){
        if (array == null || array.Length == 0) throw new ArgumentException("Error");
        double min = array[0];
        for (int i = 1; i < array.Length; i++) min = Math.Min(min, array[i]);
        return min;
    }

    public static double FindMaximum(double[] array){
        if (array == null || array.Length == 0) throw new ArgumentException("Error");
        double max = array[0];
        for (int i = 1; i < array.Length; i++) max = Math.Max(max, array[i]);
        return max;
    }

    public static double FindAverage(double[] array){
        if (array == null || array.Length == 0) throw new ArgumentException("Error");
        double sum = 0;
        for (int i = 0; i < array.Length; i++) sum += array[i] / array.Length;
        return sum;
    }

    public static double FindMedian(double[] array){
        if (array == null || array.Length == 0) throw new ArgumentException("Error");
        double[] sort_array = array;
        Array.Sort(sort_array);
        int middleIndex = array.Length / 2;
        if (array.Length % 2 == 0) return (array[middleIndex - 1] + array[middleIndex]) / 2;
        else return array[middleIndex];
    }

    public static double FindGeometricAverage(double[] array){
        if (array == null || array.Length == 0) throw new ArgumentException("Error");
        double answer = 1;
        for(int i = 0; i < array.Length; i++){
            if(array[i] <= 0) throw new ArgumentException("Error");
            answer *= Math.Pow(array[i], 1.0 / array.Length);
        }
        return answer;
    }

    
}
