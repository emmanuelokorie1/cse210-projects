using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // 1. Default constructor: initializes to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Single parameter constructor: initializes to whole_number/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // 3. Two parameter constructor: initializes to top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom != 0 ? bottom : 1; // Enforce invariant: denominator cannot be zero
    }

    // Getter and Setter for _top
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for _bottom with validation
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Error: Denominator cannot be zero. Value unchanged.");
        }
    }

    // Returns fraction as a string, e.g. "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns fraction as a decimal value, e.g. 0.75
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
