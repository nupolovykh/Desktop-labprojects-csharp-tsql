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
        double[] sorted_array = new double[array.Length];
        for(int i = 0; i < array.Length; i++) sorted_array[i] = array[i];
        Array.Sort(sorted_array);
        int middleIndex = array.Length / 2;
        if (array.Length % 2 == 0) return (sorted_array[middleIndex - 1] + sorted_array[middleIndex]) / 2;
        else return sorted_array[middleIndex];
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
