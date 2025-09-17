using System;
using System.Diagnostics;
using System.Threading;

class Checker
{
    // Pure functions for each vital check
    public static bool IsTemperatureOk(float temperature)
    {
        return temperature >= 95 && temperature <= 102;

        // Introduce a bug: allow only temperature >= 96 (should be 95)
        //return temperature >= 96 && temperature <= 102;
    }

    public static bool IsPulseOk(int pulseRate)
    {
        return pulseRate >= 60 && pulseRate <= 100;
    }

    public static bool IsSpo2Ok(int spo2)
    {
        return spo2 >= 90;
    }

    // Reusable function for blinking alert
    private static void BlinkWarning()
    {
        for (int i = 0; i < 6; i++)
        {
            Console.Write("\r* ");
            Thread.Sleep(1000);
            Console.Write("\r *");
            Thread.Sleep(1000);
        }
    }

    // Original function with I/O and blinking (for real usage)
    public static bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        if (!IsTemperatureOk(temperature))
        {
            Console.WriteLine("Temperature critical!");
            BlinkWarning();
            return false;
        }

        if (!IsPulseOk(pulseRate))
        {
            Console.WriteLine("Pulse Rate is out of range!");
            BlinkWarning();
            return false;
        }

        if (!IsSpo2Ok(spo2))
        {
            Console.WriteLine("Oxygen Saturation out of range!");
            BlinkWarning();
            return false;
        }

        Console.WriteLine("Vitals received within normal range");
        Console.WriteLine($"Temperature: {temperature}, Pulse: {pulseRate}, SO2: {spo2}");
        return true;
    }

    // New silent version for unit testing (no I/O, no delays)
    public static bool VitalsOkSilent(float temperature, int pulseRate, int spo2)
    {
        return IsTemperatureOk(temperature) &&
               IsPulseOk(pulseRate) &&
               IsSpo2Ok(spo2);
    }
}
