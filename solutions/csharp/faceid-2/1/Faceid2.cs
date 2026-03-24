using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    // Task 1: Override Equals to compare values
    public override bool Equals(object obj)
    {
        if (obj is not FacialFeatures other) return false;
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    // Task 1: GetHashCode must match Equals logic
    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    // Task 2: Override Equals for Identity
    public override bool Equals(object obj)
    {
        if (obj is not Identity other) return false;
        return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    // Task 3 & 4: Store registered identities in a Set for uniqueness
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        // Uses our overridden Equals method
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        // Task 2: Check against the hardcoded admin credentials
        var adminFeatures = new FacialFeatures("green", 0.9m);
        var adminIdentity = new Identity("admin@exerc.ism", adminFeatures);
        return identity.Equals(adminIdentity);
    }

    public bool Register(Identity identity)
    {
        // Task 3: HashSet.Add returns false if the item already exists
        return _registeredIdentities.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        // Task 4: Check if the identity exists in the set
        return _registeredIdentities.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        // Task 5: ReferenceEquals ignores our custom Equals and checks memory address
        return Object.ReferenceEquals(identityA, identityB);
    }
}