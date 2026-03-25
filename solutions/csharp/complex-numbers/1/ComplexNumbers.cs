using System;

public struct ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real() => _real;

    public double Imaginary() => _imaginary;

    // This implicit operator solves the "cannot convert from int to ComplexNumber" errors
    public static implicit operator ComplexNumber(double d) => new ComplexNumber(d, 0);

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(_real + other.Real(), _imaginary + other.Imaginary());
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(_real - other.Real(), _imaginary - other.Imaginary());
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        // (a + bi)(c + di) = (ac - bd) + (ad + bc)i
        double newReal = _real * other.Real() - _imaginary * other.Imaginary();
        double newImaginary = _real * other.Imaginary() + _imaginary * other.Real();
        return new ComplexNumber(newReal, newImaginary);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        // (a + bi) / (c + di) = [(ac + bd) / (c^2 + d^2)] + [(bc - ad) / (c^2 + d^2)]i
        double divisor = Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2);
        
        if (divisor == 0) throw new DivideByZeroException("Cannot divide by a complex zero.");

        double newReal = (_real * other.Real() + _imaginary * other.Imaginary()) / divisor;
        double newImaginary = (_imaginary * other.Real() - _real * other.Imaginary()) / divisor;
        return new ComplexNumber(newReal, newImaginary);
    }

    public double Abs()
    {
        return Math.Sqrt(Math.Pow(_real, 2) + Math.Pow(_imaginary, 2));
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(_real, -_imaginary);
    }

    public ComplexNumber Exp()
    {
        // e^(a + bi) = e^a * (cos(b) + i * sin(b))
        double expReal = Math.Exp(_real);
        return new ComplexNumber(expReal * Math.Cos(_imaginary), expReal * Math.Sin(_imaginary));
    }
}