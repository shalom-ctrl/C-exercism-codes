using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        Coord1 = c1;
        Coord2 = c2;
        Coord3 = c3;
        Coord4 = c4;
    }

    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }

    // Helper to calculate the longest side of this specific plot
    public double GetMaxSide()
    {
        return new[]
        {
            GetSideLength(Coord1, Coord2),
            GetSideLength(Coord2, Coord3),
            GetSideLength(Coord3, Coord4),
            GetSideLength(Coord4, Coord1)
        }.Max();
    }

    private double GetSideLength(Coord a, Coord b)
    {
        // Using Pythagorean theorem: sqrt((x2-x1)^2 + (y2-y1)^2)
        return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
    }
}

public class ClaimsHandler
{
    private readonly HashSet<Plot> _claims = new();
    private Plot _lastClaim;

    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(_lastClaim);

    public Plot GetClaimWithLongestSide()
    {
        Plot longestPlot = default;
        double maxSide = -1;

        foreach (var plot in _claims)
        {
            double currentMax = plot.GetMaxSide();
            if (currentMax > maxSide)
            {
                maxSide = currentMax;
                longestPlot = plot;
            }
        }

        return longestPlot;
    }
}